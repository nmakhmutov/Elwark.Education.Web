import {CssBaseline, ThemeProvider} from '@material-ui/core';
import App from 'next/app';
import Router from 'next/router';
import NProgress from 'nprogress';
import * as React from 'react';
import theme from '../theme';

Router.events.on('routeChangeStart', () => NProgress.start());
Router.events.on('routeChangeComplete', () => NProgress.done());
Router.events.on('routeChangeError', () => NProgress.done());

export default class MyApp extends App {
    public componentDidMount() {
        // Remove the server-side injected CSS.
        const jssStyles = document.querySelector('#jss-server-side');
        if (jssStyles) {
            jssStyles.parentElement!.removeChild(jssStyles);
        }
    }

    public render() {
        const {Component, pageProps} = this.props;

        return (
            <>
                <ThemeProvider theme={theme}>
                    {/* CssBaseline kickstart an elegant, consistent, and simple baseline to build upon. */}
                    <CssBaseline/>
                    <Component {...pageProps} />
                </ThemeProvider>
            </>
        );
    }
}
