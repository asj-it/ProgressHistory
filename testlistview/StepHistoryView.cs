using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace testlistview
{

    public class StepHistoryView : BoxView
    {
        public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create<StepHistoryView, Color>(s => s.StrokeColor, Color.Default);

        public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create<StepHistoryView, float>(s => s.StrokeWidth, 1f);

        public static readonly BindableProperty IndicatorPercentageProperty = BindableProperty.Create<StepHistoryView, float>(s => s.IndicatorPercentage, 0f);
        public static readonly BindableProperty StepsProperty = BindableProperty.Create<StepHistoryView, float>(s => s.Steps, 0f);
        public static readonly BindableProperty TargetProperty = BindableProperty.Create<StepHistoryView, float>(s => s.TargetSteps, 0f);

        public static readonly BindableProperty StepDateProperty = BindableProperty.Create<StepHistoryView, DateTime>(s => s.StepDate, DateTime.Today);

        public static readonly BindableProperty StepDateStringProperty = BindableProperty.Create<StepHistoryView, string>(s => s.DateString, DateTime.Today.ToString("dd MMM"));

        public static readonly BindableProperty PaddingProperty = BindableProperty.Create<StepHistoryView, Thickness>(s => s.Padding, default(Thickness));

        public Color StrokeColor
        {
            get{ 

                if (Steps >= TargetSteps)
                    return Color.Green;

                if (Steps >= (TargetSteps / 2))
                    return Color.Yellow;

                return Color.Red;
            }
        }

        public string DateString 
        {
            get
            {
                return (string)GetValue(StepDateStringProperty);
            }
        }

        public float StrokeWidth
        {
            get{ return (float)GetValue(StrokeWidthProperty); }
            set{ SetValue(StrokeWidthProperty, value); }
        }

        public DateTime StepDate
        {
            get{ return (DateTime)GetValue(StepDateProperty); }
            set
            { 
                SetValue(StepDateProperty, value); 

                var startOfWeek = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek) * -1);

                var dateString = startOfWeek < value ? value.ToString("ddd") : value.ToString("MMM dd");

                SetValue(StepDateStringProperty, dateString);
            }
        }

        public float Steps
        {
            get{ return (float)GetValue(StepsProperty); }
            set
            {
                SetValue(StepsProperty, value);
            }
        }

        public float TargetSteps
        {
            get{ return (float)GetValue(TargetProperty); }
            set
            {
                SetValue(TargetProperty, value);
            }
        }

        public float IndicatorPercentage
        {
            get{ return Steps/TargetSteps > 0.99 ? 1 : Steps/TargetSteps; }
        }

        public Thickness Padding
        {
            get{ return (Thickness)GetValue(PaddingProperty); }
            set{ SetValue(PaddingProperty, value); }
        }

        public StepHistoryView()
        {
        }
    }
}