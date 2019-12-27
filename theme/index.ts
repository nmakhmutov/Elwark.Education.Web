import {createMuiTheme} from '@material-ui/core/styles';
import overrides from './overrides';
import palette from './palette';
import typography from './typography';

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
