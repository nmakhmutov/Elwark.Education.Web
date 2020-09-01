import React from 'react';
import {Grid, Theme} from '@material-ui/core';
import HistoryTopicCard from 'components/History/Card/HistoryTopicCard';
import {HistoryTopicItem} from 'lib/api/history';
import {makeStyles} from '@material-ui/styles';
import clsx from 'clsx';

const useStyles = makeStyles((theme: Theme) => ({
    root: {}
}));

type Props = {
    className?: string;
    topics: HistoryTopicItem[]
}

const HistoryTopicGrid: React.FC<Props> = (props) => {
    const classes = useStyles();
    const {topics, className} = props;

    let i = 0;
    const get = () => {
        if (i >= 8)
            i = 0;

        i++;

        if (i === 3 || i === 4 || i === 5)
            return 4;

        if (i === 8)
            return 12;

        return 5;
    }

    return (
        <div className={clsx(classes.root, className)}>
            <Grid container={true} spacing={3} justify={'center'}>
                {topics.map((topic) =>
                    <Grid key={topic.topicId} item={true} xs={12} sm={6} md={get()}>
                        <HistoryTopicCard topic={topic}/>
                    </Grid>
                )}
            </Grid>
        </div>
    );
}

export default HistoryTopicGrid;
