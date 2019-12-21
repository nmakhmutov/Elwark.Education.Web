import {NextComponentType} from "next";
import {Container} from "@material-ui/core";

const MainLayout: NextComponentType = props => (
    <Container>
        {props.children}
    </Container>
);

export default MainLayout;