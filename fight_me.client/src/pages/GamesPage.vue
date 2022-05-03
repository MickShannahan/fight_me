<template>
<div class=" row text p-2 justify-content-center">
  <div class="col-12 mb-1 d-flex justify-content-center align-items-center text-center bungee">
    <img src="../assets/img/3d/FightMeStickP1-1.png" class="header-img" alt="">
    <h2 class="mx-3">Games</h2>
    <img src="../assets/img/3d/FightMeStickP2-3.png" class="header-img" alt="">
  </div>
  <div class="wrapper d-flex justify-content-center">
    <transition name="fade" >
      <div v-if="!activeGame.id" class="col-12 col-md-11 col-lg-10 ">
      <GamesThread @gameClick="setActiveGame"/>
      </div>
      <div v-else class="col-12 col-md-11 col-lg-10">
        <GameDetails/>
      </div>
    </transition>
  </div>
</div>
</template>

<script>
import { computed, onMounted, watchEffect } from "@vue/runtime-core"
import { AppState } from "../AppState"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { gamesService} from '../services/GamesService'
import { useRoute } from "vue-router"
export default {
  setup(){
    const route = useRoute()
    onMounted(async ()=> {
       try {

        await gamesService.getGames()
      } catch (error) {
        Pop.toast(error.message)
        logger.error(error)
      }
      watchEffect(()=>{
        if(route.name != 'Games') AppState.activeGame = {}; AppState.searchCategories=[];
      })
    })
    return{
      activeGame: computed(()=> AppState.activeGame),
      setActiveGame(game){
        logger.log(game)
        AppState.activeGame = game
      }
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";
.wrapper{
  position: relative;
}
.header-img{
  height: 60px;
  width: 60px;
}

.fade-enter-active,
.fade-leave-active {
  transition: all .2s ease;
}
.fade-enter-from,
.fade-leave-to {
  opacity: 0;
  filter: blur(2px);
  position: absolute;
  padding: 0 10px;
  transform: translateY(5px);
}
</style>
