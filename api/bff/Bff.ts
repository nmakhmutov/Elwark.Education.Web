import fetch from 'isomorphic-unfetch';
import {CompanyShortModel} from '../../interfaces';

export default class Bff {
    public static async GetCompanies(limit: number, offset: number) {
        const res = await fetch(`${Bff.host}/companies?offset=${offset}&limit=${limit}`);
        const companies = await res.json();

        return companies as CompanyShortModel[];
    }

    private static host = 'http://localhost:5199';
}
