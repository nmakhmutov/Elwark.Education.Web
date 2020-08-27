import axios from 'axios';
import {SERVER_BASE_URL} from 'lib/utils/constants';

const SERVER_HISTORY_URL = `${SERVER_BASE_URL}/history`;
const HistoryApi = {
    getAll: async (token: string) => {
        return await axios.get(SERVER_HISTORY_URL, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    },
    getTopic: async (topicId: string, token: string) => {
        return await axios.get(`${SERVER_HISTORY_URL}/${topicId}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    }
}

export default HistoryApi;
