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

## 📈 Current Progress

| Feature | Status |
|----------|--------|
| PDF Upload | ✅ |
| PDF Extraction | ✅ |
| Chunking | ✅ |
| Ollama Embeddings | ✅ |
| Docker | ✅ |
| Qdrant | ✅ |
| Store Vectors | 🚧 |
| Semantic Search | ⏳ |
| Chatbot | ⏳ |
| AI Agent | ⏳ |

## ✅ Completed Features

- Upload PDF documents
- PDF text extraction
- Document chunking
- Local embeddings using Ollama
- Store embeddings in Qdrant
- Clean architecture
- Dependency Injection
- Factory Pattern for document readers
---

## 👨‍💻 Author

**Anup Sable**