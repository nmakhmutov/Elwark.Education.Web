import {AppBar, Tab, Tabs} from '@material-ui/core';
import React from 'react';
import {HistoryPeriod} from 'lib/api/history';
import {useRouter} from 'next/router';
import Links from 'lib/utils/Links';
import Link from "components/Link";

type Props = {
    className?: string,
    selected: HistoryPeriod
}
const HistoryPeriodTabs: React.FC<Props> = (props) => {
    const {className, selected} = props;
    const [width, setWidth] = React.useState(0);

    React.useEffect(() => {
        const handleResize = () => setWidth(window.innerWidth);

        window.addEventListener('resize', handleResize);

        handleResize();

        return () => window.removeEventListener('resize', handleResize);
    }, []);

    const router = useRouter();
    const handleChange = (event: React.ChangeEvent<{}>, newValue: HistoryPeriod) => {
        return router.push(Links.HistoryPeriod(newValue))
    }

    return (
        <AppBar className={className} position={'static'} color={'inherit'}>
            <Tabs
                value={selected}
                onChange={handleChange}
                indicatorColor={'primary'}
                textColor={'primary'}
                variant={width > 780 ? 'fullWidth' : 'scrollable'}
                scrollButtons={'on'}
            >
                <Tab label="Prehistory" value={HistoryPeriod.Prehistory}/>
                <Tab label="Ancient" value={HistoryPeriod.Ancient}/>
                <Tab label="Middle ages" value={HistoryPeriod.MiddleAges}/>
                <Tab label="Modern" value={HistoryPeriod.Modern}/>
                <Tab label="Contemporary" value={HistoryPeriod.Contemporary}/>
            </Tabs>
        </AppBar>
    )
}

export default HistoryPeriodTabs;
