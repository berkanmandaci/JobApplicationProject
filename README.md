# Proje Yönetimi Sistemi API

Bu proje, projeleri ve bu projelere bağlı görevleri yönetmek için tasarlanmış bir RESTful API'sidir. Temiz mimari prensipleri ve modern .NET teknolojileri kullanılarak geliştirilmiştir.

## Özellikler

-   **Proje Yönetimi:** Projeler oluşturun, görüntüleyin, güncelleyin ve silin.
-   **Görev Yönetimi:** Projelere bağlı görevler oluşturun, görüntüleyin, güncelleyin ve silin.
-   **İlişkisel Veritabanı:** Projeler ve görevler arasında bire çok ilişki (bir proje birden çok görev içerebilir).

## Kullanılan Teknolojiler

-   **.NET 8:** Modern ve yüksek performanslı bir arka uç geliştirme çerçevesi.
-   **ASP.NET Core Web API:** RESTful servisler oluşturmak için kullanılır.
-   **Entity Framework Core:** Veritabanı etkileşimleri için bir ORM (Object-Relational Mapper) aracıdır. Code-First yaklaşımıyla veritabanı şeması yönetilir.
-   **PostgreSQL:** Güçlü, açık kaynaklı bir ilişkisel veritabanı sistemi.
-   **Docker:** Uygulamanın ve veritabanının kapsayıcılar içinde izole bir şekilde çalıştırılması için kullanılır.
-   **Swagger/OpenAPI:** API dokümantasyonu ve etkileşimli test arayüzü sağlar.

## Mimari Yaklaşım

Proje, Clean Architecture ve SOLID prensipleri gözetilerek tasarlanmıştır. Bu, kodun daha modüler, test edilebilir ve sürdürülebilir olmasını sağlar:

-   **Modeller (Models):** Uygulamanın temel veri yapılarını (Project, TaskItem) içerir.
-   **Kontratlar (Contracts):** Uygulamanın iş mantığı ve veri erişim katmanları arasındaki arayüzleri (ITaskItemRepository, IProjectRepository, ITaskItemService, IProjectService) tanımlar.
-   **Depolar (Repositories):** Veritabanı etkileşimlerini soyutlar ve `TodoContext` üzerinden Entity Framework Core kullanarak veri operasyonlarını gerçekleştirir.
-   **Hizmetler (Services):** Uygulamanın iş mantığını içerir ve depo katmanını kullanarak veri operasyonlarını düzenler.
-   **Kontrolcüler (Controllers):** API endpoint'lerini tanımlar ve gelen HTTP isteklerini hizmet katmanına yönlendirir.

## Başlarken

Bu projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyin.

### Ön Koşullar

-   [Docker Desktop](https://www.docker.com/products/docker-desktop/) kurulu olmalıdır.

### Kurulum ve Çalıştırma (Docker ile)

1.  **Depoyu Klonlayın:**
    ```bash
    git clone https://github.com/KULLANICI_ADINIZ/JobApplicationProject.git
    cd JobApplicationProject
    ```
    *Not: `KULLANICI_ADINIZ` kısmını kendi GitHub kullanıcı adınızla değiştirin.*

2.  **Veritabanı Kimlik Bilgilerini Ayarlayın:**
    `docker-compose.yml` dosyası, PostgreSQL veritabanı için ortam değişkenlerini kullanır. Bu değişkenleri Docker Compose çalıştırmadan önce terminalinizde ayarlamanız gerekmektedir.

    **PowerShell için:**
    ```powershell
    $env:ADMIN_USERNAME="sizin_kullanıcı_adınız"
    $env:ADMIN_PASSWORD="sizin_şifreniz"
    ```
    *Lütfen `sizin_kullanıcı_adınız` ve `sizin_şifreniz` kısımlarını kendi belirlediğiniz güvenli kimlik bilgileriyle değiştirin.*

3.  **Uygulamayı Başlatın:**
    Proje kök dizininde (`C:\Projects\Backend\RoadMap\JobApplicationProject`)

    ```bash
    docker compose up --build
    ```
    Bu komut, hem PostgreSQL veritabanı hem de .NET Web API uygulaması için Docker kapsayıcılarını oluşturacak ve başlatacaktır. İlk çalıştırma biraz zaman alabilir.

4.  **Kapsayıcıların Çalıştığını Doğrulayın:**
    Yeni bir terminal açın ve aşağıdaki komutu çalıştırın:

    ```bash
    docker ps
    ```
    `jobapplicationproject-api-1` ve `jobapplicationproject-db-1` kapsayıcılarının `Up` durumda olduğunu görmelisiniz.

## API Uç Noktaları ve Test Etme (Swagger UI)

Uygulama başarıyla başladıktan sonra, API'ye Swagger UI üzerinden erişebilirsiniz:

[http://localhost:8080/swagger](http://localhost:8080/swagger)

Swagger UI, API'nizin tüm uç noktalarını (endpoints) listeler ve bunları etkileşimli olarak test etmenize olanak tanır.

### Önemli Not: Projeleri ve Görevleri Test Etme Sırası

Veritabanı ilişkileri nedeniyle, bir görevi oluşturmadan önce o görevin atanacağı bir proje oluşturmanız gerekmektedir.

1.  **Bir Proje Oluşturun (POST /api/Projects):**
    *   `POST /api/Projects` endpoint'ini genişletin ve `Try it out` düğmesine tıklayın.
    *   `Request body` bölümüne aşağıdaki gibi bir JSON payload girin (ID otomatik olarak oluşturulacaktır):
        ```json
        {
          "name": "Örnek Proje",
          "description": "Bu, bir demo projedir."
        }
        ```
    *   `Execute` düğmesine tıklayın. `201 Created` yanıtını aldığınızda, oluşturulan projenin `id` değerini not alın.

2.  **Bu Projeye Bağlı Bir Görev Oluşturun (POST /api/TaskItems):**
    *   `POST /api/TaskItems` endpoint'ini genişletin ve `Try it out` düğmesine tıklayın.
    *   `Request body` bölümüne aşağıdaki gibi bir JSON payload girin (ID otomatik olarak oluşturulacaktır):
        ```json
        {
          "name": "Proje Görevi A",
          "isComplete": false,
          "projectId": [PROJE_ID_BURAYA] // Önceki adımda not aldığınız proje ID'sini buraya girin
        }
        ```
    *   `Execute` düğmesine tıklayın. `201 Created` yanıtını almalısınız.

3.  **Oluşturulan Projeleri ve Görevleri Görüntüleyin (GET /api/Projects):**
    *   `GET /api/Projects` endpoint'ini genişletin ve `Try it out` düğmesine tıklayın.
    *   `Execute` düğmesine tıklayın.
    *   Dönen JSON yanıtında, oluşturduğunuz projenin `taskItems` dizisinin artık boş olmadığını ve içine eklediğiniz görevleri içerdiğini görmelisiniz.

## Gelecek Geliştirmeler (İsteğe Bağlı)

Bu proje, çeşitli iyileştirmeler ve ek özellikler için temel oluşturmaktadır. Potansiyel gelecek geliştirme alanları şunları içerebilir:

-   **Kimlik Doğrulama ve Yetkilendirme:** Kullanıcı yönetimi ve API erişimi için güvenlik katmanları ekleme.
-   **Daha İleri İş Mantığı:** Görev öncelikleri, son tarihler, kullanıcı atamaları gibi daha karmaşık iş kuralları uygulama.
-   **Bulut Dağıtımı:** Dockerize edilmiş yapısı sayesinde AWS EC2, AWS ECS (Elastic Container Service) veya Kubernetes gibi bulut platformlarına kolayca dağıtılabilir.
-   **Testler:** Birim testleri, entegrasyon testleri ve uçtan uca testler yazma.

## İletişim

Sorularınız veya geri bildirimleriniz için [e-posta adresiniz] üzerinden benimle iletişime geçebilirsiniz. 