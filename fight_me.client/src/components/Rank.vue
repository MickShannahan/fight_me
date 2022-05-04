<template>
  <img v-if="rank" :src="league?.img" alt="">
</template>

<script>
import bronze from '../assets/img/3d/FM-Rank-Bronze.png'
import silver from '../assets/img/3d/FM-Rank-Silver.png'
import gold from '../assets/img/3d/FM-Rank-Gold.png'
import diamond from '../assets/img/3d/FM-Rank-Diamond.png'

import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  props:{gameId: {type: Number, required: false, default: 0}},
setup(props){
  return{
    rank: computed(()=>AppState.accountLeagues[props.gameId]),
    league: computed(()=>AppState.accountLeagues[props.gameId]?.league),
  }
}
}
</script>

<style>
img{
  width: 100%;
  filter: drop-shadow(0px 4px 8px rgba(0, 0, 0, 0.301));
}
</style>
