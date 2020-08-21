import {ServerStyleSheets} from '@material-ui/core/styles';
import theme from 'components/theme';
import {StorageApi} from 'lib/clients/storage';
import Document, {Head, Main, NextScript} from 'next/document';
import * as React from 'react';

export default class MyDocument extends Document {
    public render() {
        const primary = StorageApi.Static.Icons.Elwark.Primary;

        return (
            <html>
            <Head>
                <meta charSet="utf-8"/>
                <link rel="stylesheet"
                      href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"/>
                <meta name="theme-color" content={theme.palette.common.white}/>
                <link rel="apple-touch-icon" sizes="57x57" href={primary.Size57x57}/>
                <link rel="apple-touch-icon" sizes="60x60" href={primary.Size60x60}/>
                <link rel="apple-touch-icon" sizes="72x72" href={primary.Size72x72}/>
                <link rel="apple-touch-icon" sizes="76x76" href={primary.Size76x76}/>
                <link rel="apple-touch-icon" sizes="114x114" href={primary.Size114x114}/>
                <link rel="apple-touch-icon" sizes="120x120" href={primary.Size120x120}/>
                <link rel="apple-touch-icon" sizes="144x144" href={primary.Size144x144}/>
                <link rel="apple-touch-icon" sizes="152x152" href={primary.Size152x152}/>
                <link rel="apple-touch-icon" sizes="180x180" href={primary.Size180x180}/>
                <link rel="icon" type="image/png" sizes="192x192" href={primary.Size192x192}/>
                <link rel="icon" type="image/png" sizes="32x32" href={primary.Size32x32}/>
                <link rel="icon" type="image/png" sizes="96x96" href={primary.Size96x96}/>
                <link rel="icon" type="image/png" sizes="16x16" href={primary.Size16x16}/>
                <meta name="msapplication-TileImage" content={primary.Size144x144}/>
                <meta name="msapplication-TileColor" content={theme.palette.common.white}/>
                <link rel="stylesheet" type="text/css" href="/static/styles.css"/>
                <link rel="stylesheet" type="text/css" href="/static/nprogress.css"/>
            </Head>
            <body>
                <Main/>
                <NextScript/>
            </body>
            </html>
        );
    }
}

MyDocument.getInitialProps = async (ctx) => {
    // Render app and page and get the context of the page with collected side effects.
    const sheets = new ServerStyleSheets();
    const originalRenderPage = ctx.renderPage;

    ctx.renderPage = () =>
        originalRenderPage({
            enhanceApp: (App) => (props) => sheets.collect(<App {...props} />),
        });

    const initialProps = await Document.getInitialProps(ctx);

    return {
        ...initialProps,
        // Styles fragment is rendered after the app and page rendering finish.
        styles: [...React.Children.toArray(initialProps.styles), sheets.getStyleElement()],
    };
};
