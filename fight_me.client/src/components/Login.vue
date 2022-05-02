<template>
    <div
      class="selectable text d-flex align-items-center justify-content-center"
      @click="login"
      v-if="!user.isAuthenticated"
    >
    <img v-if="!user.isAuthenticated" src="../assets/img/3d/FM-Skull.png" class="nav-icon">
    <div class="nav-item">
      Login
    </div>
    </div>
    <div v-else class="drop-menu text">
      <div>
        <img :src="user.picture" class="nav-icon rounded">
      </div>
      <!-- Dashboard -->
      <div class="selectable" :class="{'active': $route.name == 'Dashboard'}" @click="goTo('Dashboard')"><i class="mdi mdi-view-dashboard"></i><b class="nav-item ms-1" >Dashboard</b></div>
      <!-- Account -->
      <div class="selectable" :class="{'active': $route.name == 'Account'}" @click="goTo('Account')"><i class="mdi mdi-account-box"></i><b class="nav-item ms-1" >Account</b></div>
      <!-- LogOut -->
      <div class="selectable"><i class="mdi mdi-arrow-collapse-left" @click="logout"></i><b class="nav-item ms-1">Logout</b></div>
    </div>


</template>


<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import { AuthService } from "../services/AuthService";
import { useRouter } from "vue-router";
export default {
  setup() {
    const router = useRouter()
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup();
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin });
      },
      goTo(page){
        router.push({name: page})
      }
    };
  },
};
</script>


<style lang="scss" scoped>
@import "../assets/scss/main.scss";

.drop-menu {


  div{
    transition: all .2s ease;
    margin: .5em 0px;
    padding: .4em .5em;
    display: flex;
    justify-content: center ;
    align-items: center;
    &.active{
        background-color: $secondary;
        color: $light;
    }
  }


}

</style>
