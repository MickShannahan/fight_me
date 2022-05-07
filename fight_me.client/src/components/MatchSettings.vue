<template>
  <div class="row">

  </div>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  setup(){
    return{
      isRanked: computed(()=>AppState.matchSettings.ranked),
      ranked(bool){
        AppState.matchSettings.ranked = bool
      }
    }
  }
}
</script>

<style>

</style>
