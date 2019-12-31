import {SimplePaletteColorOptions} from '@material-ui/core';
import {createMuiTheme} from '@material-ui/core/styles';
import overrides from './overrides';
import palette from './palette';
import typography from './typography';

declare module '@material-ui/core/styles/createPalette' {

    interface Palette {
        success: SimplePaletteColorOptions;
        info: SimplePaletteColorOptions;
        warning: SimplePaletteColorOptions;
        icon: string;
    }

    interface PaletteOptions {
        success?: SimplePaletteColorOptions;
        info?: SimplePaletteColorOptions;
        warning?: SimplePaletteColorOptions;
        icon?: string;
    }
}

const theme = createMuiTheme({
    palette,
    typography,
    overrides,
    zIndex: {
        appBar: 100,
        drawer: 110,
    },
});

export default theme;
