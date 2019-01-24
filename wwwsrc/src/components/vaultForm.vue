<template>
  <div class="row">
    <div class="col-12">
      <h4>Create a new Vault</h4>
      <form action="">
        <div class="form-group">
          <label for="">Vault Name: </label>
          <input type="text" v-model="vault.name" class="form-control">
        </div>
        <div class="form-group">
          <label for="">Description: </label>
          <input type="text" v-model="vault.description" class="form-control">
        </div>
        <button @click.prevent="CreateNewVault()" class="btn btn-primary">Save</button>
      </form>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaultForm',
    data() {
      return {
        vault: {
          name: '',
          description: ''
        }
      }
    },
    computed: {},
    methods: {
      CreateNewVault() {
        this.$store.dispatch('createNewVault', this.vault)
      }
    }
  }

</script>

<style>


</style>