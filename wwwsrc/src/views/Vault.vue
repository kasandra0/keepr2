<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Vault: {{vault.name}}</h1>
        <h6>{{vault.description}}</h6>
      </div>
    </div>
    <div class="row card-collumns">
      <keep v-for="keep in vault.keeps" :keepData="keep" class="col-12 col-sm-6 col-md-4 col-lg-3"></keep>
    </div>
  </div>
</template>

<script>
  import keep from "@/components/keep.vue"

  export default {
    name: 'Vault',
    components: {
      keep
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
    methods: {}
  }

</script>

<style>


</style>