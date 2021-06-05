<template>
  <img alt="Alexander On Test logo" src="./assets/AlexanderOnTestLogo.svg">
  <h1>AlexanderOnTest: Automating tables</h1>
  <div id="tables">
    <Users />
    <Rates />
    <UkEnergy />
  </div>
</template>

<script>
import Rates from './components/CryptoPrices.vue'
import Users from './components/Users.vue'
import UkEnergy from './components/UkEnergyMix.vue'

export default {
  name: 'Tables',
  components: {
    Rates,
    Users,
    UkEnergy
  }
}
</script>

