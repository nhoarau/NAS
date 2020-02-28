import Http from "./Http.ts";

const ressource = "account";
const action = "getMethod";
export default {
    get(){
        return Http.get(`${ressource}/${action}`);
    }
}