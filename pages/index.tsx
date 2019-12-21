import * as React from "react";
import {Button, Container} from "@material-ui/core";
import {NextPage} from "next";
import Link from 'next/link';
import MainLayout from "../components/MainLayout";

interface Props {
    userAgent: string,
}

const Home: NextPage<Props> = ({userAgent}) => (
    <MainLayout>
        <h1>Hello world! - user agent:</h1>
        <h5>{userAgent}</h5>
        <Link href={'/companies'}>Companies</Link>
    </MainLayout>
);

Home.getInitialProps = async ({req, query}) => {
    const userAgent = req ? req.headers['user-agent'] : navigator.userAgent;
    return {userAgent} as Props;
};

export default Home;