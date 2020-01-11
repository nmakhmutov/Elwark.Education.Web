import {Bff} from 'api';
import {CompanyModel} from 'api/bff/types';
import {CompanyLayout} from 'layouts';
import {NextPage} from 'next';
import React from 'react';

interface CatalogProps {
    company: CompanyModel;
}

const Catalog: NextPage<CatalogProps> = (props) => {
    const {company} = props;

    return (
        <CompanyLayout title={`Catalog of ${company.name}`} tab={'catalog'} company={company}>
            Catalog
        </CompanyLayout>
    );
};

Catalog.getInitialProps = async ({query}) => {
    const companyId = +query.company;
    const company = await Bff.Company.Get(companyId);

    return {company} as CatalogProps;
};

export default Catalog;
