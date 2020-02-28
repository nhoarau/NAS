import axios from 'axios'

const baseDomain = "http://localhost:50598";
const baseURL = `${baseDomain}/`;

export default axios.create({
    baseURL
})


