import UserStorage from './UserStorage'

const repositories = {
  account: UserStorage
}

export default {
  get: name => repositories[name],
  post: name => repositories[name]
}
