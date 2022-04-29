<template>
<div class="side-nav bg-card text p-2">
  <div class="d-flex align-items-center">
    💀
  <Login class="nav-item"/>
  </div>
  <div class="d-flex">🌭<b class="nav-item ">hotdog</b></div>
  <div class="d-flex">🍕<b class="nav-item ">pizza</b></div>
</div>
</template>

<script>
export default {

}
</script>

<style lang="scss" scoped>
@import "../assets/scss/mixins.scss";

.side-nav{
  transition: all .2s ease;
  @media (min-width: 768px) {
    width: 50px;
    max-height: 100vh;
    .nav-item{
    @include hide('x')

    }
  &:hover{
    width: 140px;
      .nav-item{
        @include hide('show')
      }
    }
  }
  div{
    margin: 2em .5em;
  }
}

</style>
