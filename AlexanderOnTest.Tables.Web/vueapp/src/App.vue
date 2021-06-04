<template>
  <img alt="Alexander On Test logo" src="./assets/AlexanderOnTestLogo.svg">
  <h1>AlexanderOnTest: Automating tables</h1>
  <div id="tables">
    <Users />
    <Rates />
  </div>
</template>

<script>
import Rates from './components/CryptoPrices.vue'
import Users from './components/Users.vue'

export default {
  name: 'Tables',
  components: {
    Rates,
    Users
  }
}
</script>

