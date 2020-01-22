import fetch from 'isomorphic-unfetch';
import {
    CoffeeHouseMapPoint,
    CompanyCafeItem,
    CompanyCatalogItem,
    CompanyModel,
    CompanyShortModel,
    CompanyStats,
    CountryCityModel
} from './types';

const host = process.env.BFF_HOST || 'http://localhost:5199';

/* tslint:disable:max-classes-per-file */
export default class Bff {
    public static Company = class {
        public static async List(limit: number, offset: number) {
            const res = await fetch(`${host}/companies?offset=${offset}&limit=${limit}`);
            const companies = await res.json();

            return companies as CompanyShortModel[];
        }

        public static async Get(id: number) {
            const res = await fetch(`${host}/companies/${id}`);
            const company = await res.json();

            return company as CompanyModel;
        }

        public static async Statistics(id: number) {
            const res = await fetch(`${host}/companies/${id}/statistics`);
            const stats = await res.json();

            return stats as CompanyStats;
        }

        public static async Cafes(id: number, limit: number, offset: number) {
            const res = await fetch(`${host}/companies/${id}/cafes?offset=${offset}&limit=${limit}`);
            const cafes = await res.json();

            return cafes as CompanyCafeItem[];
        }

        public static async Catalog(id: number) {
            const res = await fetch(`${host}/companies/${id}/catalog`);
            const catalog = await res.json();

            return catalog as CompanyCatalogItem[];
        }
    };

    public static Cities = class {
        public static async List() {
            const res = await fetch(`${host}/cities`);
            const cities = await res.json();

            return cities as CountryCityModel[];
        }

        public static async Cafes(id: string) {
            const res = await fetch(`${host}/cities/${id}/cafes`);
            const cafes = await res.json();

            return cafes as CoffeeHouseMapPoint[];
        }
    };

    public static Categories = class {
        public static async List() {
            const res = await fetch(`${host}/categories`);
            const categories = await res.json();

            return categories;
        }
    };
}
