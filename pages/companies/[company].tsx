import {NextPage} from 'next';
import {useRouter} from 'next/router';
import {MainLayout} from '../../components/layouts/Main';

// tslint:disable-next-line:no-empty-interface
interface CompanyProps {

}

const Company: NextPage<CompanyProps> = (props) => {
    const router = useRouter();
    const {company: id} = router.query;

    return (
        <MainLayout title={`Company: ${id}`}>
            <div>{id}</div>
        </MainLayout>
    );
};

export default Company;
