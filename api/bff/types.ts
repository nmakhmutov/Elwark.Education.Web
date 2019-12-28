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
    total: Total;
    cafes: Cafe[];
}

export interface Rating {
    value: number;
    voters: number;
}

export interface Total {
    cafeCount: number;
    rating: Rating;
}

export interface Country {
    code: string;
    name: string;
}

export interface City {
    id: string;
    name: string;
    position: Position;
}

export interface Position {
    latitude: number;
    longitude: number;
}

export interface Cafe {
    country: Country;
    city: City;
    cafeCount: number;
    rating: Rating;
}
