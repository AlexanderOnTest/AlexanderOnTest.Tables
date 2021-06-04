<template>
  <div id="cryptocurrencies" class="container">
    <h3> CryptoCurrency Rates in GB £:</h3>
    Data courtesy of <a href="https://api.coinpaprika.com" target="_blank">https://api.coinpaprika.com</a>
    <table class="table">
      <thead>
      <tr>
        <th scope="col" class="text-left">Base currency</th>
        <th scope="col">Quote currency</th>
        <th scope="col" class="text-right">Price in £</th>
        <th scope="col">Updated</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="rate in rates" v-bind:key="rate.pair">
        <th scope="row" class="text-left">{{rate.base_currency_name}}</th>
        <td>{{rate.quote_currency_name}}</td>
        <td class="text-right">£{{rate.quotes.GBP.price.toFixed(2)}}</td>
        <td>{{new Date(rate.last_updated).toLocaleString()}}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';

function sortByRateDescending( a, b ) {
  if ( a.quotes.GBP.price < b.quotes.GBP.price ){
    return 1;
  }
  if ( a.quotes.GBP.price > b.quotes.GBP.price ){
    return -1;
  }
  return 0;
}

export default {
  name: 'Rates',
  data() {
    return {
      rates : null
    };
  },
  created: function () {
    axios
        .get('https://api.coinpaprika.com/v1/exchanges/binance/markets?quotes=GBP')
        .then(res => {
          this.rates = res.data.filter(function (rate) {
            return rate.quote_currency_name === "Pound Sterling";
          }).sort(sortByRateDescending)
        })
  },
}
</script>

<style>
</style>