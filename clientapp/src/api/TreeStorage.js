import Http from './Http'

const ressource = 'tree'
const action = 'getTree'
const actionFile = 'downloadFile'

export default {
  get (url) {
    console.log(url)
    return Http.get(`${ressource}/${action}` + '?Path=' + url)
  },
  getFile (url, fileName) {
    console.log('entre bien dans la method a voir')
    return Http.get(`${ressource}/${actionFile}` + '?Path=' + url + '&FileName=' + fileName)
  }
}
