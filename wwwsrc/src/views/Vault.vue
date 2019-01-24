<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Vault: {{vault.name}}</h1>
        <h6>{{vault.description}}</h6>
      </div>
    </div>
    <div class="row card-collumns">
      <keepCard v-for="keep in vault.keeps" :keepData="keep" :displayRemove="true" class="col-12 col-sm-6 col-md-4 col-lg-3"></keepCard>
    </div>
  </div>
</template>

<script>
  import keepCard from "@/components/keepCard.vue"

  export default {
    name: 'Vault',
    components: {
      keepCard
    },
    data() {
      return {}
    },
    computed: {
      vault() {
        return this.$store.state.activeVault
      }
    },
    mounted() {
      this.$store.dispatch('getKeepsByVaultId', this.$route.params.vaultid)
    },
    methods: {

    }
  }

</script>

<style>


</style>