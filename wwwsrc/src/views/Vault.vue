<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Vault:</h1>
      </div>
    </div>
  </div>
</template>

<script>
  import keep from "@/components/keep.vue"

  export default {
    name: 'Vault',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getKeepsByVaultId', this.$route.params.vaultid)
    },
    components: {
      keep
    },
    computed: {},
    methods: {}
  }

</script>

<style>


</style>