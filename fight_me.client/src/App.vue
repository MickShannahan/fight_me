<template >
  <main :class="{'theme--default': theme, 'theme--dark': !theme}" class="d-flex">
    <SideNav class="side-nav"/>
    <div class="container-fluid ms-md-5">
    <router-view />
    </div>
    <ThemeButton/>
  </main>
    <BottomNav class="bottom-nav"/>
</template>

<script>
import { computed, onMounted, ref, watchEffect } from 'vue'
import { AppState } from './AppState'
import {localStore} from './utils/localStorage'
export default {
  name: 'App',
  setup() {
    onMounted(()=> {
      // need timeout to keep saved theme started on page load
      setTimeout(()=>document.body.style.transition = 'background-color .5s ease', 200)})
    watchEffect(()=> document.body.style.backgroundColor = AppState.theme ? '#e9ecef':'#070725')
    return {
      appState: computed(() => AppState),
      theme: computed(()=> AppState.theme)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
body{
  background-image: url('./assets/img/backgrounds/Background grid.png');
  background-size: 100vh;
  background-repeat: no-repeat;
  background-position: bottom right;
}



.d-flex{
  flex-direction: row;
  @media (max-width: 768px){
    flex-direction: column;
  }
}

.side-nav{
  @media (max-width: 768px) {
    display: none;
  }
}

.bottom-nav{
  @media (min-width: 768px) {
    display: none;
  }
}



</style>
