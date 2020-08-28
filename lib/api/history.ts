import axios from 'axios';
import {SERVER_BASE_URL} from 'lib/utils/constants';

const SERVER_HISTORY_URL = `${SERVER_BASE_URL}/history`;

export interface TopicItem {
    topicId: string,
    title: string,
    image: string,
    range: string,
    progress: {
        count: number,
        passed: number
    }
}

export interface TopicModel {
    title: string,
    description: string,
    image: string,
    date: string,
    articles: ArticleItem[]
}

export interface ArticleItem {
    topicId: string,
    articleId: string,
    title: string,
    image?: string,
    type: 'Regular' | 'Premium'
}

const HistoryApi = {
    getAll: async (token: string) => {
        return await axios.get<TopicItem[]>(SERVER_HISTORY_URL, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    },
    getTopic: async (topicId: string, token: string) => {
        return await axios.get<TopicModel>(`${SERVER_HISTORY_URL}/${topicId}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    }
}

export default HistoryApi;
