import Http from './Http'

const ressource = 'account'
const action = 'getMethod'
const log = 'login'

export default {
  get () {
    return Http.get(`${ressource}/${action}`)
  },
  post (email, password) {
    const user = {
      email: email,
      password: password
    }
    const userJson = JSON.stringify(user)
    console.log(userJson)
    return Http.post(`${ressource}/${log}`, userJson, {
      headers: {
        'content-type': 'application/json'
      }
    })
  }
}
