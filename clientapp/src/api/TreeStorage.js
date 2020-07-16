import Http from './Http'

const ressource = 'tree'
const action = 'getTree'
const actionFile = 'downloadFile'

export default {
  get (url) {
    return Http.get(`${ressource}/${action}` + '?Path=' + url)
  },
  getFile (url) {
    return Http.get(`${ressource}/${actionFile}` + '?Path=' + url, { headers: { 'Content-Type': 'arraybuffer' } })
  }
}
