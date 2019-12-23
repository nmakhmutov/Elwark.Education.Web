import {NextPage} from "next";
import React, {useEffect, useState} from "react";
import fetch from 'isomorphic-unfetch'
import CompanyList from "../../components/CompanyList";
import {CompanyShortModel} from "../../interfaces";
import {useRouter} from "next/router";
import {MainLayout} from "../../components/layouts/Main";

interface CompaniesProps {
    companies: CompanyShortModel[]
}

const Index: NextPage<CompaniesProps> = (props) => {
    const {companies} = props;
    const data = useState(companies);
    const router = useRouter();

    // useEffect(() => {
    //     void router.push({pathname: router.pathname, query: {page: 1}});
    // }, []);

    return (
        <MainLayout title={'Companies'}>
            <CompanyList companies={companies}/>
        </MainLayout>
    )
};

Index.getInitialProps = async () => {
    const res = await fetch('http://localhost:5199/companies?limit=20');
    const companies = await res.json();

    return {companies: companies} as CompaniesProps;
};

export default Index