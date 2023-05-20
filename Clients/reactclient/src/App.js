import { Route, Routes } from 'react-router-dom';
import './App.css';
import Header from './components/header/Header';
import NowShowing from './pages/NowShowing';
import ScreeningTimes from './pages/ScreeningTimes';
import Footer from './components/footer/Footer';
import GridLoader from 'react-spinners/GridLoader';
import { useContext } from 'react';
import { MovieContext } from './MovieContext';
import SeatSelection from './pages/SeatSelection';

function App() {
  const { loading } = useContext(MovieContext);

  return (
    <div>
      <Header />
      <GridLoader className="loader" color='#0c72f7' loading={loading} />
      <Routes>
        <Route path='/' element={<NowShowing />} />
        <Route path='/screening' element={<ScreeningTimes />} />
        <Route path='/selectseat' element={<SeatSelection />} />
        <Route path='/cart' element={<NowShowing />} />
      </Routes>
      {!loading && <Footer />}
    </div>
  );
}

export default App;
