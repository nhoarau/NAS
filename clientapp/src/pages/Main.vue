<template>
    <q-page padding>
      <q-btn color="secondary" label="Enter" @click="redirect()"/>
      <SideBar :tree="this.chemin" ></SideBar>
    </q-page>
</template>

<script>
import HttpFactory from '../api/HttpFactory'
import SideBar from '../components/SideBar'

export default {
  name: 'Main',
  props: {
    cheminGobal: Object
  },
  components: {
    SideBar
  },
  data () {
    return {
      visible: true,
      simple: []
    }
  },
  methods: {
    // Chargement de l'arbo
    // TODO: prévoir un chargement auto au chargement de la page pour l'instant je gade le bouton
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
