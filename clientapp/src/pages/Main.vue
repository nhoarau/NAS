<template>
    <q-page id="container" padding>
      <q-btn class="glossy" round color="primary" @click="goBack()" icon="fas fa-chevron-left" :disabled="previous.length == 0"/>
      <h3>{{directory.name}}</h3>
      <div style="display: flex; flex-wrap: wrap;">
        <div class="folder-item"  v-for="dir in directory.subDirectories" v-bind:key="dir" @click="openFolder(dir.url)">
          <img src="https://img.icons8.com/cotton/64/000000/folder-invoices--v1.png" height="50" width="50">
          <h6>{{ dir.name }}</h6>
        </div>
        <div class="folder-item" v-for="file in directory.files" v-bind:key="file" @click="getFile(file.url, file.name)">
          <img src="https://img.icons8.com/cotton/2x/file.png" height="50" width="50">
          <h6>{{file.name}}</h6>
        </div>
      </div>
    </q-page>
</template>

<script>
import HttpFactory from '../api/HttpFactory'

export default {
  name: 'Main',
  props: {
    cheminGobal: Object
  },
  components: {
  },
  data () {
    return {
      directory: Object,
      previous: [],
      currentUrl: '',
      url: 'C:\\Repos\\'
    }
  },
  methods: {
    // Chargement de l'arbo
    getFolder (url) {
      const TreeStorage = HttpFactory.get('tree')
      TreeStorage.get(url)
        .then(response => {
          this.currentUrl = url
          this.directory = response.data
        })
    },

    openFolder (url) {
      if (this.currentUrl && this.currentUrl !== '') {
        console.log(url)
        this.previous.push(this.currentUrl)
      }
      this.getFolder(url)
    },

    getFile (url, fileName) {
      console.log('getFile method')
      const TreeStorage = HttpFactory.get('tree')
      TreeStorage.getFile(url, fileName)
        .then(response => {
          console.log(response.data)
        })
    },

    goBack () {
      this.getFolder(this.previous.pop())
    },

    init () {
      this.openFolder(this.url)
    }
  },
  created: function () {
    this.init()
  }
}

</script>

<style>
.folder-item {
  margin: 1em;
  width: 150px;
  overflow:auto;
  display: flex;
  align-items: center;
  flex-direction: column;
}

h6 {
  text-align: center;
  font-size: 1rem;
  margin-top: 1px;
}

.glossy {
  position: fixed;
  top: 20px;
  left: 20px;
}
#container {
  margin: 2em;
}

</style>
