<template>
<Border class="details rounded">
  <div class="bg-card row justify-content-center">
    <i class="mdi mdi-close p-2 selectable" @click="closeDetails"></i>
    <div class="header-img "></div>
    <div class="title-card bg-card border border-primary rounded-pill px-5">
      <h3 class="">{{activeGame.title}}</h3>
      <h6 class="text-muted">{{activeGame.subtitle}}</h6>
      <div>
        <Categories :categories="categories" @clicked="searchCategory"/>
      </div>
    </div>
    <div class="col-12 leaderboard">
      <Leaderboard :players="leaderboard"/>
    </div>
  </div>
</Border>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
import Categories from "./Categories.vue"
import { watchEffect } from "@vue/runtime-core"
import {matchesService} from '../services/MatchesService'
import { gamesService } from "../services/GamesService"
import Pop from "../utils/Pop"
export default {
    setup() {
      watchEffect(async()=>{
        try {
          await gamesService.getLeaderboard(AppState.activeGame.id)
        } catch (error) {
          Pop.error(error)
        }
      })
        return {
            activeGame: computed(() => AppState.activeGame),
            categories: computed(() => AppState.categories[AppState.activeGame?.id]),
            bgImage: computed(() => `url(${AppState.activeGame.coverImg || AppState.activeGame.img || AppState.activeGame.posterImg})`),
            leaderboard: computed(()=> AppState.activeGameLeaderboard),
            closeDetails() {
                AppState.activeGame = {};
            },
            async searchCategory(category) {
                await gamesService.getGames("?category=" + category.name);
                AppState.searchCategories = [category];
                AppState.activeGame = {};
            }
        };
    },
    components: { Categories }
}
</script>

<style lang="scss" scoped>
$img-height: 30vh;
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
  filter: drop-shadow(0px 0px 5px black);
}
}

.header-img{
  background: v-bind(bgImage);
  background-position: center;
  background-size: cover;
  height: $img-height;
  border-end-start-radius: 0;
  border-end-end-radius: 0;
}
.title-card{
  position: absolute;
  display: flex;
  flex-direction: column;
  align-items: center;
  width: unset;
  padding: 1rem;
  top: calc(#{$img-height} - 6vh);
  margin: 0 auto;
}
.leaderboard{
  margin-top: 5em;
}

</style>
