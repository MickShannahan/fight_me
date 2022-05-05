<template>
    <div class="row justify-content-center px-4 text">
      <div class="col-12 my-2">
      <MatchQueue/>
      </div>
      <div class="col-12 col-md-11 col-lg-10">
        <GamesThread @gameClick="addToQueue"/>
      </div>

    </div>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
import { onMounted } from "@vue/runtime-core"
import Pop from "../utils/Pop"
import { gamesService } from "../services/GamesService"
import {accountService} from '../services/AccountService'
import { logger } from "../utils/Logger"
export default {
  setup(){
    onMounted(async()=> {
      try {
        await gamesService.getGames()
        await accountService.getAccountLeagues()
      } catch (error) {
        Pop.error(error)
      }
    })
    return{
      addToQueue(game){
        logger.log(game)
        if(AppState.gameQueue.length < 3){
        AppState.gameQueue.push(game)
        } else {
          Pop.toast("max 3 games in queue at a time", 'warning', 'center')
        }
      }
    }
  }
}
</script>

<style>

</style>
