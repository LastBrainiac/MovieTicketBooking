import { useContext, useEffect, useState } from "react";
import { MovieContext } from "../../MovieContext";
import { Link } from "react-router-dom";
import HeaderMenu from "./HeaderMenu";
import Badge from '@mui/material/Badge';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import { Tooltip } from "@mui/material";

const Header = () => {
    const { cartItems } = useContext(MovieContext);
    const [windowWidth, setWindowWidth] = useState(window.innerWidth);

    useEffect(() => {
        const handler = () => setWindowWidth(window.innerWidth);
        window.addEventListener('resize', handler);
        return () => window.removeEventListener('resize', handler);
    }, []);

    return (
        <div className="header-container">
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
            <Link to='/cart'>
                <Tooltip title='My Bookings' placement="bottom-start" arrow>
                    <Badge badgeContent={cartItems.length} color="primary">
                        <ShoppingCartIcon sx={{ color: 'var(--gray-light)' }} />
                    </Badge>
                </Tooltip>
            </Link>
        </div>
    )
}

export default Header;