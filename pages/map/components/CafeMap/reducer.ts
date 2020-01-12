import {CoffeeHouseMapPoint, CountryCityModel} from 'api/bff/types';

enum Types {
    filterRequest,
    filterSuccess,
    filterFailure,

    markersRequest,
    markersSuccess,
    markersFailure,

    changeCity,
}

type Action =
    | { type: Types.filterRequest }
    | { type: Types.filterSuccess, result: CountryCityModel[] }
    | { type: Types.filterFailure, error: string }

    | { type: Types.markersRequest }
    | { type: Types.markersSuccess, result: CoffeeHouseMapPoint[] }
    | { type: Types.markersFailure, error: string }

    | { type: Types.changeCity, result: { lat: number, lng: number, cityId: string, zoom: number } };

export const filterRequest = (): Action => ({type: Types.filterRequest});
export const filterSuccess = (result: CountryCityModel[]): Action => ({type: Types.filterSuccess, result});
export const filterFailure = (error: string): Action => ({type: Types.filterFailure, error});

export const markersRequest = (): Action => ({type: Types.markersRequest});
export const markersSuccess = (result: CoffeeHouseMapPoint[]): Action => ({type: Types.markersSuccess, result});
export const markersFailure = (error: string): Action => ({type: Types.markersFailure, error});

export const changeCity = (cityId: string, lat: number, lng: number, zoom: number): Action => ({
    type: Types.changeCity, result: {cityId, lat, lng, zoom},
});

export interface State {
    lat: number;
    lng: number;
    zoom: number;
    cityId: string;
    filter: {
        loading: boolean,
        data: CountryCityModel[],
        error?: any,
    };
    markers: {
        loading: boolean,
        data: CoffeeHouseMapPoint[],
        error?: any,
    };
}

const storageKey = 'e1980037f03a43968f9591d745164ac1';

export const initialState: State = {
    cityId: localStorage.getItem(storageKey) || '',
    lat: 0,
    lng: 0,
    zoom: 3,
    markers: {
        loading: false,
        data: [],
    },
    filter: {
        loading: false,
        data: [],
    },
};

export const cafeMapReducer = (state: State, action: Action): State => {
    switch (action.type) {
        case Types.filterRequest:
            return {...state, filter: {...state.filter, loading: true}};

        case Types.filterSuccess:
            return {...state, filter: {...state.filter, data: action.result, error: undefined, loading: false}};

        case Types.filterFailure:
            return {...state, filter: {...state.filter, data: [], error: action.error, loading: false}};

        case Types.markersRequest:
            return {...state, markers: {...state.markers, loading: true}};

        case Types.markersSuccess:
            return {...state, markers: {...state.markers, data: action.result, error: undefined, loading: false}};

        case Types.markersFailure:
            return {...state, markers: {...state.markers, data: [], error: action.error, loading: false}};

        case Types.changeCity:
            const {cityId, lat, lng, zoom} = action.result;
            localStorage.setItem(storageKey, cityId);
            return {...state, cityId, lat, lng, zoom};

        default:
            return state;
    }
};
