<template>
  <div id="UkEnergy" class="container">
    <h3> UK Energy Generation Sources:</h3>
    UK Energy generation mix for the 30 minutes starting at ({{startTime}}) courtesy of the National Grid: <a href="https://api.carbonintensity.org.uk/generation">https://api.carbonintensity.org.uk/generation</a>
    <table class="table">
      <thead>
      <tr>
        <th scope="col">Fuel</th>
        <th scope="col">Percentage</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="source in ukEnergy?.sort()" v-bind:key="source.fuel">
        <th scope="row">{{source.fuel}}</th>
        <td>{{source.perc}}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';

function sortByUsageDescending( a, b ) {
  if ( a.perc < b.perc ){
    return 1;
  }
  if ( a.perc > b.perc ){
    return -1;
  }
  return 0;
}

export default {
  name: 'UkEnergy',
  data() {
    return {
      ukEnergy: null,
      startTime: null
    };
  },
  created: function () {
    axios
        .get('https://api.carbonintensity.org.uk/generation')
        .then(res => {
          this.ukEnergy = res.data.data?.generationmix.sort(sortByUsageDescending);
          this.startTime = new Date(res.data.data?.from).toLocaleString();
        })
  }
}
</script>

<style>
</style>