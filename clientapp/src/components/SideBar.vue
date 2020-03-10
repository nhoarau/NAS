<template>
    <div class="q-pa-md q-gutter-sm">
    <q-tree
      :nodes="tree"
      node-key="libelle"
    />
  </div>
</template>

<script>
export default {
  name: 'sideBar',
  props: {
    tree: Object
  }
}
</script>

<style>

</style>
