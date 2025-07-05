# Proje Yönetimi Sistemi (Blazor Server)

Bu proje, projeleri ve bu projelere bağlı görevleri yönetmek için tasarlanmış, **Blazor Server tabanlı** modern bir web uygulamasıdır. Temiz kod, SOLID prensipleri ve katmanlı mimari ile geliştirilmiştir. Uygulama doğrudan veritabanına erişir, API katmanı ve Swagger şu an aktif değildir (isteğe bağlı olarak ileride Vue.js ve API eklenecektir).

## Özellikler

-   **Proje Yönetimi:** Projeler oluşturun, görüntüleyin, güncelleyin ve silin.
-   **Görev Yönetimi:** Projelere bağlı görevler oluşturun, görüntüleyin, güncelleyin ve silin.
-   **Blazor Server UI:** Modern, etkileşimli ve erişilebilir arayüz.
-   **İlişkisel Veritabanı:** Projeler ve görevler arasında bire çok ilişki (bir proje birden çok görev içerebilir).
-   **Temiz Kod ve SOLID:** Kodun sürdürülebilirliği ve okunabilirliği için en iyi pratikler uygulanmıştır.

## Kullanılan Teknolojiler

-   **.NET 8 & Blazor Server:** Modern, gerçek zamanlı ve C# tabanlı web arayüzü.
-   **Entity Framework Core:** Veritabanı işlemleri için ORM (Object-Relational Mapper).
-   **PostgreSQL:** Güçlü, açık kaynaklı ilişkisel veritabanı.
-   **Docker:** Uygulamanın ve veritabanının kapsayıcılar içinde izole çalıştırılması.

## Mimari Yaklaşım

Proje, Clean Architecture ve SOLID prensipleriyle tasarlanmıştır:

-   **Modeller (Models):** Temel veri yapıları (Project, TaskItem).
-   **Kontratlar (Contracts):** Servis ve repository arayüzleri (IProjectService, ITaskItemService, IProjectRepository, ITaskItemRepository).
-   **Depolar (Repositories):** Entity Framework Core ile veri erişimi.
-   **Hizmetler (Services):** İş mantığı ve veri operasyonları.
-   **Blazor Componentleri:** UI ve iş mantığı code-behind ile ayrılmıştır.

## Başlarken

### Ön Koşullar
-   [Docker Desktop](https://www.docker.com/products/docker-desktop/) kurulu olmalıdır.

### Kurulum ve Çalıştırma (Docker ile)

1.  **Depoyu Klonlayın:**
    ```bash
    git clone https://github.com/berkanmandaci/JobApplicationProject.git
    cd JobApplicationProject
    ```

2.  **Veritabanı Kimlik Bilgilerini Ayarlayın:**
    `docker-compose.yml` dosyası, PostgreSQL veritabanı için ortam değişkenlerini kullanır. Bu değişkenleri Docker Compose çalıştırmadan önce terminalinizde ayarlayın.

    **PowerShell için:**
    ```powershell
    $env:ADMIN_USERNAME="admin"
    $env:ADMIN_PASSWORD="admin"
    ```
    *Varsayılan olarak admin/admin kullanılır, isterseniz değiştirebilirsiniz.*

3.  **Uygulamayı Başlatın:**
    ```bash
    docker compose up --build
    ```
    Bu komut, hem PostgreSQL veritabanı hem de Blazor Server uygulaması için Docker kapsayıcılarını oluşturacak ve başlatacaktır.

4.  **Kapsayıcıların Çalıştığını Doğrulayın:**
    ```bash
    docker ps
    ```
    `jobapplicationproject-ui-1` ve `jobapplicationproject-db-1` kapsayıcılarının `Up` durumda olduğunu görmelisiniz.

5.  **Blazor Arayüzüne Erişim:**
    Tarayıcınızda [http://localhost:8080](http://localhost:8080) (veya docker-compose.yml'deki port ayarına göre) adresine gidin.

## Uygulama Kullanımı

-   **Projeler** sekmesinden yeni proje ekleyebilir, mevcut projeleri listeleyebilir, düzenleyebilir veya silebilirsiniz.
-   Her proje için görevler ekleyip yönetebilirsiniz (görev CRUD işlemleri için benzer component yapısı kullanılabilir).
-   Arayüzde yapılan tüm işlemler gerçek zamanlı olarak veritabanına yansır.

## Geliştirici Notları

-   Kodlar code-behind (partial class) ile ayrılmıştır. UI ve iş mantığı net şekilde ayrılır.
-   SOLID ve clean code prensiplerine uygun, okunabilir ve sürdürülebilir bir yapı hedeflenmiştir.
-   İleride API ve Vue.js arayüzü eklemek için altyapı hazırdır (API ve Swagger şu an devre dışı).

## Katkı ve Geliştirme

-   Yeni özellikler eklemek veya mevcut componentleri geliştirmek için Blazor component ve code-behind yapısını takip edin.
-   Kodun okunabilirliğini ve sürdürülebilirliğini ön planda tutun.

---

Her türlü soru ve katkı için iletişime geçebilirsiniz!


