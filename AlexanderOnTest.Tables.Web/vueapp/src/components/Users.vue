<template>
  <div id="users" class="container">
    Developed from the tutorial: <a href="https://www.blog.duomly.com/vue-js-tutorial-how-to-create-vue-js-app-in-5-minutes/" target="blank">Vue.js Tutorial: How to Create Vue.js App in 5 Minutes?</a>
    <h3> Users:</h3>
    Data courtesy of <a href="https://jsonplaceholder.typicode.com" target="_blank">https://jsonplaceholder.typicode.com</a>
    <table class="table">
      <thead>
      <tr>
        <th scope="col">Id</th>
        <th scope="col">Name</th>
        <th scope="col">Email</th>
        <th scope="col">City</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="user in users" v-bind:key="user.id">
        <th scope="row">{{user.id}}</th>
        <td>{{user.name}}</td>
        <td>{{user.email}}</td>
        <td>{{user.address.city}}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'Users',
  data() {
    return {
      users: null,
    };
  },
  created: function () {
    axios
        .get('https://jsonplaceholder.typicode.com/users')
        .then(res => {
          this.users = res.data;
        })
  }
}
</script>

<style>
</style>