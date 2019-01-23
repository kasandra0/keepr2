<template>
  <div class="card p-2">
    <img :src="keepData.img" class="card-img-top">
    <div class="card-body">
      <h5 class="card-title">{{keepData.name}}</h5>
      <p>{{keepData.description}}</p>
    </div>
    <div class="card-footer">
      <i class="fas fa-desktop"></i>: {{keepData.views}}
      <i class="fas fa-thumbtack"></i>: {{keepData.keeps}}
      <i class="fas fa-bullhorn"></i>: {{keepData.shares}}
    </div>
  </div>
</template>

<script>
  export default {
    name: "keep",
    data() {
      return {

      }
    },
    props: ['keepData'],
    computed: {},
    methods: {}
  }

</script>

<style>


</style>