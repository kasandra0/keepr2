<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Dashboard</h1>
      </div>
      <div class="col-12">
      </div>
    </div>
    <div class="row">
      <div class="col-10 offset-1 p-2 text-center">
        <button @click.prevent="dashView= 'vaults'" type="button" class="btn btn-outline-primary m-1">Vaults</button>
        <button @click.prevent="dashView= 'keeps'" type="button" class="btn btn-outline-primary m-1">Keeps</button>
      </div>
    </div>
    <myVaults v-if="dashView== 'vaults'"></myVaults>
    <myKeeps v-if="dashView=='keeps'"></myKeeps>

  </div>
</template>

<script>
  import myVaults from "@/components/myVaults.vue"
  import myKeeps from "@/components/myKeeps.vue"
  export default {
    name: 'Dashboard',
    components: {
      myVaults,
      myKeeps
    },
    data() {
      return {
        dashView: 'vaults'
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