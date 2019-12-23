import {NextPage} from "next";
import MainLayout from "../layouts/Main";
import React from "react";
import fetch from 'isomorphic-unfetch'
import CompanyList from "../views/CompanyList";
import {CompanyShortModel} from "../interfaces";

interface CompaniesProps {
    companies: CompanyShortModel[]
};

const Companies: NextPage<CompaniesProps> = (props) => {
    const {companies} = props;

    return (
        <MainLayout title={'Companies'}>
            <CompanyList companies={companies}/>
        </MainLayout>
    )
};

Companies.getInitialProps = async () => {
    const res = await fetch('http://localhost:5199/companies?limit=20');
    const companies = await res.json();

    return {companies: companies} as CompaniesProps;
};

export default Companies