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
            <Link to='/'><h1>M<span>T</span>B</h1></Link>
            {windowWidth > 780 &&
                <HeaderMenu />
            }
            <Link to='/cart'><i className={`ri-shopping-cart-${cartClass} ri-fw ri-2x`}></i></Link>
        </header>
    )
}

export default Header;