import {makeStyles} from '@material-ui/styles';
import {CardMedia, Theme, Typography, withStyles} from '@material-ui/core';
import clsx from 'clsx';
import React from 'react';
import Links from 'lib/utils/Links';
import {Link} from 'components';
import {HistoryArticleItem} from 'lib/api/history';
import {amber} from '@material-ui/core/colors';
import moment from 'moment';

const useStyles = makeStyles((theme: Theme) => ({
    root: {
        display: 'flex',
        height: 150,
    },
    content: {
        display: 'flex',
        flexDirection: 'column',
        '& > *': {
            paddingBottom: theme.spacing(1)
        },
        '& > *:last-child': {
            padding: 0
        }
    },
    image: {
        width: 150,
        marginRight: theme.spacing(3)
    },
    center: {
        justifyContent: 'center',
    },
    end: {
        justifyContent: 'flex-end',
    }
}));

const PremiumTypography = withStyles({root: {color: amber.A700}})(Typography);

type Props = {
    className?: string,
    article: HistoryArticleItem
}

const HistoryArticleCard: React.FC<Props> = (props) => {
    const {className, article} = props;

    const classes = useStyles();
    const link = Links.HistoryArticle(article.articleId);

    return (
        <div className={clsx(classes.root, className)}>
            {article.image
                ? <CardMedia className={classes.image} image={article.image} title={article.title}/>
                : <div className={classes.image}/>
            }
            <div className={clsx(classes.content, article.image ? classes.end : classes.center)}>
                {article.type === 'Premium' &&
                <PremiumTypography variant={'subtitle1'}>
                    {article.type}
                </PremiumTypography>
                }
                <Typography component={Link} display={'block'} href={link.href} as={link.as} color={'textPrimary'}
                            variant={'h4'}>
                    {article.title}
                </Typography>
                <Typography variant={'caption'}>
                    {article.passedAt ? 'Article passed ' + moment(article.passedAt).fromNow() : 'Article not passed'}
                </Typography>
            </div>
        </div>
    );
};

export default HistoryArticleCard
