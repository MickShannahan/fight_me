<template>
  <div class="row justify-content-between my-1">
<Border class="rounded col-4 ">
    <div class="bg-card"><PlayerCard/></div>
  </Border>
    <div class="col-4"><QueueStatus/></div>
  <Border class="rounded col-4 ">
    <div class="bg-card"><MatchSettings/></div>
  </Border>
  </div>
  <!-- CURRENT GAME QUEUE -->
  <div class="row justify-content-center mt-3 px-3 py-1">
  <Border class="rounded col-12 col-md-11 col-lg-10">
    <div class="bg-card row game-queue">
    <div class="bungee col-12 text-center py-3">Current Queue</div>
      <div class=" col-custom"  v-for="g in gameQueue" :key="g.id">
        <Game :game="g"/>
        <i class="mdi mdi-close btn btn-danger " @click="removeFromQ(g.id)"></i>

      </div>
      <!-- <div v-for="num in 6" :key="num" class="col-custom placeholder"></div> -->
    </div>
  </Border>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  setup(props, {emit}){
    return{
      gameQueue: computed(()=> AppState.gameQueue),
      gameClicked(game){
        emit('gameClick', game)
      },
      removeFromQ(id){
        AppState.gameQueue = AppState.gameQueue.filter(g => g.id != id)
      }
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";



.game-queue{
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  min-height: 20em;
  background-image: url('../assets/img/3d/FM-Stage-castle-blue.png');
  background-position: right bottom;
  background-size: 30em;
  background-repeat: no-repeat;
}

.placeholder{
  background-color: transparent;
  cursor: unset !important;
}
.col-custom{
  position: relative;
  padding: 0 .5em;
  flex: 1 0 auto;
  width: 10rem;
  max-width: 15em;
  .mdi-close{
    position: absolute !important;
    background: $danger;
    height: 40px;
    width: 40px;
    z-index: 100;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 50px;
    top: 0;
    left: calc(50% - 15px);
    transition: all .1s ease;
    transform: translateY(5px);
    opacity: 0;
    @include selectable($light, $danger, .5 )
  }
  &:hover .mdi-close{
    transform: translateY(-40px);
    opacity: 1;
  }
}
</style>
