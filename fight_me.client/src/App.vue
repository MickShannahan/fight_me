<template >
  <main :class="{'theme--default': theme, 'theme--dark': !theme}">
    <router-view />
    <button @click="theme = !theme"> change theme {{bodyBg}}</button>
  </main>
</template>

<script>
import { computed, ref, watchEffect } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    const theme = ref(true)
    watchEffect(()=> document.body.style.backgroundColor = theme.value ? '#e9ecef':'#070725')
    return {
      theme,
      appState: computed(() => AppState),
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
body{
  transition: background-color .5s ease;
  background-image: url('./assets/img/backgrounds/Background grid.png');
  background-size: 100vh;
  background-repeat: no-repeat;
  background-position: bottom right;
}

</style>
