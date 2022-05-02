<template>
  <i v-if="loading" class="loader line"></i>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  setup(){
    return{
      loading:computed(()=> AppState.loading)
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";
</style>
