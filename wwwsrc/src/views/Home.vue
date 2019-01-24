<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>Welcome Home</h1>
        <h3>Public Keeps</h3>
      </div>
    </div>
    <div class="row card-collumns">
      <keepCard v-for="k in publicKeeps" :keepData="k" class="col-12 col-sm-6 col-md-4 col-lg-3"></keepCard>
    </div>
  </div>
</template>

<script>
  import keepCard from "@/components/keepCard.vue"

  export default {
    name: "home",
    components: {
      keepCard
    },
    computed: {
      publicKeeps() {
        return this.$store.state.publicKeeps
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      this.$store.dispatch('getAllPublicKeeps')
    }
  }
</script>
<style scoped>

</style>