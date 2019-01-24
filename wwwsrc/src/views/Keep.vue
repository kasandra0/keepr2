<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-10 offset-1 text-center">
        <div class="card border-0">
          <h1>{{activeKeep.name}}</h1ß>
            <img :src="activeKeep.img" class="card-img-top">
            <div class="card-body">
              <h3>{{activeKeep.description}}</h3>
            </div>
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
    },
    methods: {}
  }

</script>

<style>


</style>