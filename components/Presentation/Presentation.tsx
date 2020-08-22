import makeStyles from '@material-ui/core/styles/makeStyles';
import Head from 'next/head';
import React from 'react';
import Header from './components/Header';

const useStyles = makeStyles(() => ({
    root: {}
}));

const Presentation: React.FC = (props) => {
    const classes = useStyles();

    return (
        <div className={classes.root}>
            <Head>
                <title>Elwark Education</title>
            </Head>
            <Header/>
        </div>
    );
};

export default Presentation;
