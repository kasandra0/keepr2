<template>
  <div class="">
    <div class="row card-collumns text-center">
      <div class="col-12">
        <h4>My Keeps</h4>
      </div>
      <keepCard v-for="k in keeps" :keepData="k" :displayRemove="false" class="col-12 col-sm-6 col-md-4 col-lg-3"></keepCard>
    </div>
    <keepForm></keepForm>
  </div>
</template>

<script>
  import keepCard from "@/components/keepCard.vue"
  import keepForm from "@/components/keepForm.vue"
  export default {
    name: 'myKeeps',
    components: {
      keepCard,
      keepForm
    },
    data() {
      return {

      }
    },
    computed: {
      keeps() {
        return this.$store.state.userKeeps
      }
    },
    mounted() { },
    methods: {}
  }

</script>

<style>


</style>