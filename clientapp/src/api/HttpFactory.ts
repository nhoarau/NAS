import UserStorage from "./ressources/userStorage"

const repositories = {
    account: UserStorage,
};

export const HttpFactory = {
    get: name => repositories[name]
};