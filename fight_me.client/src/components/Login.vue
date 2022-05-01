<template>
  <span class="navbar-text">
    <button
      class="btn selectable text text-uppercase my-2 my-lg-0"
      @click="login"
      v-if="!user.isAuthenticated"
    >
      Login
    </button>
    <div v-else class="drop-menu text">
    <div class="selectable">Dashboard</div>
    <div class="selectable">Account</div>
    <div class="selectable f-100" @click="logout">logout</div>
    </div>


  </span>
</template>


<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import { AuthService } from "../services/AuthService";
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup();
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin });
      },
    };
  },
};
</script>


<style lang="scss" scoped>
@import "../assets/scss/main.scss";

.drop-menu {


  div{
    margin: .5em 0px;
    padding: .25em .5em;
    border-radius: 5px;
    font-weight: bold;
  }
}

</style>
