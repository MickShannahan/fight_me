<template>
  <div class="filter-component">
    <div>
      <Categories :categories="searchCategories"/>
      <i v-if="searchCategories.length" class="mdi mdi-close px-2 py-1 selectable" @click="filter('clear')"></i>
    </div>
    <div class="p-1 px-3 rounded selectable filter-button" @click="open = true">
      <span>sort </span><i class="mdi mdi-sort f-2"></i>
    </div>
    <div class="drop-menu elevation-5" :class="{'open': open}">
      <div class="drop-item selectable" @click="filter('popular')"><i class="mdi mdi-star"></i><i class="mdi mdi-arrow-down"></i>popular</div>
      <div class="drop-item selectable" @click="filter('hidden')"><i class="mdi mdi-star"></i><i class="mdi mdi-arrow-up"></i>hidden</div>
      <div class="drop-item selectable" @click="filter('a-z')"><i class="mdi mdi-sort-alphabetical-ascending"></i> a-z</div>
      <div class="drop-item selectable" @click="filter('z-a')"><i class="mdi mdi-sort-alphabetical-descending"></i>z-a</div>
    </div>
  </div>
</template>

<script>
import { computed, ref } from "@vue/reactivity"
import { AppState } from "../AppState"
import { watchEffect } from "@vue/runtime-core"
import { logger } from "../utils/Logger"
import { gamesService } from "../services/GamesService"
export default {
  setup(){
    const open = ref(false)
    watchEffect(()=>{
      if(open.value){
        let fn;
        fn = ()=> { document.body.removeEventListener('click', fn);open.value = false}
        setTimeout(()=>{
            document.body.addEventListener('click', fn)
        }, 10)
      }
    })
    return {
      open,
      searchCategories: computed(()=>AppState.searchCategories),
      filter(type){
        switch (type){
          case 'popular':
            AppState.games = AppState.games.sort((a,b) => b.popularity-a.popularity)
          break;
          case 'hidden':
            AppState.games = AppState.games.sort((a,b) => a.popularity-b.popularity)
          break;
          case 'a-z':
            AppState.games = AppState.games.sort((a,b) => {
              if(a.title < b.title) { return -1; }
              if(a.title > b.title) { return 1; }
              return 0;
              })
            break;
          case 'z-a':
             AppState.games = AppState.games.sort((a,b) => {
              if(a.title > b.title) { return -1; }
              if(a.title < b.title) { return 1; }
              return 0;
              })
          break;
          default:
            AppState.searchCategories = []
            gamesService.getGames()
            break;
        }
        open.value = false;
      }
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";

.filter-component{
  display: flex;
  justify-content: end;
  text-align: end;
}

.filter-button{
  span{
    transition: all .1s ease;
    @include hide('x')
  }
  &:hover{
    span{
      @include hide('show')
    }
  }


}
.drop-menu{
  @include themed(){
    text-align: start;
    transform: translateY(2em);
    position: absolute;
    background: _('bg') ;
    z-index: 1050;
    @include hide('y');

      &.open{
        @include hide('show');
      }
    .drop-item{
      border-radius: 0px;
      transition: all .1s ease;
      margin: .5em 0em;
      padding: .25em 1em;
      &:hover{
        background-color: _('bg-nav');
        color: _('text-contrast');
      }
    }
  }
}
</style>
