import {HistoryPeriod} from 'lib/api/history';

export default class Links {
    public static Account = 'http://localhost:5003';
    public static Logout = '/api/logout';

    public static Home = '/';
    public static Profile = '/profile';
    public static Premium = '/premium';
    public static History = '/history';
    public static HistoryTopic = (id: string) => ({
        href: `/history/[id]`,
        as: `/history/${id}`,
    });
    public static HistoryArticle = (id: string) => ({
        href: `/history/article/[id]`,
        as: `/history/article/${id}`,
    });
    public static HistoryTest = (articleId: string) => ({
        href: `/history/test/[id]`,
        as: `/history/test/${articleId}`,
    });
    public static HistoryPeriod = (period: HistoryPeriod | string) =>
        `/history/${period.toLowerCase()}`;

    public static Physics = '/physics';
}
