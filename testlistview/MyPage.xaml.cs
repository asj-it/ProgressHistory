using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace testlistview
{
    public partial class MyPage : ScrollView
    {
        string[] images;

        public MyPage()
        {
            InitializeComponent();

            images = new [] { "Blue", "Green", "Orange", "LightBlue", "LightGreen", "Navy" };

            int col = 0;
            int row = 0;
            int image = 0;

            var random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 30; i++)
            {
                DateTime date = DateTime.Today.AddDays(i * -1);
                    
                Grid.Children.Add(new StepHistoryView { HeightRequest= 120, WidthRequest = 120, StepDate = date, StrokeWidth = 5, Padding = 10, Steps = random.Next(125, 18999), TargetSteps = 10000  }, col, row);
                col = NextCol(col, ref row);
                image = NextImage(image);
            }
        }

        private int NextImage(int img)
        {
            return ++img == images.Length ? 0 : img;
        }

        private int NextCol(int col, ref int row)
        {
            if (++col == Grid.ColumnDefinitions.Count)
            {
                ++row;
                return 0;
            }

            return col;
        }
    }
}

