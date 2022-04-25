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

<style lang="scss" scoped>
@import "../assets/scss/main.scss";

.border-gradient{
  padding: 2px;
	background: linear-gradient(to top, $primary, $secondary);
}
</style>
