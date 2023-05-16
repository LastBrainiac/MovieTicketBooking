import { useContext, useEffect, useState } from "react";
import { MovieContext } from "../../MovieContext";
import { Link } from "react-router-dom";
import HeaderMenu from "./HeaderMenu";

const Header = () => {
    const { cartItems } = useContext(MovieContext);
    const cartClass = cartItems.length > 0 ? "fill" : "line";
    const [windowWidth, setWindowWidth] = useState(window.innerWidth);

    useEffect(() => {
        const handler = () => setWindowWidth(window.innerWidth);
        window.addEventListener('resize', handler);
        return () => window.removeEventListener('resize', handler);
    }, []);

    return (
        <header>
            <Link to='/'>
                <div className="logo">
                    <h1 className="m"><span>M</span>ovie</h1>
                    <h1 className="t"><span>T</span>icket</h1>
                    <h1><span>B</span>ooking</h1>
                </div>
            </Link>
            {windowWidth > 780 &&
                <HeaderMenu />
            }
            <Link to='/cart'><i className={`ri-shopping-cart-${cartClass} ri-fw ri-2x`}></i></Link>
        </header>
    )
}

export default Header;