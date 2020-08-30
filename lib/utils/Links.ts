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
    public static Physics = '/physics';
}
