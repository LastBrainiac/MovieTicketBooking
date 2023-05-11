import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { MovieContextProvider } from './MovieContext';
import { BrowserRouter as Router } from 'react-router-dom';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <MovieContextProvider>
      <Router>
        <App />
      </Router>
    </MovieContextProvider>
  </React.StrictMode>
);

