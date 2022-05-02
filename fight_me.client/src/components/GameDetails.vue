<template>
<Border class="details rounded">
  <div class="bg-card row p-3">
    <i class="mdi mdi-close p-2 selectable" @click="closeDetails"></i>
    <div class="col-12 col-md-6">
      <img :src="activeGame.img || activeGame.posterImg" alt="" class="img-fluid">
    </div>
    <div class="col-12 col-md-6">
      <h3>{{activeGame.title}}</h3>
      <h3>{{activeGame.subtitle}}</h3>
      <h6>
        <Categories :categories="categories" @clicked="searchCategory"/>
      </h6>
    </div>
  </div>
</Border>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
import { gamesService } from "../services/GamesService"
export default {
  setup(){
    return{
      activeGame: computed(()=> AppState.activeGame),
      categories: computed(()=> AppState.categories[AppState.activeGame?.id]),
      closeDetails(){
        AppState.activeGame = {}
      },
      async searchCategory(category){
        await gamesService.getGames('?category='+category.name)
        AppState.searchCategories = [category]
        AppState.activeGame = {}
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.details{
position: relative;
.mdi-close{
  font-size: 25px;
  display: flex;
  justify-content: center;
  align-items: center;
  width: 45px;
  height: 45px;
  position: absolute;
  right: 0;
  top: 0;
}
}

</style>
