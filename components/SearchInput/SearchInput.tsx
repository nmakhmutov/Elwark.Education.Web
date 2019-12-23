import Input from '@material-ui/core/Input';
import {InputProps} from '@material-ui/core/Input/Input';
import Paper from '@material-ui/core/Paper';
import {PaperProps} from '@material-ui/core/Paper/Paper';
import makeStyles from '@material-ui/core/styles/makeStyles';
import SearchIcon from '@material-ui/icons/Search';
import clsx from 'clsx';
import React from 'react';

const useStyles = makeStyles((theme) => ({
    root: {
        borderRadius: '4px',
        alignItems: 'center',
        padding: theme.spacing(1),
        display: 'flex',
        flexBasis: 420,
    },
    icon: {
        marginRight: theme.spacing(1),
        color: theme.palette.text.secondary,
    },
    input: {
        flexGrow: 1,
        fontSize: '14px',
        lineHeight: '16px',
        letterSpacing: '-0.05px',
    },
}));

export interface SearchInputProperties {
    className?: string;
    onChange?: () => void;
    style?: object;
}

export type SearchInputProps = SearchInputProperties & InputProps & PaperProps;

const SearchInput: React.FC<SearchInputProps> = (props) => {
    const {className, onChange, style, ...rest} = props;

    const classes = useStyles();

    return (
        <Paper
            {...rest}
            className={clsx(classes.root, className)}
            style={style}
        >
            <SearchIcon className={classes.icon}/>
            <Input
                {...rest}
                className={classes.input}
                disableUnderline
                onChange={onChange}
            />
        </Paper>
    );
};

export default SearchInput;
