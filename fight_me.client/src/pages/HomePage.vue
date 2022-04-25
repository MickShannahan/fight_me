<template>
  <div class=" home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <Border class="rounded  elevation-3">
      <div  class="bg-card home-card py-3">
        <img src="../assets/img/3d/FM-soft.png" alt="fight me logo" class="rounded-circle">
        <h1 class="mt-5 mb-0 bg-dark text-white p-3 rounded text-center ">
          Fight Me
        </h1>
      </div >
    </Border>
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped lang="scss">

.home{
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card{
    width: 50vw;
    > img{
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
