# 🤖 AI File Assistant

An AI-powered document assistant built with ASP.NET Core MVC, following clean architecture principles.

## 🚀 Features

- Upload PDF and Word documents
- Extract document text
- Intelligent document chunking
- Local AI using Ollama
- Vector embeddings
- Semantic search
- RAG (Retrieval-Augmented Generation)
- Chat with your documents
- Source citations

---

## 🏗️ Tech Stack

- ASP.NET Core 8 MVC
- C#
- Semantic Kernel
- Ollama
- Qdrant (coming soon)
- iText7
- Dependency Injection

---

## 📂 Architecture

```text
User
 │
 ▼
MVC Controller
 │
 ▼
Services
 │
 ├── Document Reader
 ├── Chunking Service
 ├── Embedding Service
 └── Chat Service
 │
 ▼
Ollama
 │
 ▼
Qdrant
 │
 ▼
LLM Response
```

---

## 📅 Roadmap

- [x] Upload Documents
- [x] PDF Extraction
- [x] Document Chunking
- [ ] Ollama Integration
- [ ] Embeddings
- [ ] Vector Database
- [ ] Semantic Search
- [ ] Chat Interface
- [ ] AI Agent
- [ ] Conversation Memory

---

## 👨‍💻 Author

**Anup Sable**