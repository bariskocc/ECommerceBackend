# E-Commerce Backend API

Clean Architecture prensiplerine uygun olarak geliştirilmiş bir e-ticaret backend projesi.

## 🏗️ Teknolojiler

### Mevcut Teknolojiler
- **.NET 8**
- **Entity Framework Core** - ORM ve veritabanı işlemleri için
- **PostgreSQL** - Ana veritabanı
- **MediatR** - CQRS pattern implementasyonu için
- **AutoMapper** - Nesne dönüşümleri için
- **FluentValidation** - Validasyon kuralları için
- **Serilog** - Yapılandırılabilir loglama için
- **Swagger** - API dokümantasyonu için

### Eklenecek Teknolojiler
- **Redis** - Caching için
- **RabbitMQ** - Message broker için
- **Elasticsearch** - Logging ve arama işlemleri için
- **Kibana** - Log görselleştirme için
- **Docker** - Konteynerizasyon için
- **Kubernetes** - Orkestrasyon için
- **Azure/AWS** - Cloud deployment için
- **SignalR** - Real-time iletişim için
- **Hangfire** - Background job processing için
- **IdentityServer4** - Authentication/Authorization için
- **MongoDB** - NoSQL veritabanı için
- **Polly** - Resilience ve fault handling için
- **Ocelot** - API Gateway için
- **gRPC** - Mikroservisler arası iletişim için

## 🏛️ Mimari

Proje Clean Architecture prensiplerine göre 4 katmandan oluşmaktadır:

- **Domain**: İş mantığının merkezi, entities ve domain logic
- **Application**: Use case'ler, business logic
- **Infrastructure**: Veritabanı, harici servisler
- **API**: HTTP endpoints, middleware'ler

## 🔧 Özellikler

### Mevcut Özellikler
- Clean Architecture implementasyonu
- CQRS ve MediatR pattern
- Global exception handling
- API versiyonlama
- Rate limiting
- Health checks
- Swagger entegrasyonu
- Serilog ile yapılandırılabilir loglama

### Eklenecek Özellikler
- JWT tabanlı authentication
- Role-based authorization
- Refresh token mekanizması
- Email servisi entegrasyonu
- Dosya upload/download işlemleri
- Ödeme sistemi entegrasyonu
- Multi-tenancy desteği
- Çoklu dil desteği
- Audit logging
- Event sourcing
- GDPR/KVKK uyumluluğu
- API documentation (Swagger UI)
- Performance monitoring
- Distributed caching
- Message queuing
- Microservices architecture

## 📚 API Dokümantasyonu

API çalışırken Swagger dokümantasyonuna şu adresten erişebilirsiniz:
`https://localhost:5001/swagger`