import {createMuiTheme} from '@material-ui/core/styles';
import overrides from './overrides';
import palette from './palette';
import typography from './typography';

declare module '@material-ui/core/styles/createPalette' {

    interface Palette {
        icon: string;
    }

    interface PaletteOptions {
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
