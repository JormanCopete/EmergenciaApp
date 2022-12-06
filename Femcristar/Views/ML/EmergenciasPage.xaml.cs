using Xamarin.Forms;

namespace AppEmergencia.Views.ML
{
    public partial class EmergenciasPage : ContentPage
    {
        public EmergenciasPage()
        {
            InitializeComponent();
            //MessagingCenter.Subscribe<MenuViewModel>(this, "CopBalancesPage", (a) =>
            //{
            //    //Application.Current.MainPage.Navigation.PushAsync(new CopBalancePage());
            //    Application.Current.MainPage = new NavigationPage(new CopBalancePage());

            //});
            //MessagingCenter.Subscribe<MenuViewModel>(this, "Login", (a) =>
            //{
            //    //Application.Current.MainPage.Navigation.PushAsync(new MyPage1());
            //    Application.Current.MainPage = new NavigationPage(new MyPage1());
            //});
        }
    }
}
