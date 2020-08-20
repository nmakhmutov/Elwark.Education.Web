export default class Links {
    public static Account = 'http://localhost:5003';
    public static Profile = '/profile';
    public static History = '/history';


    public static Company = (id: number, tab: string) => ({
        href: `/companies/[company]/${tab}`,
        as: `/companies/${id}/${tab}`,
    })
}
