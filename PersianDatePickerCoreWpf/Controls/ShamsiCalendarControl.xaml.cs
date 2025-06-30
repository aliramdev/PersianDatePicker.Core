using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PersianDatePicker_Core_Wpf.Controls
{
    public partial class ShamsiCalendarControl : UserControl
    {
        public event Action<DateTime?> DateSelected;

        private readonly PersianCalendar _calendar = new PersianCalendar();
        private DateTime _currentDate;
        private DateTime? _selectedDate;
        private ViewMode _currentView = ViewMode.Day;
        private bool _isAnimating = false;

        public ShamsiCalendarControl()
        {
            InitializeComponent();

            _currentDate = DateTime.Today;
            _selectedDate = null;

            Loaded += (s, e) =>
            {
                RenderView();

                PrevMonthBtn.Click += (s2, e2) => Navigate(-1);
                NextMonthBtn.Click += (s2, e2) => Navigate(1);

                TodayButton.Click += (s2, e2) =>
                {
                    _currentDate = DateTime.Today;
                    _selectedDate = DateTime.Today;
                    _currentView = ViewMode.Day;
                    AnimateViewChange();
                    DateSelected?.Invoke(_selectedDate);
                };

                ClearButton.Click += (s2, e2) =>
                {
                    _selectedDate = null;
                    DateSelected?.Invoke(null);
                    _currentView = ViewMode.Day;
                    AnimateViewChange();
                };

                MonthYearText.MouseLeftButtonDown += (s2, e2) => ToggleView();

                // اینجا هندلر دکمه SwitchViewButton وصل می‌شود
                SwitchViewButton.Click += (s2, e2) => ToggleView();
            };
        }

        private void ToggleView()
        {
            if (_isAnimating) return;

            _currentView = _currentView switch
            {
                ViewMode.Day => ViewMode.Month,
                ViewMode.Month => ViewMode.Year,
                _ => ViewMode.Day
            };

            AnimateViewChange();
        }

        private void Navigate(int offset)
        {
            if (_isAnimating) return;

            switch (_currentView)
            {
                case ViewMode.Day:
                    _currentDate = _currentDate.AddMonths(offset);
                    break;
                case ViewMode.Month:
                    _currentDate = _currentDate.AddYears(offset);
                    break;
                case ViewMode.Year:
                    _currentDate = _currentDate.AddYears(offset * 12);
                    break;
            }

            AnimateViewChange();
        }

        private void AnimateViewChange()
        {
            _isAnimating = true;

            var fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(150));
            fadeOut.Completed += (s, e) =>
            {
                RenderView();
                var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(150));
                fadeIn.Completed += (s2, e2) => _isAnimating = false;
                DaysGrid.BeginAnimation(OpacityProperty, fadeIn);
            };

            DaysGrid.BeginAnimation(OpacityProperty, fadeOut);
        }

        private void RenderView()
        {
            DaysGrid.Children.Clear();
            DaysGrid.Columns = 7;

            switch (_currentView)
            {
                case ViewMode.Day:
                    RenderDayView();
                    break;
                case ViewMode.Month:
                    RenderMonthView();
                    break;
                case ViewMode.Year:
                    RenderYearView();
                    break;
            }
        }

        private void RenderDayView()
        {
            int year = _calendar.GetYear(_currentDate);
            int month = _calendar.GetMonth(_currentDate);
            MonthYearText.Text = GetPersianMonthName(month) + " " + year;

            DateTime firstDay = _calendar.ToDateTime(year, month, 1, 0, 0, 0, 0);
            int startOffset = ((int)_calendar.GetDayOfWeek(firstDay) + 1) % 7;
            int daysInMonth = _calendar.GetDaysInMonth(year, month);

            for (int i = 0; i < startOffset; i++)
                DaysGrid.Children.Add(new TextBlock());

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime current = _calendar.ToDateTime(year, month, day, 0, 0, 0, 0);

                var btn = new Button
                {
                    Content = day.ToString(),
                    Margin = new Thickness(2),
                    Tag = current,
                    Padding = new Thickness(6),
                    Background = Brushes.Transparent,
                    BorderBrush = Brushes.LightGray,
                    BorderThickness = new Thickness(1),
                    FontWeight = FontWeights.Normal
                };

                if (_selectedDate.HasValue && current.Date == _selectedDate.Value.Date)
                {
                    btn.Background = (Brush)TryFindResource("CalendarDayHighlight") ?? Brushes.DeepSkyBlue;
                    btn.Foreground = Brushes.White;
                    btn.FontWeight = FontWeights.Bold;
                }
                else if (current.Date == DateTime.Today.Date)
                {
                    btn.Background = (Brush)TryFindResource("TodayBackground") ?? Brushes.LightBlue;
                    btn.FontWeight = FontWeights.Bold;
                }

                btn.Click += (s, e) =>
                {
                    _selectedDate = current;
                    DateSelected?.Invoke(current);
                    AnimateViewChange();
                };

                DaysGrid.Children.Add(btn);
            }
        }

        private void RenderMonthView()
        {
            DaysGrid.Columns = 3;

            int year = _calendar.GetYear(_currentDate);
            MonthYearText.Text = year.ToString();
            string[] months = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

            for (int i = 0; i < 12; i++)
            {
                var btn = new Button
                {
                    Content = months[i],
                    Tag = i + 1,
                    Margin = new Thickness(4),
                    Padding = new Thickness(8),
                    FontWeight = FontWeights.Normal
                };

                int currentMonth = _calendar.GetMonth(_currentDate);
                if (currentMonth == i + 1)
                {
                    btn.Background = (Brush)TryFindResource("TodayBackground") ?? Brushes.LightBlue;
                    btn.FontWeight = FontWeights.Bold;
                }

                btn.Click += (s, e) =>
                {
                    int selectedMonth = (int)((Button)s).Tag;
                    _currentDate = _calendar.ToDateTime(year, selectedMonth, 1, 0, 0, 0, 0);
                    _currentView = ViewMode.Day;
                    AnimateViewChange();
                };

                DaysGrid.Children.Add(btn);
            }
        }

        private void RenderYearView()
        {
            DaysGrid.Columns = 4;

            int centerYear = _calendar.GetYear(_currentDate);
            int startYear = centerYear - (centerYear % 12);
            MonthYearText.Text = $"{startYear} - {startYear + 11}";

            for (int i = 0; i < 12; i++)
            {
                int y = startYear + i;
                var btn = new Button
                {
                    Content = y.ToString(),
                    Tag = y,
                    Margin = new Thickness(4),
                    Padding = new Thickness(8)
                };

                if (y == centerYear)
                {
                    btn.Background = (Brush)TryFindResource("TodayBackground") ?? Brushes.LightBlue;
                    btn.FontWeight = FontWeights.Bold;
                }

                btn.Click += (s, e) =>
                {
                    int selectedYear = (int)((Button)s).Tag;
                    int month = _calendar.GetMonth(_currentDate);
                    _currentDate = _calendar.ToDateTime(selectedYear, month, 1, 0, 0, 0, 0);
                    _currentView = ViewMode.Month;
                    AnimateViewChange();
                };

                DaysGrid.Children.Add(btn);
            }
        }

        private static string GetPersianMonthName(int month)
        {
            string[] months =
            {
                "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
                "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
            };
            return months[Math.Max(0, Math.Min(11, month - 1))];
        }

        private enum ViewMode
        {
            Day,
            Month,
            Year
        }
    }
}
