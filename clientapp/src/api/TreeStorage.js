import Http from './Http'

const ressource = 'tree'
const action = 'getTree'

export default {
  get () {
    return Http.get(`${ressource}/${action}`)
  }
}
