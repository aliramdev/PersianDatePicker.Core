# PersianDatePicker.Core.Wpf

![NuGet](https://img.shields.io/nuget/v/PersianDatePicker.Core.Wpf?color=blue)  
تقویم شمسی سبک، قابل‌سفارشی‌سازی و سازگار با WPF برای پروژه‌های دات‌نت

## ✨ امکانات

- انتخاب تاریخ شمسی با نمایش معادل میلادی
- پشتیبانی از هایلایت تاریخ انتخاب‌شده و امروز
- پشتیبانی از پاک‌سازی تاریخ انتخابی
- دارای نمایش روز، ماه، و سال با قابلیت سوئیچ بین آن‌ها
- استایل کاملاً قابل سفارشی‌سازی (XAML-based)
- خروجی `DateTime` میلادی
- طراحی مدرن و مناسب با استانداردهای UI امروزی

## 🔧 نصب از NuGet

```
Install-Package PersianDatePicker.Core.Wpf
```

یا با استفاده از .NET CLI:

```
dotnet add package PersianDatePicker.Core.Wpf
```

## 🚀 استفاده سریع

```xml
xmlns:ctrls="clr-namespace:PersianDatePicker_Core_Wpf.Controls;assembly=PersianDatePicker.Core.Wpf"

<ctrls:PersianDatePicker SelectedDate="{Binding MyDate}" />
```

## 📦 ویژگی‌ها

- `SelectedDate`: تاریخ انتخاب شده از نوع `DateTime?` به میلادی
- با کلیک روی دکمه "امروز" تاریخ به روز جاری تنظیم می‌شود
- دکمه "پاک کردن" برای خالی کردن مقدار انتخاب شده
- پاپ‌آپ تقویم با انیمیشن و قابلیت شخصی‌سازی ظاهری

## 🎨 سفارشی‌سازی

می‌توانید ظاهر و آیکن‌ها را با استایل‌های سفارشی بازنویسی کنید. برای مثال، تغییر استایل دکمه‌ها یا اضافه کردن آیکن‌های SVG.

## 📥 پیش‌نیازها

- .NET Core 3.1 یا .NET 5/6/7+
- پروژه WPF

## 👤 نویسنده

Ali Ramezani  
📧 a.ramezani1364@gmail.com  
🌐 [aliram.ir](https://aliram.ir)

## 📃 لایسنس

MIT

---

پروژه با عشق ❤️ برای توسعه‌دهندگان فارسی‌زبان توسعه داده شده است.
