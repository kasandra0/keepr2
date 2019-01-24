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
        <div v-if="true">
          <button @click.prevent="deleteKeep()" type="button" class="btn btn-danger">Delete</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'Keep',
    data() {
      return {

      }
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      }
    },
    mounted() {
      this.$store.dispatch('getKeepById', this.$route.params.keepid)
      this.$store.dispatch('incrementKeepViews', this.$route.params.keepid)
    },
    methods: {
      deleteKeep() {
        this.$store.dispatch('deleteKeep', this.$route.params.keepid)
      }
    }
  }

</script>

<style>


</style>