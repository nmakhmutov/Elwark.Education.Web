export default class Links {
    public static Home = '/';
    public static Map = '/map';
    public static Drinks = '/drinks';
    public static Companies = '/companies';
    public static Company = {
        href: '/companies/[company]/[page]',
        as: (id: number, page: 'overview' | 'cafes' | 'catalog' | string) => `/companies/${id}/${page}`,
    };
    public static CompaniesPaging = (page: number) => `/companies?page=${page}`;
    public static DrinkItem = (id: number) => `/drinks?id=${id}`;
}
