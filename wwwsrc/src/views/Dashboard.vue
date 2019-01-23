<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Dashboard</h1>
      </div>
    </div>

    <div class="row card-deck">
      <div v-for="vault in vaults" class="col-12 col-md-6">
        <div class="card">
          <div class="card-body">
            <h4 class="card-title">{{vault.name}}</h4>
            <p>{{vault.description}}</p>
          </div>
          <div class="card-footer">

          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'Dashboard',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getAllVaults')
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {}
  }

</script>

<style>


</style>