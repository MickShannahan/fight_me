<template>
<div class="wrapper">
<div class="game selectable elevation-2 p-2" @click="gameClicked">
</div>
  <div class="title">
    {{game.title}}
  </div>
  <div class="subtitle">
    {{game.subtitle}}
  </div>
  <div class="f-13">
    <Categories :categories="categories?.slice(0,2)" @clicked="searchByCategory"/>
  </div>
</div>
</template>

<script>
import { computed } from "@vue/reactivity"
import { onMounted } from "@vue/runtime-core"
import Pop from "../utils/Pop"
import {categoriesService} from '../services/CategoriesService'
import { AppState } from "../AppState"
import Categories from "./Categories.vue"
import { logger } from "../utils/Logger"
import { gamesService } from "../services/GamesService"
export default {
  props: {
    game: {type: Object, required: true}
  },
  setup(props, {emit}){
    onMounted(async ()=>{
      try {
        let catsFound = AppState.categories[props.game.id]
        if(!catsFound){
          await categoriesService.getCategories('?gameId='+props.game.id, props.game.id)
        }
      } catch (error) {
        Pop.error(error)
      }
    })
    return{
      categories: computed(()=> AppState.categories[props.game.id]),
      bgImage: computed(()=> `url(${props.game.posterImg})`),
      searchByCategory(category){
        logger.log(category)
        gamesService.getGames('?category='+category.name)
        AppState.searchCategories = [category]
      },
      gameClicked(){
        emit('gameClick', props.game)
      }
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";
.wrapper{
  margin-bottom: 2em;
}

.f-13{
  font-size: 13px;
}

.game{
  border-radius: 3px;
  transition: all .1s linear;
  min-height: 24vh;
  max-height: 18vw;
  background-image: v-bind(bgImage);
  background-position: center;
  background-size: cover;
  &:hover{
    transform: translate(4px, -4px);
    box-shadow: -1px 1px 0px $secondary, -2px 2px 0px $secondary,-3px 3px 0px $secondary, -4px 4px 0px $secondary, -5px 5px 0px $secondary;
  }
}

.title{
  font-weight: 500;
  margin-top: .25em;
}
.subtitle{
  font-size: 13px;
  font-family: "Nunito";
  font-weight: 400;
  margin-bottom: .25em;
}


</style>
