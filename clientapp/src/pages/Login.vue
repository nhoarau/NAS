<template>
    <div id="login" class="q-gutter-xs column fixed-center">
        <q-input v-model="login" filled type="text" hint="Login">
            <template v-slot:prepend>
                <q-icon name="pets" />
            </template>
        </q-input>
        <q-input v-model="password" filled type="password" hint="Password">
            <template v-slot:prepend>
                <q-icon name="lock" />
            </template>
        </q-input>
        <q-btn color="secondary" label="Enter" @click="connect()"/>
    </div>
</template>

<script>
import HttpFactory from '../api/HttpFactory'

export default {
  name: 'Login',
  methods: {
    // Méthode de connection
    connect () {
      const UserStorage = HttpFactory.post('account')
      UserStorage.post(this.login, this.password)
        .then(response => {
          if (response.data === true) {
            // Utilisation de la variable de connection isAuth qui passa à TRUE si utilisateur existe
            this.$q.sessionStorage.set('isAuth', true)
            this.$isAuth = true
            this.$router.push({ name: 'main' })
          }
        })
    }
  },
  data () {
    return {
      login: '',
      password: ''
    }
  },
  mounted () {
  }
}
</script>

<style>

#login {
    border: 1px solid grey;
    padding: 2em;
    background-color: #f0f0f5;
}

h5{
    text-align: center;
}

</style>
