<template>
  <span v-for="(c,i) in categories" :key="c + i" class="category selectable nunito" @click.stop="clicked(c)">
    {{c.name}}
  </span>
</template>

<script>
export default {
props: {categories: {type: Array, required: false}},
setup(props, {emit}){
  return{
    clicked(cat){
      emit('clicked',cat)
    }
  }
}
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";
.category{
@include themed(){
  transition: all .1s ease;
  text-align: center;
  text-justify: center;
  color: _('text-muted');
  font-size: inherit;
  font-weight: 600;
  padding: .1em .5em;
  margin-top: .1em;
  margin-right:.2em;
  border-radius: 50px;
  background: _('bg-alt');
}
}
</style>
