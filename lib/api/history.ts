import axios from 'axios';
import {SERVER_BASE_URL} from 'lib/utils/constants';

const SERVER_HISTORY_URL = `${SERVER_BASE_URL}/history`;

export interface HistoryTopicItem {
    topicId: string,
    title: string,
    image: string,
    range: string,
    progress: {
        count: number,
        passed: number
    }
}

export interface HistoryTopicModel {
    title: string,
    description: string,
    image: string,
    date: string,
    articles: HistoryArticleItem[]
}

export interface HistoryArticleModel {
    topicId: string,
    articleId: string,
    title: string,
    image?: string,
    type: 'Regular' | 'Premium',
    text: string,
    subtitle?: string,
    footnotes?: string,
    footer?: string
}

export interface HistoryArticleItem {
    topicId: string,
    articleId: string,
    title: string,
    image?: string,
    type: 'Regular' | 'Premium',
    passedAt: Date
}

const HistoryApi = {
    getAll: async (token: string) => {
        return await axios.get<HistoryTopicItem[]>(SERVER_HISTORY_URL, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    },
    getTopic: async (topicId: string, token: string) => {
        return await axios.get<HistoryTopicModel>(`${SERVER_HISTORY_URL}/${topicId}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    },
    getArticle: async (articleId: string, token: string) => {
        return await axios.get<HistoryArticleModel>(`${SERVER_HISTORY_URL}/articles/${articleId}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
    }
}

export default HistoryApi;
