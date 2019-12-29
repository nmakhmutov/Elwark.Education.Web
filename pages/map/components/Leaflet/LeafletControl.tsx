import {Control, DomEvent, DomUtil} from 'leaflet';
import ReactDOM from 'react-dom';
import {Map, MapControl, MapControlProps, withLeaflet} from 'react-leaflet';

interface LeafletControlProps extends MapControlProps {
    className?: string;
}

class LeafletControl extends MapControl<LeafletControlProps> {
    constructor(props: LeafletControlProps) {
        super(props);
    }

    public createLeafletElement(opts: LeafletControlProps) {
        const CityDropdown = Control.extend({
            onAdd: (map: Map) => {
                const div = DomUtil.create('div', this.props.className);
                DomEvent.disableClickPropagation(div);

                return div;
            },
        });

        return new CityDropdown({position: this.props.position});
    }

    public componentDidMount(): void {
        // tslint:disable-next-line:no-unused-expression
        super.componentDidMount && super.componentDidMount();
        this.forceUpdate();
    }

    public render() {
        if (!this.leafletElement || !this.leafletElement.getContainer()) {
            return null;
        }

        return ReactDOM.createPortal(
            this.props.children,
            this.leafletElement.getContainer()!,
        );
    }
}

export default withLeaflet(LeafletControl);
