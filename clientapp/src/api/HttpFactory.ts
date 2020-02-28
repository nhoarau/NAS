import UserStorage from "./UserStorage.ts"

const repositories = {
    account: UserStorage,
};

export default {
    get: name => repositories[name]
}; 