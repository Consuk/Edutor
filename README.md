
# 📚 Edutor – Intelligent Teaching Plan Generator from Books

Este proyecto transforma libros en PDF en una herramienta de planificación educativa, usando procesamiento de lenguaje natural (NLP), visualizaciones y modelos de IA generativa (como Gemini) para generar contenidos pedagógicos como planes de clase, resúmenes y evaluaciones.

---

## 🧠 Objetivo

Automatizar la generación de materiales educativos a partir de libros, extrayendo sus ideas principales, visualizando su contenido y seleccionando bloques relevantes mediante IA para producir:

- Planificaciones semanales
- Exámenes y actividades
- Resúmenes por temas
- Análisis léxico del contenido

---

## ⚙️ Tecnologías y librerías utilizadas

- **Python 3 + Jupyter Notebook**
- `PyMuPDF` (`fitz`) – Extracción de texto desde PDFs
- `NLTK` – Tokenización, stopwords y análisis textual (visualización)
- `Matplotlib`, `Seaborn`, `WordCloud` – Visualización de datos lingüísticos
- `LangChain` – División semántica de texto en chunks
- `scikit-learn` – TF-IDF, similitud de coseno, PCA, KMeans
- **Google Vertex AI** (`text-multilingual-embedding-002`) – Embeddings semánticos
- `Google GenAI` o Gemini – Generación de contenido educativo

---

## 🧩 Estructura del pipeline

### 1. 📄 **Carga del libro PDF**
Se usa PyMuPDF para extraer todo el texto plano del PDF.

```python
full_text = extract_text_from_pdf(pdf_path)
```

---

### 2. 🔠 **Análisis textual básico**

Se generan visualizaciones exploratorias para entender el contenido:

- Frecuencia de palabras
- Nube de palabras
- Distribución de longitud de oraciones
- Evolución de vocabulario
- Tendencias de palabras por chunks

```python
run_visualizations(pdf_path)
```

---

### 3. 📚 **División semántica del libro**

Se divide el texto en fragmentos ("chunks") con solapamiento para preservar contexto semántico.

```python
splitter = RecursiveCharacterTextSplitter(chunk_size=500, chunk_overlap=100)
docs = splitter.create_documents([full_text])
```

---

### 4. 🧹 **Limpieza heurística**

Se eliminan secciones irrelevantes como índices, agradecimientos, portadas, usando heurísticas:

```python
docs = clean_and_sequence_docs(docs)
```

---

### 5. 🔍 **Filtrado por relevancia con TF-IDF**

Se define una query educativa. Se filtran los chunks con mayor relevancia usando TF-IDF.

```python
query = "Generate a semester-long teaching plan using the main ideas and structure of this book"
```

---

### 6. 🧠 **Filtrado semántico con embeddings**

Se generan embeddings con Gemini (Vertex AI) y se filtran los más cercanos al centro semántico del grupo.

```python
pre_embeddings = embed_in_batches(pre_tfidf_chunks)
```

---

### 7. 📊 **Visualización avanzada**

Se grafican:

- Histogramas y scatterplots de similitud semántica
- Mapas de calor de similitud entre chunks
- Reducción PCA de embeddings
- Clustering KMeans para encontrar grupos temáticos
- Palabras clave dominantes por TF-IDF

---

### 8. 📌 **Ponderación semántica + estructura**

Los chunks seleccionados se ponderan por:
- 70% similitud semántica
- 30% proximidad a la estructura original del libro

Esto mejora la coherencia narrativa del contenido final (`context`).

---

### 9. ✨ **Generación con IA**

El `context` final se usa como entrada a modelos generativos como Gemini para producir materiales educativos:

```python
response = model.generate_content(prompt_with_context)
```

---

## 🔮 Posibilidades de expansión

- Crear una API (FastAPI) para recibir libros y devolver contenidos educativos.
- Soporte multilingüe y multigrado (primaria, secundaria...).
- Panel de control visual con React js.
- Generación de preguntas por niveles de Bloom.

---

## 📁 Archivos importantes

| Archivo         | Descripción |
|----------------|-------------|
| `Edutor.ipynb` | Notebook principal que contiene todo el pipeline |
| `Books/`       | Carpeta con libros PDF de entrada |
| `context`      | Texto filtrado y listo para generación AI |

---

## 📢 Requisitos

```bash
pip install pymupdf nltk langchain vertexai google-cloud-aiplatform \
                matplotlib seaborn scikit-learn wordcloud
```

Además, se necesita configurar credenciales para usar Google Vertex AI:

```python
os.environ["GOOGLE_APPLICATION_CREDENTIALS"] = "KEY_HERE.json"
```

---

## 🧑‍🏫 Autores y créditos

Este proyecto fue desarrollado como parte del sistema **Edutor**, con la misión de facilitar el trabajo docente mediante herramientas inteligentes.

Por: Constanza Corvera y Pablo T. Kusulas.

---
