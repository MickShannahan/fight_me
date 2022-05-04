<template>
    <div class="row justify-content-center px-4">
      <div class="col-12">
      <MatchQueue/>
      </div>
      <div class="col-12 col-md-11 col-lg-10">
        <GamesThread/>
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
    }
  }
}
</script>

<style>

</style>
