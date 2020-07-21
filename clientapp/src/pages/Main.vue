<template>
    <q-page id="container" padding>
      <q-btn class="glossy" round color="primary" @click="goBack()" icon="fas fa-chevron-left" :disabled="previous.length == 0"/>
      <div class="upload">
      <q-file
        style="max-width: 300px"
        filled
        label="Select a file to upload"
        v-model= file
        multiple
      />
      <q-btn color="white" @click="Images_onUpload()"><img src="https://img.icons8.com/cotton/100/000000/upload.png" height="40" width="40"/></q-btn>
      </div>
      <h3>{{directory.name}}</h3>
      <div style="display: flex; flex-wrap: wrap;">
        <div class="folder-item"  v-for="(dir, id) in directory.subDirectories" :key="id" @click="openFolder(dir.url)">
          <img src="https://img.icons8.com/cotton/64/000000/folder-invoices--v1.png" height="50" width="50">
          <h6>{{ dir.name }}</h6>
        </div>
        <div class="folder-item" v-for="(file, idf) in directory.files" :key="'A'+idf" @click="getFile(file.url, file.name)">
          <img src="https://img.icons8.com/cotton/2x/file.png" height="50" width="50">
          <h6>{{file.name}}</h6>
        </div>
      </div>
    </q-page>
</template>

<script>
import HttpFactory from '../api/HttpFactory'
import axios from 'axios'

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
      url: 'C:\\Repos\\',
      file: null
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

    Images_onUpload () {
      // const mypostparameters = new FormData()
      // mypostparameters.append('fileUpload', this.selectedFile, this.selectedFile.name)
      // axios.post('http://localhost:50598/tree/uploadFile',
      //   mypostparameters).then(res => {
      //   console.log(res)
      // })// the data to post
      var formData = new FormData()
      // var imagefile = document.querySelector('#file')
      formData.append('file', this.file[0])
      axios.post('http://localhost:50598/tree/uploadFile', formData, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      })
    },

    getFile (url, fileName) {
      // voir pour optimiser à l'avenir et utiliser le treeStorage

      // const TreeStorage = HttpFactory.get('tree')
      // TreeStorage.getFile(url)
      //   .then(res => {
      //     // const blob = new Blob([res.data], { type: res.data.type })
      //     // const url = window.URL.createObjectURL(blob)
      //     // const link = document.createElement('a')
      //     // link.href = url
      //     // link.setAttribute('download', fileName)
      //     // document.body.appendChild(link)
      //     // link.click()
      //     // link.remove()
      //     // window.URL.revokeObjectURL(url)
      //     var fileUrl = window.URL.createObjectURL(new Blob([res.data]))
      //     var fileLink = document.createElement('a')
      //     fileLink.href = fileUrl
      //     fileLink.setAttribute('download', fileName)
      //     document.body.appendChild(fileLink)
      //     fileLink.target = '_blank'
      //     fileLink.click()
      //   })
      axios({
        url: 'http://localhost:50598/tree/downloadFile?Path=' + url,
        method: 'GET',
        responseType: 'blob'// important
      }).then((response) => {
        const url = window.URL.createObjectURL(new Blob([response.data]))
        const link = document.createElement('a')
        link.href = url
        link.setAttribute('download', fileName)
        link.target = '_blank'
        link.click()
      })
    },

    // uploadFile () {
    //   const TreeStorage = HttpFactory.get('tree')
    //   TreeStorage.uploadFile(this.selectedFile)
    //     .then(response => {
    //     })
    // },

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

.upload {
  display: flex;
  flex-direction: row-reverse;

}

</style>
