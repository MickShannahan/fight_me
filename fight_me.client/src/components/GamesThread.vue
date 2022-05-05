<template>
<Border class="rounded">
  <div class="bg-card rounded row px-3 pb-3 pt-1 text">
    <!-- SORT -->
    <div class="col-12">
      <div class="row justify-content-between py-3 ">
        <div class="col-5 ps-1"><SearchGames/></div>
        <div class="col-2"><Loader/></div>
        <div class="col-5 pe-0" ><FilterGames/></div>
      </div>
    </div>
    <!-- GAMES STACK -->
    <div class="col-custom"  v-for="g in games" :key="g.id">
      <Game :game="g" @gameClick="gameClicked"/>
    </div>
    <div v-for="num in 10" :key="num" class="col-custom placeholder">

    </div>
  </div>
</Border>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  setup(props, {emit}){
    return{
      games: computed(()=> AppState.games),
      gameClicked(game){
        emit('gameClick', game)
      }
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";



.placeholder{
  background-color: transparent;
  cursor: unset !important;
}

.col-custom{
  padding: 0 .5em;
  flex: 1 0 auto;
  width: 10rem;
  max-width: 13em;
}
</style>
