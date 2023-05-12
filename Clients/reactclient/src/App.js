import { Route, Routes } from 'react-router-dom';
import './App.css';
import Header from './components/header/Header';
import NowShowing from './pages/NowShowing';
import ScreeningTimes from './pages/ScreeningTimes';
import Footer from './components/footer/Footer';

function App() {
  return (
    <div>
      <Header />
      <Routes>
        <Route path='/' element={<NowShowing />} />
        <Route path='/screening' element={<ScreeningTimes />} />
        <Route path='/cart' element={<NowShowing />} />
      </Routes>
      <Footer />
    </div>
  );
}

export default App;
