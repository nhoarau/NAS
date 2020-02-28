import Http from "../http";

const ressource = "account";
export default {
    get(){
        return Http.get(`${ressource}`);
    }
}
