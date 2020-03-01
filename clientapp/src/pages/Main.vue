<template>
    <q-page padding>
      <h1>OULA</h1>
      <q-btn color="secondary" label="Enter" @click="redirect()"/>
    </q-page>
</template>

<script>
import HttpFactory from '../api/HttpFactory'
import FileRoad from '../models/FileRoad'

export default {
  name: 'Main',
  methods: {
    redirect () {
      const TreeStorage = HttpFactory.get('tree')
      TreeStorage.get()
        .then(response => {
          console.log(FileRoad)
        })
    }
  }
}
</script>
