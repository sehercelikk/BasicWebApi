# .NET Core Web API Projesi

Bu proje, Entity Framework Core ile geliştirilmiş basit bir webapi projesidir. Amaç, .NET WebApi ye uygun olarak CRUD işlemlerini gerçekleştirmektir.

## 🔧 Kullanılan Teknolojiler
- ASP.NET Core Web API
- Entity Framework Core
- Oracle
- Identity
- Git & GitHub

## 📁 Katmanlı Mimari Yapısı
- **Entities Layer**: Veri modelleri
- **Data Access Layer**: Repository ve DbContext
- **Business Layer**: Servisler ve iş kuralları
- **Web API**: Endpoint’ler

## 🧪 Özellikler
- Ürün ekleme, silme, güncelleme, listeleme
- Kullanıcı İşlemleri
- Basit yetkilendirme (JWT veya Token tabanlı yapılab)

## 🚀 Nasıl Çalıştırılır?
1. `appsettings.json` üzerinden veritabanı bağlantısı yapılandırılır.
2. `dotnet ef database update` ile veritabanı oluşturulur.
3. `dotnet run` komutu ile proje başlatılır.
