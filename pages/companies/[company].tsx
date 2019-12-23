import {NextPage} from "next";
import {MainLayout} from "../../components/layouts/Main";
import {useRouter} from "next/router";

interface CompanyProps {

}

const Company: NextPage<CompanyProps> = (props) => {
    const router = useRouter();
    const {company: id} = router.query;

    return (
        <MainLayout title={`Company: ${id}`}>
            <div>{id}</div>
        </MainLayout>
    )
};

export default Company;