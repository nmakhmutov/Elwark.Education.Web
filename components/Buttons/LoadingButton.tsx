import {Button, ButtonProps, CircularProgress} from '@material-ui/core';
import React from 'react';
import makeStyles from '@material-ui/core/styles/makeStyles';

type Props = {
    isLoading: boolean
}
const useStyles = makeStyles((theme) => ({
    startIcon: {
        display: 'inline-flex',
        verticalAlign: 'middle'
    }
}));

const LoadingButton: React.FC<Props & ButtonProps> = (props) => {
    const {isLoading, startIcon, children, ...rest} = props;
    const classes = useStyles();

    return (
        <Button
            variant={'contained'}
            color={'primary'}
            classes={{startIcon: classes.startIcon}}
            disabled={isLoading}
            startIcon={isLoading ? <CircularProgress size={20} color={'secondary'}/> : startIcon}
            {...rest}
        >
            {children}
        </Button>
    );
};

export default LoadingButton;
