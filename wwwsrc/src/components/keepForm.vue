<template>
  <div class="row">
    <div class="col-12">
      <h4>Create a new Keep</h4>
      <form action="">
        <div class="form-group">
          <label for="">Keep Name: </label>
          <input type="text" v-model="newKeep.name" class="form-control">
        </div>
        <div class="form-group">
          <label for="">Image Url: </label>
          <input type="text" name="" v-model="newKeep.img" class="form-control">
        </div>
        <div class="form-group">
          <label for="">Description: </label>
          <input type="text" v-model="newKeep.description" class="form-control">
        </div>
        <button @click.prevent="createNewKeep()" class="btn btn-primary">Save</button>
      </form>
      {{newKeep.name}}
      {{newKeep.description}}
    </div>
  </div>
</template>

<script>
  export default {
    name: 'keepForm',
    data() {
      return {
        newKeep: {
          name: '',
          img: '',
          description: '',
          isPrivate: 0
        }
      }
    },
    computed: {},
    methods: {
      createNewKeep() {
        this.$store.dispatch('createNewKeep', this.newKeep)
      }
    }
  }

</script>

<style>


</style>