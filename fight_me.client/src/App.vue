<template >
  <main :class="{'theme--default': theme, 'theme--dark': !theme}" class="d-flex">
    <SideNav/>
    <router-view />
    <button class="theme-button btn bg-card" @click="theme = !theme">🌓</button>
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

.theme-button{
  border: solid 1px var(--bs-primary);
  position: absolute;
  right: 10px;
  top: 10px;
  border-radius: 50px!important;

}

</style>
