<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-10 offset-1 text-center">
        <div class="card border-0">
          <h1>{{activeKeep.name}}</h1ß>
            <img :src="activeKeep.img" class="card-img-top">
            <div class="card-body">
              <h3>{{activeKeep.description}}</h3>
              <i class="fas fa-desktop"></i> Views: {{activeKeep.views}}
              <i class="fas fa-thumbtack"></i> Keeps: {{activeKeep.keeps}}
              <i class="fas fa-bullhorn"></i> Shares: {{activeKeep.shares}}
            </div>
        </div>
        <select v-model="selectedVault" class="custom-select custom-select-lg mb-3">
          <option selected>Choose a Vault</option>
          <option v-for="vault in vaults" :value="vault.id">{{vault.name}}</option>
        </select>
        <button @click.prevent="addKeepToVault()" type="button" class="btn btn-primary">Keep it</button>
        <button @click.prevent="deleteKeep()" type="button" class="btn btn-danger">Delete</button>
        {{selectedVault}}
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'Keep',
    data() {
      return {
        selectedVault: {}
      }
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    mounted() {
      this.$store.dispatch('getKeepById', this.$route.params.keepid)
      this.$store.dispatch('incrementKeepViews', this.$route.params.keepid)
    },
    methods: {
      deleteKeep() {
        this.$store.dispatch('deleteKeep', this.$route.params.keepid)
      },
      addKeepToVault() {
        if (Number.isInteger(this.selectedVault)) {
          let vaultkeep = {
            vaultId: this.selectedVault,
            keepId: this.activeKeep.id
          }
          this.$store.dispatch('addKeepToVault', vaultkeep)
        } else {
          console.log("select a vault")
        }
      }
    }
  }

</script>

<style>


</style>