using AppEmergencia.AppLayout.Views;
using AppEmergencia.Views.General;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppEmergencia.Services
{
    public class NavigationService
    {
        public static void SetMainPage(string pageName)
        {

            switch (pageName)
            {
                //case "Login":
                //    Application.Current.MainPage = new NavigationPage(new Login());
                //    break;
                //case "MasterPage":
                //    Application.Current.MainPage = new NavigationPage(new MasterPage());
                //    break;
                //case "MasterProjectionPage":
                //    Application.Current.MainPage = new NavigationPage(new MasterProjectionPage());
                //    break;
                //case "CopSimulatorPage":
                //    Application.Current.MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, "#713d74");
                //    Application.Current.MainPage = new NavigationPage(new CopSimulatorPage());
                //    break;
            }
        }


        public static async Task NavigateOnMaster(string pageName)
        {
            App.Master.IsPresented = false;
            

            switch (pageName)
            {
                //case "MasterPage":
                //    await App.Navigator.PushAsync(new MasterPage());
                //    break;
                //case "MenuPage":
                //    await App.Navigator.PushAsync(new MenuPage());
                //    break;
                //case "Login":
                //    await App.Navigator.PushAsync(new Login());
                //    break;
                //case "CopBalancePage":
                //    await App.Navigator.PushAsync(new CopBalancePage());
                //    break;
                //case "CopSimulatorPage":
                //    await App.Navigator.PushAsync(new CopSimulatorPage());
                //    break;
                   
                //default:
                //    await App.Navigator.PushAsync(new MasterPage());
                //    break;
            }

        }


        public static async Task NavigateOnMaster(string pageName, object item)
        {
            //App.Master.IsPresented = false;
            

            switch (pageName)
            {
                case "CopBalanceDetailPage":
                    //await App.Navigator.PushAsync(new CopBalanceDetailPage((CopBalanceModel)item));
                    break;               
               
                default:
                    await App.Navigator.PushAsync(new MasterPage());
                    break;
            }

        }

        public static async Task NavigateOnLogin(string pageName)
        {
            switch (pageName)
            {
                //case "Login":
                //    await Application.Current.MainPage.Navigation.PushAsync(new Login());
                //    break;
                //case "CodeVerificationPage":
                //    await Application.Current.MainPage.Navigation.PushAsync(new CodeVerificationPage());
                //    break;
                //case "SetPasswordPage":
                //    await Application.Current.MainPage.Navigation.PushAsync(new SetPasswordPage());
                //    break;
                //case "RecoveryPasswordPage":
                //    await Application.Current.MainPage.Navigation.PushAsync(new RecoveryPasswordPage());
                //    break;
                ////case "sysTermsAndConditions":
                ////    await Application.Current.MainPage.Navigation.PushAsync(new sysTermsAndConditions());
                ////    break;
                //default:
                //    await Application.Current.MainPage.Navigation.PushAsync(new Login());
                //    break;
            }
        }


        public static async Task BackOnMaster()
        {
            await App.Navigator.PopAsync();
            //await Application.Current.MainPage.Navigation.PopAsync();
        }

        public static async Task BackOnLogin()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
