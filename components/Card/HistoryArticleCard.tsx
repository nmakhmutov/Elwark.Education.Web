import {makeStyles} from '@material-ui/styles';
import {Avatar, Card, CardHeader, Theme} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import {Link} from "components";
import Links from "lib/utils/Links";

const useStyles = makeStyles((theme: Theme) => ({
    root: {},
    header: {
        paddingBottom: 0
    },
    subheader: {
        flexWrap: 'wrap',
        display: 'flex',
        alignItems: 'center'
    },
    content: {
        padding: 0,
        '&:last-child': {
            paddingBottom: 0
        }
    },
    message: {
        padding: theme.spacing(2, 3)
    },
    details: {
        padding: theme.spacing(1, 3)
    }
}));

interface HistoryArticle {
    topicId: string,
    articleId: string,
    title: string,
    image?: string
}

type Props = {
    className?: string,
    article: HistoryArticle
}

const HistoryArticleCard: React.FC<Props> = (props) => {
    const {className, article} = props;

    const classes = useStyles();
    const link = Links.HistoryArticle(article.articleId);

    return (
        <Card className={clsx(classes.root, className)}>
            <CardHeader avatar={
                <Avatar alt="Reviewer" src={article.image}>
                    {article.title}
                </Avatar>
            }
                        className={classes.header}
                        disableTypography
                        title={
                            <Link
                                color="textPrimary"
                                href={link.href}
                                as={link.as}
                                variant="h5"
                            >
                                {article.title}
                            </Link>
                        }
            />
            {/*<CardContent className={classes.content}>*/}
            {/*    <div className={classes.message}>*/}
            {/*        <Typography variant="subtitle2">{review.message}</Typography>*/}
            {/*    </div>*/}
            {/*    <Divider/>*/}
            {/*    <div className={classes.details}>*/}
            {/*        <Grid*/}
            {/*            alignItems="center"*/}
            {/*            container*/}
            {/*            justify="space-between"*/}
            {/*            spacing={3}*/}
            {/*        >*/}
            {/*            <Grid item>*/}
            {/*                <Typography variant="h5">*/}
            {/*                    {review.currency}*/}
            {/*                    {review.project.price}*/}
            {/*                </Typography>*/}
            {/*                <Typography variant="body2">Project price</Typography>*/}
            {/*            </Grid>*/}
            {/*            <Grid item>*/}
            {/*                <Typography variant="h5">*/}
            {/*                    {review.currency}*/}
            {/*                    {review.pricePerHour}*/}
            {/*                </Typography>*/}
            {/*                <Typography variant="body2">Per project</Typography>*/}
            {/*            </Grid>*/}
            {/*            <Grid item>*/}
            {/*                <Typography variant="h5">{review.hours}</Typography>*/}
            {/*                <Typography variant="body2">Hours</Typography>*/}
            {/*            </Grid>*/}
            {/*        </Grid>*/}
            {/*    </div>*/}
            {/*</CardContent>*/}
        </Card>
    );
};

export default HistoryArticleCard
