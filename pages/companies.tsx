import {NextPage} from "next";
import {Container} from "@material-ui/core";
import Link from "next/link";

const Companies: NextPage = () => (
    <Container>
        <div>Companies</div>
        <Link href={'/'}>Index</Link>
    </Container>
)

export default Companies