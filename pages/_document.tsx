import {ServerStyleSheets} from '@material-ui/core/styles';
import Document, {Head, Main, NextScript} from 'next/document';
import * as React from 'react';
import {Storage} from '../api';
import theme from '../theme';

export default class MyDocument extends Document {
    public render() {
        return (
            <html>
            <Head>
                <meta charSet="utf-8"/>
                <meta name="viewport"
                      content="minimum-scale=1, initial-scale=1, width=device-width, shrink-to-fit=no"/>
                <link rel="stylesheet"
                      href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"/>
                <meta name="theme-color" content={theme.palette.common.white}/>
                <link rel="apple-touch-icon" sizes="57x57" href={Storage.Static.Icons.Elwark.Primary.Size57x57}/>
                <link rel="apple-touch-icon" sizes="60x60" href={Storage.Static.Icons.Elwark.Primary.Size60x60}/>
                <link rel="apple-touch-icon" sizes="72x72" href={Storage.Static.Icons.Elwark.Primary.Size72x72}/>
                <link rel="apple-touch-icon" sizes="76x76" href={Storage.Static.Icons.Elwark.Primary.Size76x76}/>
                <link rel="apple-touch-icon" sizes="114x114" href={Storage.Static.Icons.Elwark.Primary.Size114x114}/>
                <link rel="apple-touch-icon" sizes="120x120" href={Storage.Static.Icons.Elwark.Primary.Size120x120}/>
                <link rel="apple-touch-icon" sizes="144x144" href={Storage.Static.Icons.Elwark.Primary.Size144x144}/>
                <link rel="apple-touch-icon" sizes="152x152" href={Storage.Static.Icons.Elwark.Primary.Size152x152}/>
                <link rel="apple-touch-icon" sizes="180x180" href={Storage.Static.Icons.Elwark.Primary.Size180x180}/>
                <link rel="icon" type="image/png" sizes="192x192"
                      href={Storage.Static.Icons.Elwark.Primary.Size192x192}/>
                <link rel="icon" type="image/png" sizes="32x32" href={Storage.Static.Icons.Elwark.Primary.Size32x32}/>
                <link rel="icon" type="image/png" sizes="96x96" href={Storage.Static.Icons.Elwark.Primary.Size96x96}/>
                <link rel="icon" type="image/png" sizes="16x16" href={Storage.Static.Icons.Elwark.Primary.Size16x16}/>
                <meta name="msapplication-TileImage" content={Storage.Static.Icons.Elwark.Primary.Size144x144}/>
                <meta name="msapplication-TileColor" content={theme.palette.common.white}/>
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
    // Resolution order
    //
    // On the server:
    // 1. app.getInitialProps
    // 2. page.getInitialProps
    // 3. document.getInitialProps
    // 4. app.render
    // 5. page.render
    // 6. document.render
    //
    // On the server with error:
    // 1. document.getInitialProps
    // 2. app.render
    // 3. page.render
    // 4. document.render
    //
    // On the client
    // 1. app.getInitialProps
    // 2. page.getInitialProps
    // 3. app.render
    // 4. page.render

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
