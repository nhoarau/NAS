import Http from "../api/Http";

const ressource = "account";
export default {
    get(){
        return Http.get(`${ressource}`);
    }
}