import React, { useState } from "react";
import "./Documents.css";

function Documents() {
    const [file, setFile] = useState(null);
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [grade, setGrade] = useState('');
    const [years, setYears] = useState([]);

    const handleFileChange = (event) => {
        setFile(event.target.files[0]);
    };

    const handleStartDateChange = (event) => {
        const newStartDate = event.target.value;
        if (new Date(newStartDate) > new Date(endDate)) {
            alert("Start date cannot be after end date.");
            return;
        }
        setStartDate(newStartDate);
    };

    const handleEndDateChange = (event) => {
        const newEndDate = event.target.value;
        if (new Date(newEndDate) < new Date(startDate)) {
            alert("End date cannot be before start date.");
            return;
        }
        setEndDate(newEndDate);
    };

    const handleGradeChange = (event) => {
        setGrade(event.target.value);
        const yearsOptions = {
            'primaria': Array.from({ length: 6 }, (_, i) => i + 1),
            'secundaria': Array.from({ length: 3 }, (_, i) => i + 1),
            'preparatoria': Array.from({ length: 3 }, (_, i) => i + 1),
            'universidad': Array.from({ length: 4 }, (_, i) => i + 1),
        };
        setYears(yearsOptions[event.target.value] || []);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        // Ensure the date range is within one year
        const start = new Date(startDate);
        const end = new Date(endDate);
        const oneYearLater = new Date(start);
        oneYearLater.setFullYear(oneYearLater.getFullYear() + 1);

        if (end > oneYearLater) {
            alert("The date range cannot exceed one year.");
            return;
        }

        if (!file || !startDate || !endDate || !grade || years.length === 0) {
            alert('Please fill all fields before submitting.');
            return;
        }

        const formData = new FormData();
        formData.append('file', file);
        formData.append('startDate', startDate);
        formData.append('endDate', endDate);
        formData.append('grade', grade);
        formData.append('years', years);

        try {
            const response = await fetch('http://your-backend-url.com/upload', {
                method: 'POST',
                body: formData,
            });

            if (response.ok) {
                const result = await response.json();
                console.log('Success:', result);
                alert('File and data submitted successfully!');
            } else {
                throw new Error('Failed to submit data');
            }
        } catch (error) {
            console.error('Error:', error);
            alert('Failed to submit file and data.');
        }
    };

    return (
        <div className="document-container">
            <form onSubmit={handleSubmit} className="document-form">
                <div className="file-input-container">
                    <label htmlFor="file-input">Seleccionar archivo</label>
                    <input id="file-input" type="file" className="file-input" onChange={handleFileChange} accept="application/pdf" />
                </div>
                <div className="date-fields">
                    <div className="date-label">
                        <label>Start Date:</label>
                        <input type="date" className="date-input" value={startDate} onChange={handleStartDateChange} />
                    </div>
                    <div className="date-label">
                        <label>End Date:</label>
                        <input type="date" className="date-input" value={endDate} onChange={handleEndDateChange} />
                    </div>
                </div>
                <div className="select-row">
                    <select className="select-input" value={grade} onChange={handleGradeChange}>
                        <option value="">Selecciona grado</option>
                        <option value="primaria">Primaria</option>
                        <option value="secundaria">Secundaria</option>
                        <option value="preparatoria">Preparatoria</option>
                        <option value="universidad">Universidad</option>
                    </select>
                    <select className="select-input">
                        <option value="">Selecciona años de estudio</option>
                        {years.map((year) => (
                            <option key={year} value={year}>{year}</option>
                        ))}
                    </select>
                </div>
                <button type="submit" className="button">Subir</button>
            </form>
        </div>
    );
}

export default Documents;
