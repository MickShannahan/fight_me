<template >
  <div class="border-gradient">
    <slot ></slot>
  </div>
</template>

<script>
export default {
setup(){}
}
</script>

<style lang="scss">
@import "../assets/scss/main.scss";

.border-gradient{
  padding: 2px;
	background: linear-gradient(to top, $primary, $secondary);
  * {
    border-radius: inherit;
  }
  >* {
    margin: 0px!important;
  }
}
</style>
