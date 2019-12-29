import {makeStyles} from '@material-ui/core';
import clsx from 'clsx';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
        flexDirection: 'column',
        backgroundColor: theme.palette.common.white,
    },
}));

export interface CoffeeDetailsProps {
    className?: string;
}

const CoffeeDetails: React.FC<CoffeeDetailsProps> = (props) => {
    const {className, ...rest} = props;

    const classes = useStyles();

    return (
        <div
            {...rest}
            className={clsx(classes.root, className)}
        >
            efmekvmwtvmw[rbmrwbmrb[irwmowrm eow
        </div>
    );
};

export default CoffeeDetails;
