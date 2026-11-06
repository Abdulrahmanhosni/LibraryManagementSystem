# Library Management System

نظام إدارة مكتبة مبني باستخدام .NET 10 وEntity Framework Core وSQL Server.

## المتطلبات

- .NET 10 SDK
- SQL Server
- Visual Studio 2026 أو أي محرر يدعم .NET 10
- أداة Entity Framework Core CLI عند الحاجة إلى تنفيذ أوامر migrations

## إعداد المشروع

1. انسخ الملف:

   `LibraryManagementSystem/appsettings.example.json`

   إلى:

   `LibraryManagementSystem/appsettings.json`

2. عدّل connection string داخل `appsettings.json` ليتوافق مع إعدادات SQL Server على جهازك.

3. استعد الحزم وابنِ المشروع:

   ```powershell
   dotnet restore
   dotnet build
   ```

## التشغيل

شغّل المشروع باستخدام:

```powershell
dotnet run --project LibraryManagementSystem/LibraryManagementSystem.csproj
```

عند التشغيل يتم تطبيق الـ migrations تلقائيًا، ثم يتم إدخال البيانات التجريبية إذا كانت قاعدة البيانات فارغة.

## Migrations

لتطبيق الـ migrations يدويًا:

```powershell
dotnet ef database update --project LibraryManagementSystem/LibraryManagementSystem.csproj
```

لإنشاء migration جديدة:

```powershell
dotnet ef migrations add MigrationName --project LibraryManagementSystem/LibraryManagementSystem.csproj
```

## هيكل المشروع

- `Models/`: كيانات المؤلفين والكتب والتصنيفات والأعضاء والإعارات.
- `Configurations/`: إعدادات EF Core والعلاقات بين الجداول.
- `Data/`: DbContext وFactory وبيانات seed وإعدادات قاعدة البيانات.
- `Migrations/`: migrations الخاصة بقاعدة البيانات.
- `appsettings.example.json`: نموذج إعدادات بدون بيانات شخصية.

## العلاقات

- Author وBook: one-to-many.
- Book وCategory: many-to-many.
- Book وLoan: one-to-many.
- Member وLoan: one-to-many.

## ملاحظة أمنية

ملف `appsettings.json` محلي ولا يجب رفعه إلى GitHub لأنه قد يحتوي على بيانات اتصال خاصة. استخدم `appsettings.example.json` كنموذج للإعدادات.
