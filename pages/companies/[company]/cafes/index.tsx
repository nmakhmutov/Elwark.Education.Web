import {Bff} from 'api';
import {CompanyModel} from 'api/bff/types';
import {CompanyLayout} from 'layouts';
import {NextPage} from 'next';
import React from 'react';

interface CafeProps {
    company: CompanyModel;
}

const Cafes: NextPage<CafeProps> = (props) => {
    const {company} = props;
    return (
        <CompanyLayout title={`Cafes of ${company.name}`} tab={'cafes'} company={company}>
            Cafes
        </CompanyLayout>
    );
};

Cafes.getInitialProps = async ({query}) => {
    const companyId = +query.company;
    const company = await Bff.Company.Get(companyId);

    return {company} as CafeProps;
};

export default Cafes;
