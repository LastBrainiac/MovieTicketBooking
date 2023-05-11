import { Route, Routes } from 'react-router-dom';
import './App.css';
import Header from './components/Header';
import NowShowing from './pages/NowShowing';

function App() {
  return (
    <div>
      <Header />
      <Routes>
        <Route path='/' element={<NowShowing />} />
        <Route path='/cart' element={<NowShowing />} />
      </Routes>
    </div>
  );
}

export default App;
