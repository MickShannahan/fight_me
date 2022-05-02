<template>
    <button class="theme-button btn bg-card" @click="changeTheme">🌓</button>
</template>

<script>
import { AppState } from "../AppState"
import {localStore} from '../utils/localStorage'
export default {
  setup(){
    return{
      changeTheme(){
        AppState.theme = !AppState.theme
        localStore.savePrefs({theme: AppState.theme})
      }
    }
  }

}
</script>

<style>
.theme-button{
  border: solid 1px var(--bs-primary);
  position: absolute;
  right: 10px;
  top: 10px;
  border-radius: 50px!important;

}
</style>
