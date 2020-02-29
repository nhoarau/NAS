<template>
    <div id="login" class="q-gutter-xs column fixed-center">
        <h5> {{ login }} {{ password }} </h5>
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
        <q-btn color="secondary" label="Enter" @click="redirect()"/>
    </div>
</template>

<script>
import HttpFactory from '../api/HttpFactory'

export default {
  name: 'Login',
  methods: {
    redirect () {
      const UserStorage = HttpFactory.post('account')
      UserStorage.post(this.login, this.password)
        .then(response => {
          if (response.data === true) {
            this.$router.go({ name: 'main' })
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

html{
    /* background: url("~assets/background.jpg") no-repeat center center fixed;
    -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover;
    background-size: cover; */
}

</style>
