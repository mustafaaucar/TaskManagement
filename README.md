# 🧱 Task Management API  
### Clean Architecture • CQRS • MediatR • MongoDB • Pipeline Behaviors

Bu proje, modern bir .NET uygulamasında **Clean Architecture**, **CQRS**, **MediatR**,  
**MongoDB**, ve **Pipeline Behaviors** (Logging, Validation, Performance) gibi gelişmiş mimari kavramları uygulayan örnek bir Task Management API’sidir.

English version is included below. 👇

---

# 🇹🇷 Türkçe Açıklama

## 🚀 1. Proje Hakkında

Bu proje öğrenme amaçlı geliştirilmiş olup aşağıdaki mimari konseptleri içermektedir:

- **Clean Architecture**
  - Domain (Entity)
  - Application (CQRS + Behaviors)
  - Infrastucture (MongoDB)
  - API (Minimal API)
- **CQRS + MediatR**
- **MongoDB Repository Pattern**
- **Pipeline Behaviors**
  - LoggingBehavior
  - ValidationBehavior
  - PerformanceBehavior

---

## 🧱 2. Mimari Yapı

/
  ├── API → Minimal API + DI + Swagger
  ├── Application → CQRS, Behaviors, Interfaces
  ├── Domain → Entity tanımları
  └── Infrastucture → MongoDB ve repository implementasyonu


## 📝 3. Özellikler

| Özellik | Açıklama | Endpoint |
|--------|----------|----------|
| Task oluştur | Yeni görev ekler | `POST /tasks` |
| Task listesi | Tüm görevleri döner | `GET /tasks` |
| Task güncelle | Tamamlandı bilgisini değiştirir | `PUT /tasks/{id}/status?completed=true` |
| Task sil | Görevi siler | `DELETE /tasks/{id}` |

---

## 🧩 4. Task Modeli

```json
{
  "id": "ObjectId",
  "title": "string",
  "description": "string",
  "isCompleted": false,
  "createdAt": "2025-01-01T00:00:00Z"
}
