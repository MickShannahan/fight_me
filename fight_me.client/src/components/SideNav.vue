<template>

<div class="side-nav text">

  <Login class=" text"/>

  <div v-for="nav in tabs" :key="nav.name" class="nav-tab selectable p-1 py-2" :class="{'active': $route.name == nav.page}" @click="goTo(nav.page)"><img :src="'../assets/img/3d/'+nav.icon" class="nav-icon">
    <b class="nav-item ms-1">{{nav.name}}</b>
  </div>
</div>

</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
import { useRouter } from "vue-router"
export default {
  setup(){
    const router = useRouter()
    return{
      user: computed(()=> AppState.user),
      tabs: [
        {
          icon: "FightMeStickP1-4.png",
          name: "Games",
          page: "Games"
        },
         {
          icon: "FightMeP1.png",
          name: "Fight",
          page: "Fight"
        }
      ],
      goTo(page){
        router.push({name: page})
      }
    }
  }
}
</script>

<style lang="scss" >
@import "../assets/scss/main.scss";

.side-nav{
  position: absolute;
  z-index: 1050;
  left: 0;
  top: 0;
  bottom: 0;
  transition: all .2s ease;
  @include themed(){
    transition: all .2s ease;
    background-color: _('bg-nav');
  }
    width: 60px;
    max-height: 100vh;
    .nav-item{
    @include hide('x')
    }
  &:hover{
    width: 140px;
      .nav-item{
        @include hide('show', .5s);
        justify-content: start;

      }
    }
  div{
    margin: 2em 0em;
  }
  & .active{
    background-color: $secondary;
      color: $light;
  }
  @media (max-width: 768px) {
    display: none;
  }
}

.nav-icon{
  height: 40px;
  width: 40px;
  filter: drop-shadow(0px 0px 1px black);
}

.nav-tab{
  display: flex;
  justify-content: center;
  align-items: center;
}


</style>
