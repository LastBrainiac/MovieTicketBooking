import Cinemas from "./Cinemas"
import LegalMatters from "./LegalMatters"
import Public from "./Public"

const Footer = () => {
    return(
        <footer>
            <div className="footer-menu">
                <Public />
                <LegalMatters />
                <Cinemas />
            </div>
            <p className="copyright">Movie Ticket Booking, Created By Attila Ludanszki 2023</p>
        </footer>
    )
}

export default Footer;