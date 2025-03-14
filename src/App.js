import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./Components/Navbar/Navbar";
import Documents from "./Pages/Documents/Documents"; // Asegúrate de que la ruta de importación es correcta
import CurrentContent from "./Pages/CurrentContent/CurrentContent";
import { LanguageProvider } from "./LanguageContext";

function App() {
  return (
    <LanguageProvider>
      <Router>
        <Navbar />
        <Routes>
          <Route path="/" element={<CurrentContent />} exact />
          <Route path="/documents" element={<Documents />} />
          {/* Aquí puedes añadir más rutas según sea necesario */}
        </Routes>
      </Router>
    </LanguageProvider>
  );
}

export default App;
