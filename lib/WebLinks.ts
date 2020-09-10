import {HistoryPeriod} from 'lib/api/history';

const WebLinks = {
    Account: 'http://localhost:5003',
    Logout: '/api/logout',

    Home: '/',
    Profile: '/profile',
    Premium: '/premium',

    History: '/history',
    HistoryTopic: (id: string) => ({
        href: `/history/[topic]`,
        as: `/history/${id}`,
    }),
    HistoryArticle: (id: string) => ({
        href: `/history/article/[article]`,
        as: `/history/article/${id}`,
    }),
    HistoryTest: (testId: string) => ({
        href: `/history/test/[test]`,
        as: `/history/test/${testId}`,
    }),
    HistoryPeriod: (period: HistoryPeriod | string) =>
        `/history/${period.toLowerCase()}`,

    Physics: '/physics',
    Astronomy: '/astronomy'
}

export default WebLinks;
