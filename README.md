# Kitap Yönetim API'si

Bu proje, kitapları yönetmek için oluşturulmuş **ASP.NET Core Web API** uygulamasıdır. Kullanıcılar kitapları ekleyebilir, güncelleyebilir, silebilir ve listeleyebilir.

## Kullanılan Teknolojiler
- **AASP.NET Core 6 ve üstü**
- **Entity Framework Core**
- **SQL Server (veya başka bir ilişkisel veritabanı)**
- **MediatR (Komut/Sorgu ayrımı için isteğe bağlı)**
- **Docker (İsteğe bağlı dağıtım için)**

## Başlangıç

### Ön Koşullar
- **.ASP.NET Core 6 ve üstü**
- **SQL Server veya farklı bir veritabanı sağlayıcısı**
- **Postman veya API test aracı**

### Kurulum ve Çalıştırma

1. **Projeyi Klonlayın**
```sh
   git clone https://github.com/your-repo/kitap-yonetim-api.git
   cd kitap-yonetim-api
```

2. **Bağımlılıkları Yükleyin**
```sh
   dotnet restore
```

3. **Veritabanı Bağlantı Ayarlarını Güncelleyin** (`appsettings.json` dosyasında)
```json
   "ConnectionStrings": {
      "DefaultConnection": "Server=SUNUCUNUZ;Database=KitapDB;Trusted_Connection=True;"
   }
```

4. **Veritabanı Göçlerini (Migrations) Uygulayın**
```sh
   dotnet ef database update
```

5. **Uygulamayı Çalıştırın**
```sh
   dotnet run
```

6. **Swagger UI ile API'yi Test Edin**
    - `http://localhost:5000/swagger` adresine giderek API'nizi test edebilirsiniz.

---
## API Uç Noktaları (Endpoints)

### Tüm Kitapları Getir
```http
GET /books
```
**Yanıt:**
```json
[
  {
    "id": 1,
    "title": "Lean Startup",
    "genreId": 1,
    "pageCount": 200,
    "publishDate": "2001-01-01"
  }
]
```

### Belirli Bir Kitabı Getir
```http
GET /books/{id}
```
**Yanıt:**
```json
{
  "id": 1,
  "title": "Lean Startup",
  "genreId": 1,
  "pageCount": 200,
  "publishDate": "2001-01-01"
}
```

### Yeni Kitap Ekle
```http
POST /books
```
**İstek Gövdesi:**
```json
{
  "title": "Yeni Kitap",
  "genreId": 2,
  "pageCount": 300,
  "publishDate": "2023-05-10"
}
```

### Kitabı Güncelle
```http
PUT /books/{id}
```
**İstek Gövdesi:**
```json
{
  "title": "Güncellenmiş Başlık",
  "genreId": 3,
  "pageCount": 350,
  "publishDate": "2022-09-15"
}
```

### Kitabı Sil
```http
DELETE /books/{id}
```

---
## Hata Yönetimi
API, aşağıdaki HTTP durum kodlarını döndürmektedir:
- `200 OK` – Başarılı işlem
- `400 Bad Request` – Geçersiz veri veya eksik alanlar
- `404 Not Found` – Kitap bulunamadı
- `500 Internal Server Error` – Sunucu tarafında hata

## Dağıtım
Bu API, **Docker** veya herhangi bir bulut sağlayıcısı (**Azure, AWS, Heroku**) kullanılarak dağıtılabilir.

### Docker ile Çalıştırma
```sh
   docker build -t kitap-api .
   docker run -p 5000:80 kitap-api
```

---
## Lisans
Bu proje açık kaynaklıdır ve **MIT Lisansı** altında yayınlanmıştır.

