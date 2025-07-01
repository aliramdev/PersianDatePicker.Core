# PersianDatePicker.Core.Wpf

![NuGet Version](https://img.shields.io/nuget/v/PersianDatePicker.Core.Wpf?color=blue)
![Downloads](https://img.shields.io/nuget/dt/PersianDatePicker.Core.Wpf?color=green)
![License](https://img.shields.io/github/license/aliramdev/PersianDatePicker.Core?color=orange)

## کنترل تقویم شمسی DatePicker برای WPF

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
<ctrls:PersianDatePicker
    x:Name="MyDatePicker" DayButtonStyle="{StaticResource DefaultDayButtonStyle}" SelectedDate="{Binding MyDate}"/>
```

## الگوی استایل دهی

```xml
<Style x:Key="PersianDatePickerStyle" TargetType="ctrls:PersianDatePicker">
    <Setter Property="Background" Value="White" />
    <Setter Property="BorderBrush" Value="#DDDDDD" />
    <Setter Property="BorderThickness" Value="1" />
    <Setter Property="Padding" Value="6" />
    <Setter Property="Height" Value="36" />
    <Setter Property="FontSize" Value="14" />
    <Setter Property="Foreground" Value="#333" />
    <Setter Property="PopupBackground" Value="LightYellow" />
    <!--  جدید  -->
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="ctrls:PersianDatePicker">
                <Grid>
                    <Border
                        x:Name="Bd"
                        Background="{TemplateBinding Background}"
                        BorderBrush="{TemplateBinding BorderBrush}"
                        BorderThickness="{TemplateBinding BorderThickness}"
                        CornerRadius="6">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition />
                                <ColumnDefinition Width="Auto" />
                            </Grid.ColumnDefinitions>

                            <!--  نمایش تاریخ  -->
                            <TextBox
                                x:Name="PART_TextBox"
                                Grid.Column="0"
                                Padding="2,0"
                                VerticalContentAlignment="Center"
                                Background="Transparent"
                                BorderThickness="0"
                                FontFamily="{TemplateBinding FontFamily}"
                                FontSize="{TemplateBinding FontSize}"
                                Foreground="{TemplateBinding Foreground}"
                                IsReadOnly="True" />

                            <!--  دکمه باز شدن تقویم  -->
                            <Button
                                x:Name="PART_Button"
                                Grid.Column="1"
                                Width="30"
                                Margin="4,0,4,0"
                                Background="Transparent"
                                BorderThickness="0"
                                ToolTip="باز کردن تقویم">
                                <Path
                                    HorizontalAlignment="Center"
                                    VerticalAlignment="Center"
                                    Data="M7,10 L10,14 L14,8"
                                    Stretch="Uniform"
                                    Stroke="{TemplateBinding Foreground}"
                                    StrokeThickness="2" />
                            </Button>
                        </Grid>
                    </Border>

                    <!--  🔽 پاپ‌آپ تقویم  -->
                    <Popup
                        x:Name="PART_Popup"
                        AllowsTransparency="True"
                        Placement="Bottom"
                        StaysOpen="False">
                        <Border
                            Margin="0,4,0,0"
                            Background="{TemplateBinding PopupBackground}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="1"
                            CornerRadius="6">
                            <ctrls:ShamsiCalendarControl x:Name="PART_Calendar" />
                        </Border>
                    </Popup>
                </Grid>

                <ControlTemplate.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter TargetName="Bd" Property="BorderBrush" Value="#1083FF" />
                    </Trigger>
                    <Trigger Property="IsEnabled" Value="False">
                        <Setter TargetName="Bd" Property="Background" Value="#F2F2F2" />
                        <Setter TargetName="Bd" Property="BorderBrush" Value="#CCC" />
                        <Setter Property="Foreground" Value="#888" />
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>

<Color x:Key="AppBackgroundColor">#FF1E1E1E</Color>
<Color x:Key="AppForegroundColor">#FFF1F1F1</Color>
<Color x:Key="AppBorderColor">#FF444444</Color>
<Color x:Key="AppHighlightColor">#FF3C82F6</Color>
<Color x:Key="AppAccentColor">#FF007ACC</Color>

<SolidColorBrush x:Key="DefaultBackgroundBrush" Color="{StaticResource AppBackgroundColor}" />
<SolidColorBrush x:Key="DefaultForegroundBrush" Color="{StaticResource AppForegroundColor}" />
<SolidColorBrush x:Key="DefaultBorderBrush" Color="{StaticResource AppBorderColor}" />
<SolidColorBrush x:Key="HighlightBrush" Color="{StaticResource AppHighlightColor}" />
<SolidColorBrush x:Key="AccentBrush" Color="{StaticResource AppAccentColor}" />

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
