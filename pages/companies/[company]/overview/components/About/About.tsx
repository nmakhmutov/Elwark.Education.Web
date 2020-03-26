import {Card, CardContent, makeStyles} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import ReactMarkdown from 'react-markdown';

const useStyles = makeStyles((theme) => ({
    root: {},
}));

export interface AboutProps {
    className?: string;
    about: string;
}

const About: React.FC<AboutProps> = (props) => {
    const {className, about} = props;
    const classes = useStyles();

    return (
        <Card className={clsx(classes.root, className)}>
            <CardContent>
                <ReactMarkdown source={about}/>
            </CardContent>
        </Card>
    );
};

export default About;
