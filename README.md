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

## 🛠️ Teknolojiler (Tech Stack)

* **Backend:** .NET 8.0, ASP.NET Core MVC
* **Architecture:** Manual CQRS
* **Database:** SQL Server
* **Patterns:** Chain of Responsibility, Observer, Repository, Unit of Work
* **Cloud:** Google Cloud Storage (V1)
* **Security:** ASP.NET Core Identity (Custom Auth)
* **Mapping:** AutoMapper
* **Frontend:** Bootstrap 5, SweetAlert2

---
<img width="150" height="191" alt="ss0" src="https://github.com/user-attachments/assets/0bbd8c0f-f4aa-4b75-b737-97cc11c8f7f9" />
<img width="946" height="368" alt="ss1" src="https://github.com/user-attachments/assets/104328f3-a705-468a-9a7c-7f499fd3c17e" />
<img width="946" height="376" alt="ss3" src="https://github.com/user-attachments/assets/e089ae00-9734-456f-a957-61d7dafa4219" />
<img width="947" height="317" alt="ss4" src="https://github.com/user-attachments/assets/4c47fa8f-a494-448e-ba8b-ea97d1a663dc" />
<img width="947" height="259" alt="ss5" src="https://github.com/user-attachments/assets/e6c24676-b944-4e2b-9b84-860f159ca9d1" />
<img width="946" height="216" alt="ss6" src="https://github.com/user-attachments/assets/d87ef75a-525d-4a93-880a-97be87e33b9d" />
<img width="948" height="427" alt="ss7" src="https://github.com/user-attachments/assets/71e6faf1-2d50-4ed2-8f15-ef6e5282bd08" />
<img width="947" height="298" alt="ss8" src="https://github.com/user-attachments/assets/ab563a9f-8893-4497-a847-1ca6a9283711" />
<img width="947" height="320" alt="ss9" src="https://github.com/user-attachments/assets/a6a4d46d-31c5-495e-9143-12bab6c80c18" />
<img width="946" height="473" alt="ss10" src="https://github.com/user-attachments/assets/0aa93704-3fcf-48ee-9e87-92e6589bd169" />
<img width="947" height="473" alt="ss11" src="https://github.com/user-attachments/assets/0e164e94-dcf0-42cf-9c34-0510b3da8ecd" />
<img width="949" height="475" alt="ss12" src="https://github.com/user-attachments/assets/6b2409e9-429c-4cf6-a4eb-202fe9715697" />
<img width="952" height="476" alt="ss13" src="https://github.com/user-attachments/assets/09926a7a-93e0-46c5-806d-3faad0f9cd74" />
<img width="949" height="475" alt="ss14" src="https://github.com/user-attachments/assets/78ba8afa-b41c-4262-9005-bbadd0de88ae" />
<img width="953" height="472" alt="ss15" src="https://github.com/user-attachments/assets/a49de3a4-7d89-4dc3-941a-16dadfa823f7" />
<img width="950" height="445" alt="ss16" src="https://github.com/user-attachments/assets/f49b7b7e-ba35-41f0-9e78-b88101b85cc5" />
<img width="953" height="451" alt="ss17" src="https://github.com/user-attachments/assets/c051e9db-c383-4597-8706-b6fb6aff4566" />
<img width="949" height="473" alt="ss18" src="https://github.com/user-attachments/assets/60278c8b-ddb1-442e-b4db-6575d8610191" />
<img width="953" height="470" alt="ss19" src="https://github.com/user-attachments/assets/ee4771fc-3892-4d83-94d0-02de0e69d7ee" />
<img width="953" height="472" alt="ss20" src="https://github.com/user-attachments/assets/47d44b08-2c24-4ed7-8e42-81f6adee8ece" />
<img width="953" height="470" alt="ss21" src="https://github.com/user-attachments/assets/0895069c-6b5f-46be-9be5-5e35badd44a6" />
<img width="956" height="264" alt="ss22" src="https://github.com/user-attachments/assets/db28f9f9-a74c-4d56-bc1e-bd1b584f4ddf" />

