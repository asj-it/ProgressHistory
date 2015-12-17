using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace testlistview
{
    public partial class MyBudgetView : ContentPage
    {
        public MyBudgetView()
        {
            InitializeComponent();

            var data = new ObservableCollection<Payment>();
            data.Add(new Payment { Description = "Wages", Amount= 1234.44, PayDate = DateTime.Today.AddDays(2),  RunningTotal = 1234 });
            data.Add(new Payment { Description = "Rent", Amount= -500, PayDate = DateTime.Today.AddDays(2),  RunningTotal = 850 });
            data.Add(new Payment { Description = "Food", Amount= 40, PayDate = DateTime.Today.AddDays(3),  RunningTotal = 810 });
            data.Add(new Payment { Description = "TV", Amount= 65, PayDate = DateTime.Today.AddDays(2),  RunningTotal = 735 });
            data.Add(new Payment { Description = "Petrol", Amount= 300, PayDate = DateTime.Today.AddDays(2),  RunningTotal = 435 });
            data.Add(new Payment { Description = "Bonus", Amount= 1000, PayDate = DateTime.Today.AddDays(4),  RunningTotal = 2435 });
            data.Add(new Payment { Description = "Car Ins", Amount= 23, PayDate = DateTime.Today.AddDays(6),  RunningTotal = 2312 });
            data.Add(new Payment { Description = "Petrol", Amount= 300, PayDate = DateTime.Today.AddDays(7),  RunningTotal = 435 });
            data.Add(new Payment { Description = "Bonus", Amount= 1000, PayDate = DateTime.Today.AddDays(9),  RunningTotal = 2435 });
            data.Add(new Payment { Description = "Car Ins", Amount= 23, PayDate = DateTime.Today.AddDays(9),  RunningTotal = 2312 });

            BudgetListView.ItemsSource = data;
            BudgetListView.RowHeight = 100;
        }
    }
}

