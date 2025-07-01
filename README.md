# PersianDatePicker.Core.Wpf

![NuGet Version](https://img.shields.io/nuget/v/PersianDatePicker.Core.Wpf?color=blue)
![Downloads](https://img.shields.io/nuget/dt/PersianDatePicker.Core.Wpf?color=green)
![License](https://img.shields.io/github/license/aliramdev/PersianDatePicker.Core?color=orange)

## کنترل تقویم شمسی DatePicker برای WPF

تقویم شمسی سبک، قابل‌سفارشی‌سازی و سازگار با WPF برای پروژه‌های دات‌نت

![2025-07-01_19-28-50](https://github.com/user-attachments/assets/43602fa9-f9ba-4519-8ae2-f2481a3fc482)


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
<ctrls:PersianDatePicker
    x:Name="MyDatePicker" DayButtonStyle="{StaticResource DefaultDayButtonStyle}" SelectedDate="{Binding MyDate}"/>
```

## الگوی استایل دهی

```xml
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:System="clr-namespace:System;assembly=mscorlib"
    xmlns:ctrls="clr-namespace:PersianDatePicker_Core_Wpf.Controls;assembly=PersianDatePicker.Core.Wpf">

    <Style TargetType="ctrls:PersianDatePicker">
        <Setter Property="FontFamily" Value="Fonts/#IRANSansWeb(FaNum) Medium" />
        <Setter Property="FlowDirection" Value="LeftToRight" />
        <Setter Property="FontSize" Value="14" />
        <Setter Property="Foreground" Value="Black" />
        <Setter Property="Background" Value="White" />
        <Setter Property="BorderBrush" Value="#CCCCCC" />
        <Setter Property="BorderThickness" Value="1.5" />
        <Setter Property="Padding" Value="6,4" />
        <Setter Property="Margin" Value="0,5,0,5" />
        <Setter Property="Height" Value="40" />
        <Setter Property="HorizontalContentAlignment" Value="Right" />
        <Setter Property="VerticalContentAlignment" Value="Center" />
        <Setter Property="SnapsToDevicePixels" Value="True" />
    </Style>


    <Style x:Key="DefaultDayButtonStyle" TargetType="Button">
        <Setter Property="FontFamily" Value="Fonts/#IRANSansWeb(FaNum) Medium" />
        <Setter Property="FontSize" Value="14" />
        <Setter Property="Background" Value="White" />
        <Setter Property="Foreground" Value="Black" />
        <Setter Property="BorderBrush" Value="#DDD" />
        <Setter Property="BorderThickness" Value="1" />
        <Setter Property="Height" Value="30" />
        <Setter Property="Width" Value="30" />
        <Setter Property="Margin" Value="2" />
        <Setter Property="Cursor" Value="Hand" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Border
                        Background="{TemplateBinding Background}"
                        BorderBrush="{TemplateBinding BorderBrush}"
                        BorderThickness="{TemplateBinding BorderThickness}"
                        CornerRadius="4">
                        <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="#1083FF" />
                            <Setter Property="Foreground" Value="White" />
                        </Trigger>
                        <Trigger Property="IsPressed" Value="True">
                            <Setter Property="Background" Value="#0B63D7" />
                            <Setter Property="Foreground" Value="White" />
                        </Trigger>
                        <Trigger Property="IsEnabled" Value="False">
                            <Setter Property="Background" Value="#EEE" />
                            <Setter Property="Foreground" Value="#AAA" />
                            <Setter Property="Cursor" Value="Arrow" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>

</ResourceDictionary>

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
