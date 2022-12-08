<template>
  <div class="row justify-content-center">
    <h4 class="col-5 bungee text-center">Leaderboard</h4>
    <div v-if="players.length > 0" class="col-11">

      <div class="board-header">
        <div >name</div>
        <div >rank</div>
        <div >elo</div>
        <div >matches</div>
      </div>
      <div class="board-body">
        <div  v-for="p in players" :key="p.id" class="entry selectable" :class="{you: account.id == p.accountId}">
          <div>
            <img :src="p.account.picture" alt="">
            <span>{{p.account.name}}</span>
          </div>
          <div>
            <img :src="p.league.icon || p.league.img" alt="">
            <span>{{p.league.name}}</span>
          </div>
          <div>{{Math.round((p.elo + p.rankedElo) / 2)}}</div>
          <div>{{p.matches}}</div>
        </div>
      </div>

    </div>
    <div v-else class="col-11 text-center p-2">
      no leaderboard for this game yet
    </div>
  </div>




</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  props:{players: {type: Array, required: true}},
setup(){
  return{
    account: computed(()=> AppState.account)
  }
}
}
</script>

<style lang="scss" scoped>
h4{
  border-bottom: 2px solid var(--bs-primary);
  border-radius: 0;
}
.you{
  background-color: var(--bs-primary);
}

.board-header{
  display: grid;
  grid-template-rows: 1fr;
  grid-template-columns: 2fr repeat(3, 1fr);
}
.entry{
  display: grid;
  grid-template-rows: 1fr;
  grid-template-columns:  2fr repeat(3, 1fr);
  padding: .5em .25em;
  border-top: 1px solid var(--bs-light);
  border-radius: 0;
  img{
    width: 25px;
    height: 25px;
    margin-right: .5rem;
    border-radius: 5px;
  }
}
</style>
