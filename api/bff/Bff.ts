import fetch from 'isomorphic-unfetch';
import {CompanyModel, CompanyShortModel, CompanyStats} from './types';

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
}
