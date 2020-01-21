export default class Links {
    public static Home = '/';
    public static Map = '/map';
    public static Drinks = '/drinks';
    public static Companies = '/companies';
    public static Company = (id: number, tab: CompanyTabs) => ({
        href: `/companies/[company]/${tab}`,
        as: `/companies/${id}/${tab}`,
    })
    public static CompaniesPaging = (page: number) => `/companies?page=${page}`;
    public static DrinkItem = (id: number) => `/drinks?id=${id}`;
    public static CafeOverview = (id: number) => ({
        href: '/cafe/[cafe]/overview',
        as: `/cafe/${id}/overview`,
    })
}

export enum CompanyTabs {
    'Overview' = 'overview',
    'Cafes' = 'cafes',
    'Catalog' = 'catalog',
}
