import fetch from 'isomorphic-unfetch';
import {GeoJSON} from 'leaflet';
import {CompanyModel, CompanyShortModel, CompanyStats, CountryCityModel} from './types';

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

            return cafes as GeoJSON.FeatureCollection;
        }
    };
}
