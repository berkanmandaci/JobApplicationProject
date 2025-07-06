# Proje Yönetimi Sistemi (Blazor Server, Vue.js, Web API, Docker Compose)

Bu proje, projeleri ve bu projelere bağlı görevleri yönetmek için geliştirilmiş, **çok katmanlı ve modern bir web uygulamasıdır**. Hem Blazor Server hem de Vue.js ile iki farklı frontend çözümü sunar ve ortak bir .NET class library ile iş mantığı paylaşılır. Tüm servisler Docker Compose ile kolayca ayağa kaldırılır.

## Özellikler

- **Proje Yönetimi:** Projeler oluşturulabilir, listelenebilir, güncellenebilir ve silinebilir.
- **Görev Yönetimi:** Projelere bağlı görevler eklenebilir, listelenebilir, güncellenebilir ve silinebilir.
- **Blazor Server UI:** Modern, gerçek zamanlı ve C# tabanlı web arayüzü.
- **Vue.js UI:** Modern, bağımsız ve API tabanlı frontend (SPA).
- **Web API:** RESTful endpoint'ler ile frontend'lere veri sağlar. Swagger/OpenAPI desteği vardır.
- **Ortak Class Library:** Hem Blazor hem de API tarafından kullanılan iş mantığı ve veri erişimi.
- **PostgreSQL:** Güçlü, açık kaynaklı ilişkisel veritabanı.
- **Docker Compose:** Tüm servisler tek komutla ayağa kalkar.

## Mimari

- **JobApplicationProject:** Ortak class library (iş mantığı, veri erişimi, modeller)
- **JobApplicationProject.Api:** .NET 8 Web API (REST endpoint'ler, Swagger)
- **UI:** Blazor Server arayüzü (C# tabanlı)
- **vue-ui:** Vue.js 3 + Vite ile SPA arayüzü (API ile konuşur)
- **PostgreSQL:** Veritabanı

## Kurulum ve Çalıştırma

### Ön Koşullar
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) kurulu olmalı.

### Hızlı Başlangıç (Tüm Servisler İçin)

1. **Depoyu Klonlayın:**
    ```bash
    git clone https://github.com/berkanmandaci/
    JobApplicationProject.git
    cd JobApplicationProject
    ```
2. **Gerekli Ortam Değişkenlerini Ayarlayın:**
    ```powershell
    $env:POSTGRES_DB="JobApplicationDb"
    $env:POSTGRES_USER="admin"
    $env:POSTGRES_PASSWORD="admin"

    ```
3. **Tüm Servisleri Başlatın:**
    ```bash
    docker-compose up --build
    ```
4. **Servislere Erişim:**
    - **Blazor Server UI:** [http://localhost:8080](http://localhost:8080)
    - **Vue.js UI:** [http://localhost:8081](http://localhost:8081)
    - **Web API (Swagger):** [http://localhost:5000/swagger](http://localhost:5000/swagger)
    - **PostgreSQL:** Port 5435 üzerinden erişilebilir

## Kullanım

- **Projeler** sekmesinden yeni proje ekleyebilir, mevcut projeleri listeleyebilir, düzenleyebilir veya silebilirsiniz.
- Her proje için görevler ekleyip yönetebilirsiniz (görev CRUD işlemleri için benzer component yapısı kullanılabilir).
- Blazor Server arayüzü doğrudan class library ile, Vue.js arayüzü ise Web API üzerinden veriyle çalışır.

## Geliştirici Notları

- **Çok Katmanlı Mimari:** Ortak iş mantığı ve veri erişimi class library'de tutulur. Hem Blazor hem de API bu katmanı kullanır.
- **Blazor Server:** .NET'in component tabanlı, hızlı ve entegre arayüzü. API'ye ihtiyaç duymadan doğrudan class library ile çalışır.
- **Vue.js:** Modern, bağımsız frontend. Sadece Web API ile konuşur. Gerçek dünyada en çok tercih edilen frontend mimarisi budur.
- **Web API:** Tüm frontend'lere RESTful endpoint sağlar. Swagger ile kolayca test edilebilir.
- **Docker Compose:** Tüm servisler tek komutla ayağa kalkar, port çakışmaları önlenmiştir.
- **SPA Routing (Vue.js):** Nginx config ile SPA route'ları desteklenir.
- **CORS:** API'de CORS açık, farklı frontend'ler rahatça erişebilir.

