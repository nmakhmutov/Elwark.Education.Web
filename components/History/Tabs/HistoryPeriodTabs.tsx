import {AppBar, Tab, Tabs} from '@material-ui/core';
import React from 'react';
import {HistoryPeriod, HistoryPeriodModel} from 'lib/api/history';
import {useRouter} from 'next/router';
import Links from 'lib/utils/Links';

type Props = {
    className?: string,
    periods: HistoryPeriodModel[],
    selected: HistoryPeriod
}
const HistoryPeriodTabs: React.FC<Props> = ({className, selected, periods}) => {
    const [width, setWidth] = React.useState(0);

    React.useEffect(() => {
        const handleResize = () => setWidth(window.innerWidth);

        window.addEventListener('resize', handleResize);

        handleResize();

        return () => window.removeEventListener('resize', handleResize);
    }, []);

    const router = useRouter();
    const handleChange = (event: React.ChangeEvent<{}>, newValue: HistoryPeriod) => {
        if (newValue !== selected)
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
                {periods.map(x => <Tab key={x.type} label={x.title} value={x.type}/>)}
            </Tabs>
        </AppBar>

    )
}

export default HistoryPeriodTabs;
