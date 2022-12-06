using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEmergencia.AppLayout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterProjectionPage : MasterDetailPage
    {
        public MasterProjectionPage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    App.Navigator = Navigator;
        //    App.Master = this;
        //}
    }
}
