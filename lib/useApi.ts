import axios, {Method} from 'axios';

const useApi = <T>(method: Method, endpoint: string, data?: any) => {
    return axios.request<T>({
        method,
        url: '/api/call',
        headers: {
            endpoint
        },
        data
    });
};

export default useApi;
