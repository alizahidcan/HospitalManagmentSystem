# Hospital Management System
Bu proje, ASP.NET Core 6 MVC kullanılarak geliştirilmiş bir Hastane Yönetim Sistemi'ni temsil eder.

## Teknolojiler

- ASP.NET Core 6 MVC: Web uygulaması için temel platform.
- C#: Uygulama tarafında kullanılan ana programlama dili.
- Entity Framework Core ORM: Veritabanı işlemleri için kullanılan nesne ilişkilendirme teknolojisi.
- Bootstrap Tema: Kullanıcı arayüzü için modern ve duyarlı tasarım.
- HTML5, CSS3, Javascript ve jQuery: Front-end geliştirmek için kullanılan teknolojiler.
- SQL Server / PostgreSQL: Veritabanı yönetimi için kullanılan ilişkisel veritabanı sistemleri.

## Kurulum

1. **Clone the repository:**
   ```bash
   git clone https://github.com/kullaniciadi/hospital-management-system.git
2. **Proje dizine gidin**
   ```bash
   cd hospital-management-system
3. **Proje dosyalarını açmak için IDE kullanın**
4. **appsettings.json dosyasını düzenleyin ve veritabanı bağlantı ayarlarınızı belirtin:**
   ```json
   "ConnectionStrings": {"DefaultConnection": "Server=your-server;Database=your-database;User Id=your-username;Password=your-password;"}

5. **Proje ana dizininde aşağıdaki komutu çalıştırarak veritabanını güncelleyin:**
    ```bash
    dotnet ef database update
6. **Proje dosyalarını açın ve IDE içinde çalıştırarak projeyi başlatın.**
7. **Tarayıcıda https://localhost:5001 adresine gidin ve uygulamayı kullanmaya başlayın.*

## Kullanıcı Bilgileri
- Admin Kullanıcı Adı: OgrenciNuramarasi@sakarya.edu.tr
- Admin Şifre: sau123

## Özellikler
- Kullanıcıların üye olabileceği bir sayfa.
- Admin ve kayıtlı üye kullanıcıları için yetkilendirme.
- Çok dilli destek (Türkçe/İngilizce).
- LINQ kullanılarak veritabanındaki verilerden sorgulamalar için API hizmeti.
- Bootstrap teması ve modern Front-end teknolojileriyle geliştirilmiş kullanıcı arayüzü.

## Destek
Herhangi bir sorunuz veya geri bildiriminiz varsa lütfen bir issue oluşturun.


