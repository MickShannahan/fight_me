<template>
<div class="side-nav text p-2">
  <div class="d-flex align-items-center" :class="{'flex-column': user.isAuthenticated}">
    <img v-if="!user.isAuthenticated" src="../assets/img/3d/FM-Skull.png" class="nav-icon">
    <img v-else :src="user.picture" class="nav-icon rounded">
  <Login class="nav-item text"/>
  </div>
  <div class="d-flex selectable p-1"><img src="../assets/img/3d/FightMeP1.png" class="nav-icon"><b class="nav-item ms-1">hotdog</b></div>
</div>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  setup(){
    return{
      user: computed(()=> AppState.user)
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";

.side-nav{
  transition: all .2s ease;
  @include themed(){
    transition: all .2s ease;
    background-color: _('bg-nav');
  }
  @media (min-width: 768px) {
    width: 60px;
    max-height: 100vh;
    .nav-item{
    @include hide('x')

    }
  &:hover{
    width: 140px;
      .nav-item{
        @include hide('show')
      }
    }
  }
  div{
    margin: 2em .5em;
  }
}

.nav-icon{
  height: 30px;
  width: 30px;
  filter: drop-shadow(0px 0px 1px black);
}

</style>
