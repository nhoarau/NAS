<template>
    <q-page padding>
      <h1>test</h1>
      <q-btn color="secondary" label="Enter" @click="redirect()"/>
    </q-page>
</template>

<script>
import HttpFactory from '../api/HttpFactory'

export default {
  name: 'Main',
  props: {
    cheminGobal: Object
  },
  methods: {
    redirect () {
      const TreeStorage = HttpFactory.get('tree')
      TreeStorage.get()
        .then(response => {
          let chemin = this.cheminGobal
          chemin = response.data
          console.log(chemin)
        })
    }
  }
}
</script>
