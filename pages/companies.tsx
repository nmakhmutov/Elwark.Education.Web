import {NextPage} from "next";
import Link from "next/link";
import MainLayout from "../src/layouts/Main";

const Companies: NextPage = () => (
    <MainLayout title={'Companies'}>
        <div>Companies</div>
        <Link href={'/'}>Index</Link>
    </MainLayout>
)

export default Companies