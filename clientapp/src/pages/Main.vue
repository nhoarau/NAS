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
  data () {
    return {
      visible: true,
      simple: []
    }
  },
  methods: {
    redirect () {
      const TreeStorage = HttpFactory.get('tree')
      TreeStorage.get()
        .then(response => {
          let chemin = this.cheminGobal
          chemin = response.data
          this.simple = []
          this.simple = chemin
          console.log(this.simple)
        })
    }
  }
}
</script>
