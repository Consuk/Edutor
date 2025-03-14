import React, { useState } from "react";
import "./Navbar.css";
import { useLanguage } from "../../LanguageContext";

function Navbar() {
  const { t, toggleLanguage, language } = useLanguage();
  const [dropdownOpen, setDropdownOpen] = useState(false);

  const handleLanguageChange = (lang) => {
    toggleLanguage(lang);
    setDropdownOpen(false); // Cierra el dropdown después de seleccionar
  };

  return (
    <nav className="navbar">
      {/* Logo a la izquierda */}
      <div className="navbar-left">
        <div className="logo">
          <a href="/"><span>{t("logo")}</span></a>
        </div>
        <ul className="navbar-links">
          <li><a href="/">{t("currentContent")}</a></li>
          <li><a href="/documents">{t("documents")}</a></li>
          <li><a href="/exams">{t("exam")}</a></li>
          <li>
            <a href="/calendario" className="highlight-button">{t("calendar")}</a>
          </li>
        </ul>
      </div>

      {/* Dropdown para cambiar idioma */}
      <div className="navbar-right">
        <div className="dropdown">
          <button
            className="dropdown-button"
            onClick={() => setDropdownOpen(!dropdownOpen)}
          >
            {language === "es" ? "Español" : "English"}
          </button>
          {dropdownOpen && (
            <div className="dropdown-menu">
              <button onClick={() => handleLanguageChange("es")}>Español</button>
              <button onClick={() => handleLanguageChange("en")}>English</button>
            </div>
          )}
        </div>
      </div>
    </nav>
  );
}

export default Navbar;
