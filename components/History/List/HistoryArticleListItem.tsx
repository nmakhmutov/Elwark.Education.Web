import {makeStyles} from '@material-ui/styles';
import {CardMedia, Link as UiLink, Theme, Typography, withStyles} from '@material-ui/core';
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
    onPremiumPopup?: () => void
    article: HistoryArticleItem
}

const HistoryArticleListItem: React.FC<Props> = (props) => {
        const {className, article, onPremiumPopup} = props;

        const classes = useStyles();
        const link = Links.HistoryArticle(article.articleId);

        const title = () => {
            if (article.type === 'Premium' && onPremiumPopup) {
                const onClick = (event: MouseEvent) => {
                    event.preventDefault();
                    onPremiumPopup();
                };

                return (
                    <Typography
                        component={UiLink}
                        display={'block'}
                        color={'textPrimary'}
                        variant={'h4'}
                        href={'#'}
                        onClick={onClick}>
                        {article.title}
                    </Typography>
                )
            }

            return (
                <Typography component={Link} display={'block'} href={link.href} as={link.as} color={'textPrimary'}
                            variant={'h4'}>
                    {article.title}
                </Typography>
            )
        }

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
                    {title()}
                    <Typography variant={'subtitle2'}>
                        {article.subtitle}
                    </Typography>
                    <Typography variant={'caption'}>
                        {article.passedAt ? 'Test passed ' + moment(article.passedAt).fromNow() : 'Test not passed'}
                    </Typography>
                </div>
            </div>
        );
    }
;

export default HistoryArticleListItem
