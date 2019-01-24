<template>
  <div class="">
    <div class="row card-deck">
      <div class="col-12 text-center">
        <h4>My Vaults</h4>
      </div>
      <div v-for="vault in vaults" class="col-12 col-md-5 m-1">
        <div class="card">
          <div class="card-body" @click.prevent="goToVaultView(vault.id)">
            <h4 class="card-title">{{vault.name}}</h4>
            <p>{{vault.description}}</p>
          </div>
          <div class="card-footer">
            <button @click="deleteVault(vault.id)" type="button" class="btn btn-danger">Delete Vault</button>
          </div>
        </div>
      </div>
    </div>
    <!-- Create vault form -->
    <vaultForm></vaultForm>
  </div>
</template>

<script>
  import vaultForm from "@/components/vaultForm.vue"

  export default {
    name: 'myVaults',
    components: {
      vaultForm
    },
    data() {
      return {

      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    mounted() {
      this.$store.dispatch('getAllVaults')
    },
    methods: {
      goToVaultView(vaultId) {
        this.$store.dispatch('getActiveVault', vaultId)
      },
      deleteVault(vaultId) {
        this.$store.dispatch('deleteVault', vaultId)
      }
    }
  }

</script>

<style>


</style>