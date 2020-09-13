import axios from 'axios';
import {SERVER_BASE_URL} from 'lib/constants';

export interface HistoryTopicItem
{
    topicId: string,
    title: string,
    image: string,
    range: string,
    progress?: {
        count: number,
        passed: number
    }
}

export interface HistoryTopicModel
{
    title: string,
    description: string,
    image: string,
    date: string,
    period: {
        type: string,
        title: string
    },
    articles: HistoryArticleItem[]
}

export type ArticleType = 'regular' | 'premium';

export interface HistoryArticleModel
{
    id: string,
    topic: {
        id: string,
        title: string
    },
    period: {
        type: string,
        title: string
    }
    title: string,
    image?: string,
    type: ArticleType,
    text: string,
    subtitle?: string,
    footnotes?: string,
    isTestAvailable: boolean
}

export interface HistoryArticleItem
{
    topicId: string,
    articleId: string,
    title: string,
    subtitle?: string,
    image?: string,
    type: ArticleType,
    test: {
        isAvailable: true,
        passedAt?: Date
    }
}

export interface HistoryPeriodModel
{
    type: HistoryPeriod,
    title: string,
    description: string,
    image: string,
}

export interface HistoryTestModel
{
    id: string,
    expiredAt: Date,
    questions: HistoryTestQuestionModel[]
}

export interface HistoryTestQuestionModel
{
    id: string,
    title: string,
    isAnswered: boolean,
    type: 'noOptions' | 'singleOption' | 'manyOptions'
    options: string[]
}

export enum HistoryPeriod
{
    'prehistory' = 'prehistory',
    'ancient' = 'ancient',
    'middleAges' = 'middleAges',
    'earlyModern' = 'earlyModern',
    'modern' = 'modern'
}

const HistoryApi = {
    endpoints: {
        getPeriods: 'history/periods',
        getTopics: (period: HistoryPeriod) => `history/topics?period=${period}`,
        getTopic: (topicId: string) => `history/topics/${topicId}`,
        getArticle: (articleId: string) => `history/articles/${articleId}`,
        getRandomArticle: 'history/articles/random',
        createTest: 'history/tests',
        getTest: (testId: string) => `history/tests/${testId}`
    },
    getPeriods: async (token: string) => {
        return await axios.get<HistoryPeriodModel[]>(`${SERVER_BASE_URL}/${HistoryApi.endpoints.getPeriods}`, {
            headers: {
                Authorization: `Bearer ${token}`,
                Language: 'en'
            }
        });
    },
    getTopics: async (period: HistoryPeriod, token: string) => {
        return await axios.get<HistoryTopicItem[]>(`${SERVER_BASE_URL}/${HistoryApi.endpoints.getTopics(period)}`, {
            headers: {
                Authorization: `Bearer ${token}`,
                Language: 'en'
            }
        });
    },
    getTopic: async (topicId: string, token: string) => {
        return await axios.get<HistoryTopicModel>(`${SERVER_BASE_URL}/${HistoryApi.endpoints.getTopic(topicId)}`, {
            headers: {
                Authorization: `Bearer ${token}`,
                Language: 'en'
            }
        });
    },
    getArticle: async (articleId: string, token: string) => {
        return await axios.get<HistoryArticleModel>(`${SERVER_BASE_URL}/${HistoryApi.endpoints.getArticle(articleId)}`, {
            headers: {
                Authorization: `Bearer ${token}`,
                Language: 'en'
            }
        });
    },
    getRandomArticle: async (token: string) => {
        return await axios.get<HistoryArticleItem[]>(`${SERVER_BASE_URL}/${HistoryApi.endpoints.getRandomArticle}`, {
            headers: {
                Authorization: `Bearer ${token}`,
                Language: 'en'
            }
        });
    },
    getTest: async (testId: string, token: string) => {
        return await axios.get<HistoryTestModel>(`${SERVER_BASE_URL}/${HistoryApi.endpoints.getTest(testId)}`, {
            headers: {
                Authorization: `Bearer ${token}`,
                Language: 'en'
            }
        });
    }
};

export default HistoryApi;
