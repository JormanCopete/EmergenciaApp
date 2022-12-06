using AppEmergencia.AppLayout.Views;
using AppEmergencia.Views.ML;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace AppEmergencia
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }

        public static MasterPage Master
        {
            get;
            internal set;
        }

        public App()
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQzMDY3QDMxMzgyZTMxMmUzMEpFSW5oSkhTSlh0OHBTSVc4NTZ3dXQzaWxNRC9lYzdLNHJaWHQ0QjY0WE09");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDE2NDc4QDMxMzgyZTM0MmUzMGtueUpOVXZHWHlSNkRzWVhBdzdCV1RJdW0wby8yT24xWTBRS1UxOVBFbTg9");

            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new Login());
            //MainPage = new EmergenciasPage();
            MainPage = new NavigationPage(new EmergenciasPage());
        }

        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
