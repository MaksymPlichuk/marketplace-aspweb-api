import {Outlet} from "react-router";
import Navbar from "./Navbar.tsx";
import Footer from "./Footer.tsx";

const DefaultLayout: React.FC = () => {
    return (
        <>
            <Navbar/>
            <div className="main justify-content-center align-items-center h-full mt-5">
                <Outlet></Outlet>
            </div>
            <Footer/>
        </>
    )
}
export default DefaultLayout;