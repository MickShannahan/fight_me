<template>
  <div class="bottom-nav sticky-top">
    Bottom Nav
  </div>
</template>

<script>
export default {

}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";

  .bottom-nav{
    @include themed(){
    background-color: $primary;
    display: flex;
    width: 100%;
    height: 4vh;
    position: sticky;
    bottom: 0;

  }
}
</style>
