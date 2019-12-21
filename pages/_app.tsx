import App from "next/app";
import {CssBaseline, ThemeProvider} from "@material-ui/core";
import Head from "next/head";
import * as React from "react";
import theme from "../src/theme";

export default class MyApp extends App {
    componentDidMount() {
        // Remove the server-side injected CSS.
        const jssStyles = document.querySelector('#jss-server-side');
        if (jssStyles) {
            jssStyles.parentElement!.removeChild(jssStyles);
        }
    }

    render() {
        const {Component, pageProps} = this.props;

        return (
            <React.Fragment>
                <Head>
                    <title>My page</title>
                </Head>
                <ThemeProvider theme={theme}>
                    {/* CssBaseline kickstart an elegant, consistent, and simple baseline to build upon. */}
                    <CssBaseline/>
                    <Component {...pageProps} />
                </ThemeProvider>
            </React.Fragment>
        );
    }
}