export default class Links {
    public static Home = '/';
    public static Map = '/map';
    public static Coffee = '/coffee';
    public static Companies = '/companies';
    public static Company = {
        href: '/companies/[company]/[page]',
        as: (id: number, page: 'overview' | 'cafes' | 'catalog' | string) => `/companies/${id}/${page}`,
    };
    public static CoffeeItem = (id: number) => `/coffee?id=${id}`;
}
