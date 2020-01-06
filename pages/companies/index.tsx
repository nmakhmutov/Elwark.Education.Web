import {Bff} from 'api';
import {CompanyShortModel} from 'api/bff/types';
import {DefaultLayout} from 'layouts';
import {NextPage} from 'next';
import {useRouter} from 'next/router';
import React, {useEffect, useState} from 'react';
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

    const pagingHandler = async (container: HTMLDivElement, page: number) => {
        container.style.opacity = '0.5';
        setCurrentPage(page);
        setCompanies(await loadCompanies(page));
        container.scrollIntoView({behavior: 'smooth'});
        container.style.opacity = null;
    };

    return (
        <DefaultLayout title={'Companies'}>
            <CompanyList
                companies={companies}
                onNextClick={async (container) => await pagingHandler(container.current!, currentPage + 1)}
                onNextDisabled={companies.length !== limit}
                onPrevClick={async (container) => await pagingHandler(container.current!, currentPage - 1)}
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
