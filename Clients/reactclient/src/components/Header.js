import { useContext } from "react";
import { MovieContext } from "../MovieContext";
import { Link } from "react-router-dom";

const Header = () => {
    const { cartItems } = useContext(MovieContext);
    const cartClass = cartItems.length > 0 ? "fill" : "line";

    return (
        <header>
            <Link to='/'><h1>M<span>T</span>B</h1></Link>
            <ul>
                <li>Coming soon</li>
                <li>Cinemas</li>
                <li>Offers</li>
                <li>IMAX</li>
                <li>Contacts</li>                
            </ul>
            <Link to='/cart'><i className={`ri-shopping-cart-${cartClass} ri-fw ri-2x`}></i></Link>
        </header>
    )
}

export default Header;