import UserStorage from "../api/UserStorage"

const repositories = {
    account: UserStorage,
};

export const HttpFactory = {
    get: name => repositories[name]
}; 