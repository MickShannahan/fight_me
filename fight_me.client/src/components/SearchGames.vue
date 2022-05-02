<template>
<form action="" @submit="searchGames" class="d-flex">
  <div class="input-group h-25 d-flex">
    <input type="text" class="" v-model="search" placeholder="search game...">
    <button class="btn btn-outline-primary h-25 px-3 py-0"><i class="mdi mdi-magnify"></i></button>
  </div>
</form>
</template>

<script>
import { ref } from "@vue/reactivity"
import { gamesService } from "../services/GamesService"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
export default {
 setup(){
   const search = ref('')
   return {
     search,
     async searchGames(){
       try {
         await gamesService.getGames('?search='+ search.value.trim())
       } catch (error) {
        Pop.toast(error.message)
        logger.error(error)
       }
     }
   }
 }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";

input{
  @include themed(){
    transition: all .1s ease;
    border: 1px solid $primary!important;
    background-color: _('bg');
    color: _('text');
    font-family: Arial, Helvetica, sans-serif;
  }
}
</style>
