import {NextPage} from 'next';
import {useRouter} from 'next/router';
import React, {useEffect, useState} from 'react';
import {Bff} from '../../api';
import {CompanyShortModel} from '../../api/bff/types';
import {DefaultLayout} from '../../layouts';
import CompanyList from './components/CompanyList';

interface CompaniesProps {
    page: number;
    companies: CompanyShortModel[];
}

const limit = 30;

const Index: NextPage<CompaniesProps> = (props) => {
    const [companies, setCompanies] = useState(props.companies);
    const [currentPage, setCurrentPage] = useState(props.page);

    const router = useRouter();

    useEffect(() => {
        void router.push({pathname: router.pathname, query: {page: currentPage}});
    }, [currentPage]);

    const pagingHandler = async (page: number) => {
        setCurrentPage(page);
        setCompanies(await loadCompanies(page));

        window.scrollTo({
            top: 0,
            left: 0,
            behavior: 'smooth',
        });
    };

    return (
        <DefaultLayout title={'Companies'}>
            <CompanyList
                companies={companies}
                onNextClick={async () => await pagingHandler(currentPage + 1)}
                onNextDisabled={companies.length !== limit}
                onPrevClick={async () => await pagingHandler(currentPage - 1)}
                onPrevDisabled={currentPage <= 1}
            />
        </DefaultLayout>
    );
};

Index.getInitialProps = async ({query}) => {
    const page = +(query.page as string) || 1;
    const companies = await loadCompanies(page);

    return {
        page,
        companies,
    } as CompaniesProps;
};

const loadCompanies = async (page: number) => {
    const offset = (page - 1) * limit;

    return await Bff.Company.List(limit, offset);
};

export default Index;
