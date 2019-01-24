<template>
  <nav class="navbar navbar-dark bg-dark">
    <router-link :to="{name: 'home'}" class="col-4">
      <button type="button" class="btn btn-outline-light m-1">Public</button>
    </router-link>
    <div v-if="user.id" class="col-6">
      <router-link :to="{name: 'dashboard'}">
        <button type="button" class="btn btn-outline-light m-1">Dash</button>
      </router-link>
      <button type="button" @click="logout()" class="btn btn-outline-light m-1">Logout</button>
    </div>
    <div v-else class="col-4">
      <router-link :to="{name: 'login'}">
        <button type="button" class="btn btn-outline-light m-1">Login</button>
      </router-link>
    </div>
  </nav>
</template>

<script>
  export default {
    name: 'navbar',
    data() {
      return {

      }
    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      }
    }
  }

</script>

<style>
  nav {
    /* min-height: 7vh; */
  }
</style>