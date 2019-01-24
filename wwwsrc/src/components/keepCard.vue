<template>
  <div class="card p-2">
    <img :src="keepData.img" class="card-img-top">
    <div class="card-body" @click.prevent="goToKeepView(keepData.id)">
      <h5 class="card-title">{{keepData.name}}</h5>
      <p>{{keepData.description}}</p>
      <p>id# {{keepData.id}}</p>
    </div>
    <div class="card-footer">
      <i class="fas fa-desktop"></i>: {{keepData.views}}
      <i class="fas fa-thumbtack"></i>: {{keepData.keeps}}
      <i class="fas fa-bullhorn"></i>: {{keepData.shares}}
      <button v-if="displayRemove" @click.prevent="removeFromVault()" type="button" class="btn btn-info">Remove from
        vault</button>
    </div>
  </div>
</template>

<script>
  export default {
    name: "keepCard",
    data() {
      return {

      }
    },
    props: ['keepData', 'displayRemove'],
    computed: {
      activeVault() {
        return this.$store.state.activeVault
      }
    },
    methods: {
      goToKeepView(keepid) {
        this.$router.push({ name: 'keep', params: { keepid: keepid } })
      },
      removeFromVault() {
        let vaultkeep = {
          keepId: this.keepData.id,
          vaultId: this.activeVault.id
        }
        this.$store.dispatch('removeKeepFromVault', vaultkeep)
      }
    }
  }

</script>

<style>


</style>