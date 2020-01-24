export interface EnumerableResponse<T> {
    total: number;
    offset: number;
    limit: number;
    hasNext: boolean;
    items: T[];
}

export interface CompanyModel {
    id: number;
    name: string;
    description: string;
    logotype: CompanyLogotype;
    sites: Record<string, string>;
    contacts: Record<string, string>;
}

export interface CompanyShortModel {
    id: number;
    name: string;
    logotype: CompanyLogotype;
}

export interface CompanyLogotype {
    square: string;
    rectangle: string;
    background: string;
    color: string;
}

export interface CompanyStats {
    id: number;
    total: TotalModel;
    cafes: CafeModel[];
}

export interface RatingModel {
    value: number;
    voters: number;
}

export interface TotalModel {
    countries: number;
    cities: number;
    cafes: number;
    rating: RatingModel;
}

export interface CountryModel {
    code: string;
    name: string;
}

export interface CityModel {
    id: string;
    name: string;
    position: Position;
}

export interface Position {
    latitude: number;
    longitude: number;
}

export interface CafeModel {
    country: CountryModel;
    city: CityModel;
    cafeCount: number;
    rating: RatingModel;
}

export interface CoffeeCategoryModel {
    item: CoffeeCategoryItem;
    children: CoffeeCategoryModel[];
}

export interface CoffeeCategoryItem {
    categoryId: number;
    name: string;
    language: string;
    image?: string;
}

export interface CountryCityModel {
    countryCode: string;
    countryName: string;
    cityId: string;
    cityName: string;
    position: Position;
    image?: string;
}

export interface CoffeeHouseMapPoint {
    cafeId: number;
    cityId: string;
    name: string;
    image?: string;
    address: string;
    position: Position;
    rating: RatingModel;
    company: CompanyShortModel;
}

export interface CompanyCafeItem {
    cafeId: number;
    country: CountryModel;
    city: CityModel;
    name: string;
    image: string;
    address: string;
    rating: RatingModel;
}

export interface CompanyCatalogItem {
    catalogItemId: number;
    categoryId: number;
    image?: string;
    name: string;
}
