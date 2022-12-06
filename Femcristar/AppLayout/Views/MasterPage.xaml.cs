using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEmergencia.AppLayout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Navigator = Navigator;
            App.Master = this;
        }
    }
}
