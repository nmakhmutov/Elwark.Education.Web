import makeStyles from '@material-ui/core/styles/makeStyles';
import clsx from 'clsx';
import React from 'react';
import {SearchInput} from '../../../../../../components';

const useStyles = makeStyles((theme) => ({
    root: {},
    row: {
        height: '42px',
        display: 'flex',
        alignItems: 'center',
        marginTop: theme.spacing(1),
    },
    spacer: {
        flexGrow: 1,
    },
    importButton: {
        marginRight: theme.spacing(1),
    },
    exportButton: {
        marginRight: theme.spacing(1),
    },
    searchInput: {
        marginRight: theme.spacing(1),
    },
}));

export interface CompanyToolbarProps {
    className?: string;
}

const CompanyToolbar: React.FC<CompanyToolbarProps> = (props) => {
    const {className, ...rest} = props;

    const classes = useStyles();

    return (
        <div
            {...rest}
            className={clsx(classes.root, className)}>
            <div className={classes.row}>
                <SearchInput
                    className={classes.searchInput}
                    placeholder="Search coffee company"
                />
            </div>
        </div>
    );
};

export default CompanyToolbar;
