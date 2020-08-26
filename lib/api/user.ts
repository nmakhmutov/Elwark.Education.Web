import axios from 'axios';
import {SERVER_BASE_URL} from 'lib/utils/constants';

const SERVER_USERS_URL = `${SERVER_BASE_URL}/users`;
const UserApi = {
    get: async (token: string) => {
        return await axios.get(SERVER_USERS_URL,{
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    },
    register: async (token: string) => {
        return await axios.post(SERVER_USERS_URL,null,{
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    }
}

export default UserApi;
