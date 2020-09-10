import axios from 'axios';
import {SERVER_BASE_URL} from 'lib/constants';

const UserApi = {
    endpoints: {
        get: 'users'
    },
    get: async (token: string) => {
        return await axios.get(`${SERVER_BASE_URL}/${UserApi.endpoints.get}`,{
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    },
    register: async (token: string) => {
        return await axios.post(`${SERVER_BASE_URL}/${UserApi.endpoints.get}`,null,{
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    }
}

export default UserApi;
