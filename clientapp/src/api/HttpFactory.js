import UserStorage from './UserStorage'
import TreeStorage from './TreeStorage'

const repositories = {
  account: UserStorage,
  tree: TreeStorage
}

export default {
  get: name => repositories[name],
  post: name => repositories[name]
}
