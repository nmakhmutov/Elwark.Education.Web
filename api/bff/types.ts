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
    cafeCount: number;
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
    id: number;
    name: string;
    image?: string;
    description?: string;
}

export interface CountryCityModel {
    countryCode: string;
    countryName: string;
    cityId: string;
    cityName: string;
    position: Position;
    image?: string;
}
