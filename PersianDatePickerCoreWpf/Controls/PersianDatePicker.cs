using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace PersianDatePicker_Core_Wpf.Controls
{
    [TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_Button", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
    [TemplatePart(Name = "PART_Calendar", Type = typeof(ShamsiCalendarControl))]
    public class PersianDatePicker : Control
    {
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register(
                nameof(SelectedDate),
                typeof(DateTime?),
                typeof(PersianDatePicker),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public DateTime? SelectedDate
        {
            get => (DateTime?)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

        public static readonly DependencyProperty CalendarStyleProperty =
            DependencyProperty.Register(
                nameof(CalendarStyle),
                typeof(Style),
                typeof(PersianDatePicker),
                new PropertyMetadata(null));

        public Style CalendarStyle
        {
            get => (Style)GetValue(CalendarStyleProperty);
            set => SetValue(CalendarStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register(
                nameof(ButtonStyle),
                typeof(Style),
                typeof(PersianDatePicker),
                new PropertyMetadata(null));

        public Style ButtonStyle
        {
            get => (Style)GetValue(ButtonStyleProperty);
            set => SetValue(ButtonStyleProperty, value);
        }

        public static readonly DependencyProperty TextBoxStyleProperty =
            DependencyProperty.Register(
                nameof(TextBoxStyle),
                typeof(Style),
                typeof(PersianDatePicker),
                new PropertyMetadata(null));

        public Style TextBoxStyle
        {
            get => (Style)GetValue(TextBoxStyleProperty);
            set => SetValue(TextBoxStyleProperty, value);
        }

        public static readonly DependencyProperty DayButtonStyleProperty =
            DependencyProperty.Register(
                nameof(DayButtonStyle),
                typeof(Style),
                typeof(PersianDatePicker),
                new PropertyMetadata(null));

        public Style DayButtonStyle
        {
            get => (Style)GetValue(DayButtonStyleProperty);
            set => SetValue(DayButtonStyleProperty, value);
        }

        static PersianDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PersianDatePicker),
                new FrameworkPropertyMetadata(typeof(PersianDatePicker)));
        }

        private TextBox _textBox;
        private Button _button;
        private Popup _popup;
        private ShamsiCalendarControl _calendar;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _textBox = GetTemplateChild("PART_TextBox") as TextBox;
            _button = GetTemplateChild("PART_Button") as Button;
            _popup = GetTemplateChild("PART_Popup") as Popup;
            _calendar = GetTemplateChild("PART_Calendar") as ShamsiCalendarControl;

            if (_textBox != null && TextBoxStyle != null)
                _textBox.Style = TextBoxStyle;

            if (_button != null)
            {
                if (ButtonStyle != null)
                    _button.Style = ButtonStyle;

                _button.Click += (s, e) =>
                {
                    if (_popup != null)
                        _popup.IsOpen = !_popup.IsOpen;
                };
            }

            if (_calendar != null)
            {
                if (CalendarStyle != null)
                    _calendar.Style = CalendarStyle;

                if (DayButtonStyle != null)
                    _calendar.DayButtonStyle = DayButtonStyle;

                _calendar.DateSelected += date =>
                {
                    SelectedDate = date;
                    if (_popup != null) _popup.IsOpen = false;
                };
            }
        }

        public static readonly DependencyProperty PopupBackgroundProperty =
    DependencyProperty.Register(
        nameof(PopupBackground),
        typeof(Brush),
        typeof(PersianDatePicker),
        new PropertyMetadata(Brushes.White));

        public Brush PopupBackground
        {
            get => (Brush)GetValue(PopupBackgroundProperty);
            set => SetValue(PopupBackgroundProperty, value);
        }

    }

}