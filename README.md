# 🧱 Task Management API  
### Clean Architecture • CQRS • MediatR • MongoDB • Pipeline Behaviors

Bu proje, modern bir .NET uygulamasında **Clean Architecture**, **CQRS**, **MediatR**,  
**MongoDB**, ve **Pipeline Behaviors** (Logging, Validation, Performance) gibi gelişmiş mimari kavramları uygulayan örnek bir Task Management API’sidir.


---

## 1. Yapım Amacım

Bu proje, günümüzde sıkça kullanılan modern .NET mimarilerini deneyimlemek ve öğrenmek amacıyla geliştirilmiştir.
Hedefim:

Clean Architecture yapısını doğru şekilde uygulamak

CQRS ve MediatR ile command/query ayrımını öğrenmek

MongoDB ile repository pattern kullanımını görmek

Pipeline Behavior mantığını kavramak

Esnek, test edilebilir ve genişletilebilir bir mimari kurmak

Bu proje bir “todo app” oluşturmak için değil; kurumsal mimariyi kavramak,
servis katmanlarını ayırmak,
bağımlılık yönlerini doğru kurmak,
ve modern .NET uygulamalarının nasıl inşa edildiğini öğrenmek için hazırlanmıştır.

## 🚀 2. Proje Hakkında

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

## 🧱 3. Mimari Yapı

/
  ├── API → Minimal API + DI + Swagger
  ├── Application → CQRS, Behaviors, Interfaces
  ├── Domain → Entity tanımları
  └── Infrastucture → MongoDB ve repository implementasyonu


## 📝 4. Özellikler

| Özellik | Açıklama | Endpoint |
|--------|----------|----------|
| Task oluştur | Yeni görev ekler | `POST /tasks` |
| Task listesi | Tüm görevleri döner | `GET /tasks` |
| Task güncelle | Tamamlandı bilgisini değiştirir | `PUT /tasks/{id}/status?completed=true` |
| Task sil | Görevi siler | `DELETE /tasks/{id}` |

---


## 🧩 5. Task Modeli

```json
{
  "id": "ObjectId",
  "title": "string",
  "description": "string",
  "isCompleted": false,
  "createdAt": "2025-01-01T00:00:00Z"
}

