<template>
  <div class="">
    <div class="row card-deck">
      <div class="col-12 text-center">
        <h4>My Vaults</h4>
      </div>
      <div v-for="vault in vaults" class="col-12 col-md-5 m-1">
        <router-link :to="{name: 'vault', params:{vaultid: vault.id}}" class="card">
          <div class="card-body">
            <h4 class="card-title">{{vault.name}}</h4>
            <p>{{vault.description}}</p>
          </div>
          <div class="card-footer">
          </div>
        </router-link>
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
    methods: {}
  }

</script>

<style>


</style>