<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Dashboard</h1>
      </div>
      <div class="col-12">
      </div>
    </div>
    <dashNav></dashNav>
    <myVaults></myVaults>
    <myKeeps></myKeeps>

  </div>
</template>

<script>
  import myVaults from "@/components/myVaults.vue"
  import myKeeps from "@/components/myKeeps.vue"
  import dashNav from "@/components/dashNav.vue"
  export default {
    name: 'Dashboard',
    components: {
      dashNav,
      myVaults,
      myKeeps
    },
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getAllVaults')
      this.$store.dispatch('getAllKeepsByUser')

    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      goToVaultView(vaultId) {
        // this.$router.push({ name: 'vault', params: { vaultId } })
      }
    }
  }

</script>

<style>


</style>