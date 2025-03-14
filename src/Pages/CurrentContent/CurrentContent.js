import React, { useState, useEffect } from "react";
import { format, addDays, subDays } from "date-fns";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import "./CurrentContent.css";

function CurrentContent() {
  const [selectedDate, setSelectedDate] = useState(new Date());
  const [tasks, setTasks] = useState([]);
  const [filteredTasks, setFilteredTasks] = useState([]);
  const [loading, setLoading] = useState(false);
  const [showDatePicker, setShowDatePicker] = useState(false);
  const [showSubjects, setShowSubjects] = useState(false);
  const [selectedSubject, setSelectedSubject] = useState("Materias");

  // Simulación de datos del servidor
  const fakeServerData = {
    "2025-01-15": [
      {
        title: "Preparar presentación",
        summary: "Realizar una presentación sobre tecnología en la educación.",
        tasks: ["Investigar sobre el tema", "Crear diapositivas", "Practicar presentación"],
        subject: "Educación",
      },
      {
        title: "Leer capítulo 5",
        summary: "Leer el capítulo 5 del libro de historia.",
        tasks: ["Leer páginas 120-145", "Tomar notas"],
        subject: "Historia",
      },
    ],
    "2025-01-23": [
      {
        title: "Revisar proyecto",
        summary: "Revisar el proyecto de fin de curso y hacer ajustes.",
        tasks: ["Corregir errores", "Revisar diseño", "Documentar cambios"],
        subject: "Programación",
      },{
        title: "Revisar proyecto",
        summary: "Revisar el proyecto de fin de curso y hacer ajustes.",
        tasks: ["Corregir errores", "Revisar diseño", "Documentar cambios"],
        subject: "Educación",
      },{
        title: "Revisar proyecto",
        summary: "Revisar el proyecto de fin de curso y hacer ajustes.",
        tasks: ["Corregir errores", "Revisar diseño", "Documentar cambios"],
        subject: "Lenguaje",
      },
      
    ],
  };

  const formattedDate = format(selectedDate, "yyyy-MM-dd");
  const displayDate = format(selectedDate, "EEEE dd MMMM", { locale: undefined });

  // Función para cambiar al siguiente día
  const handleNextDay = () => {
    setSelectedDate((prevDate) => addDays(prevDate, 1));
    setSelectedSubject("Materias"); // Resetear el botón de materias
  };

  // Función para cambiar al día anterior
  const handlePreviousDay = () => {
    setSelectedDate((prevDate) => subDays(prevDate, 1));
    setSelectedSubject("Materias"); // Resetear el botón de materias
  };

  // Cambiar la materia seleccionada
  const handleSubjectChange = (subject) => {
    setSelectedSubject(subject);
    setShowSubjects(false);
  };

  // Actualizar las tareas al cambiar la fecha
  useEffect(() => {
    setLoading(true);
    setTimeout(() => {
      const fetchedTasks = fakeServerData[formattedDate] || [];
      setTasks(fetchedTasks);

      // Si no hay tareas, el botón debe decir "Materias"
      const firstSubject = fetchedTasks.length > 0 ? fetchedTasks[0].subject : "Materias";
      setSelectedSubject(firstSubject);
      setLoading(false);
    }, 1000); // Simulación de retraso del servidor
  }, [formattedDate]);

  // Filtrar las tareas al cambiar la materia seleccionada
  useEffect(() => {
    if (selectedSubject === "Materias" || selectedSubject === "Todas") {
      setFilteredTasks(tasks);
    } else {
      setFilteredTasks(tasks.filter((task) => task.subject === selectedSubject));
    }
  }, [tasks, selectedSubject]);

  return (
    <div className="content-container">
      <div className="content-header">
        <button className="subjects-button" onClick={() => setShowSubjects(!showSubjects)}>
          {selectedSubject}
        </button>
      </div>

      {showSubjects && (
        <div className="subjects-dropdown">
          <div
            className="subject-option"
            onClick={() => handleSubjectChange("Todas")}
          >
            Todas
          </div>
          {tasks
            .map((task) => task.subject)
            .filter((value, index, self) => self.indexOf(value) === index) // Eliminar duplicados
            .map((subject, index) => (
              <div
                key={index}
                className="subject-option"
                onClick={() => handleSubjectChange(subject)}
              >
                {subject}
              </div>
            ))}
        </div>
      )}

      <div className="content-card">
        <div className="date-widget">
          <button className="arrow-button" onClick={handlePreviousDay}>
            ←
          </button>
          <div className="date-display" onClick={() => setShowDatePicker(true)}>
            {displayDate}
          </div>
          <button className="arrow-button" onClick={handleNextDay}>
            →
          </button>
        </div>

        {showDatePicker && (
          <div className="modal-overlay" onClick={() => setShowDatePicker(false)}>
            <div className="modal-content" onClick={(e) => e.stopPropagation()}>
              <DatePicker
                selected={selectedDate}
                onChange={(date) => {
                  setSelectedDate(date);
                  setShowDatePicker(false);
                  setSelectedSubject("Materias"); // Resetear materias al cambiar fecha
                }}
                inline
                className="date-picker"
              />
            </div>
          </div>
        )}

        <h2>Tareas para el día</h2>
        {loading ? (
          <p>Cargando tareas...</p>
        ) : filteredTasks.length > 0 ? (
          filteredTasks.map((task, index) => (
            <div key={index} className="task-card">
              <h3>{task.title}</h3>
              <p><strong>Resumen:</strong> {task.summary}</p>
              <ul>
                {task.tasks.map((subtask, idx) => (
                  <li key={idx}>{subtask}</li>
                ))}
              </ul>
            </div>
          ))
        ) : (
          <p>No hay tareas para este día.</p>
        )}
      </div>
    </div>
  );
}

export default CurrentContent;
