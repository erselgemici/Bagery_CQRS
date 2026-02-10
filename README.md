# 🚀 Bagery_CQRS - Advanced E-Commerce Architecture

**Bagery_CQRS**, .NET 8.0 ve ASP.NET Core kullanılarak geliştirilmiş; modern yazılım mimarileri, tasarım desenleri ve bulut teknolojilerinin entegre edildiği kapsamlı bir E-Ticaret projesidir.

Bu projenin temel amacı; **Clean Architecture** prensiplerini ve **CQRS** desenini saf  haliyle uygulayarak, dış bağımlılıkları minimize eden ve tam denetim sağlayan ölçeklenebilir bir backend mimarisi oluşturmaktır.

---

## 🏗️ Mimari ve Tasarım Desenleri

### 🔹 1. Manual CQRS & Pure Dependency Injection
Veri okuma (Query) ve yazma (Command) sorumlulukları mimari düzeyde ayrıştırılmıştır.
* **Yapı:** Her işlev, kendine ait `Handler` sınıfları tarafından yönetilir.
* **Uygulama:** Handler ve Controller arasındaki iletişim, doğrudan **Dependency Injection (DI)** prensipleriyle kurgulanmıştır.
* **Avantaj:** Bu yaklaşım sayesinde **Compile-Time (Derleme Zamanı)** güvenliği sağlanmış, "Magic Code" oluşumu engellenmiş ve kodun izlenebilirliği (Traceability) %100 artırılmıştır. Geliştirici, bir isteğin hangi sınıftan geçip nereye gittiğini IDE üzerinden doğrudan takip edebilir.

### 🔹 2. Chain of Responsibility (Zincirleme Sorumluluk Deseni)
Sipariş oluşturma süreci (`Order Processing Pipeline`), tek bir metodun içine yığılmak yerine, birbirini tetikleyen bağımsız vagonlara bölünmüştür.

1.  **CheckStockHandler:** Sepetteki ürünlerin stok durumu kontrol edilir.
2.  **PaymentHandler:** Ödeme/Bakiye doğrulaması simüle edilir.
3.  **CreateOrderHandler:** Zincirin önceki halkaları onay verirse sipariş veritabanına işlenir.

*Bu yapı, iş kurallarının (Business Rules) birbirinden izole edilmesini ve sürecin kolayca genişletilebilmesini sağlar.*

### 🔹 3. Observer Pattern (Gözlemci Deseni)
Sistemdeki kritik olayların (Sipariş oluşumu, Hata takibi vb.) ana iş mantığını kirletmeden izlenmesi için Observer deseni kullanılmıştır.
* **Subject:** Sipariş işlemi (`CreateOrderHandler`).
* **Observer:** `DbLoggerObserver`.
* **Akış:** Sipariş tamamlandığında, Observer tetiklenir ve veritabanına asenkron olarak log kaydı atar.

---

## ☁️ Google Cloud Storage Entegrasyonu

Projede medya yönetimi (Resim Upload) için sunucu disk alanı yerine **Google Cloud Platform (GCP)** kullanılmıştır.

* **Depolama:** Kullanıcıların yüklediği görseller doğrudan **Google Cloud Bucket** servisine iletilir.
* **Veritabanı:** SQL Server tarafında sadece görsellerin **Public URL**'leri saklanır.
* **Güvenlik:** Google API entegrasyonu, JSON Service Account Key ile güvenli bir şekilde yapılandırılmıştır.

---

## 🛠️ Teknoloji Yığını (Tech Stack)

* **Backend:** .NET 8.0, ASP.NET Core MVC
* **Architecture:** Manual CQRS
* **Database:** SQL Server
* **Patterns:** Chain of Responsibility, Observer, Repository, Unit of Work
* **Cloud:** Google Cloud Storage (V1)
* **Security:** ASP.NET Core Identity (Custom Auth)
* **Mapping:** AutoMapper
* **Frontend:** Bootstrap 5, SweetAlert2

---


5.  **Projeyi Başlatın:**
    ```bash
    dotnet run
    ```

---
👨‍💻 **Geliştirici:** [Adın Soyadın]
