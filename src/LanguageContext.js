// src/LanguageContext.js
import React, { createContext, useState, useContext } from "react";
import translations from "./i18n";

const LanguageContext = createContext();

export const LanguageProvider = ({ children }) => {
  const [language, setLanguage] = useState("es"); // Idioma predeterminado: Español

  const toggleLanguage = (lang) => setLanguage(lang);

  const t = (key) => translations[language]?.[key] || key;

  return (
    <LanguageContext.Provider value={{ language, toggleLanguage, t }}>
      {children}
    </LanguageContext.Provider>
  );
};

export const useLanguage = () => useContext(LanguageContext);
