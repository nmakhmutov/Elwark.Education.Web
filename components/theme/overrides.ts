import {colors} from '@material-ui/core';
import {Overrides} from '@material-ui/core/styles/overrides';
import palette from './palette';
import typography from './typography';

const overrides: Overrides = {
    MuiButton: {
        contained: {
            boxShadow:
                '0 1px 1px 0 rgba(0,0,0,0.14), 0 2px 1px -1px rgba(0,0,0,0.12), 0 1px 3px 0 rgba(0,0,0,0.20)',
            backgroundColor: '#FFFFFF',
        },
    },
    MuiCardActions: {
        root: {
            padding: '16px 24px',
        },
    },
    MuiCardContent: {
        root: {
            padding: 24,
        },
    },
    MuiCardHeader: {
        root: {
            padding: '16px 24px',
        },
    },
    MuiChip: {
        root: {
            backgroundColor: colors.blueGrey[50],
            color: colors.blueGrey[900],
        },
        deletable: {
            '&:focus': {
                backgroundColor: colors.blueGrey[100],
            },
        },
    },
    MuiIconButton: {
        root: {
            'color': palette.icon,
            '&:hover': {
                backgroundColor: 'rgba(0, 0, 0, 0.03)',
            },
        },
    },
    MuiInputBase: {
        root: {},
        input: {
            '&::placeholder': {
                opacity: 1,
                color: palette.text?.secondary,
            },
        },
    },
    MuiLinearProgress: {
        root: {
            borderRadius: 3,
            overflow: 'hidden',
        },
        colorPrimary: {
            backgroundColor: colors.blueGrey[50],
        },
    },
    MuiListItemIcon: {
        root: {
            color: palette.icon,
            minWidth: 32,
        },
    },
    MuiOutlinedInput: {
        root: {},
        notchedOutline: {
            borderColor: 'rgba(0,0,0,0.15)',
        },
    },
    MuiPaper: {
        root: {},
        elevation1: {
            boxShadow: '0 0 0 1px rgba(63,63,68,0.05), 0 1px 3px 0 rgba(63,63,68,0.15)',
        },
    },
    MuiTableHead: {
        root: {
            backgroundColor: colors.grey[50],
        },
    },
    MuiTableCell: {
        root: {
            // @ts-ignore
            ...typography.body1,
            borderBottom: `1px solid ${palette.divider}`,
        },
    },
    MuiTableRow: {
        root: {
            '&$selected': {
                backgroundColor: palette.background?.default,
            },
            '&$hover': {
                '&:hover': {
                    backgroundColor: palette.background?.default,
                },
            },
        },
    },
    MuiTypography: {
        gutterBottom: {
            marginBottom: 8,
        },
    },
};

export default overrides;
