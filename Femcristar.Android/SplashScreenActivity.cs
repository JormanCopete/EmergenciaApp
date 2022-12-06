using Android.App;
using Android.OS;
using Android.Views;

namespace AppEmergencia.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
              MainLauncher = true,
              NoHistory = true)]
    //, Icon = "@drawable/icon")]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            //Window.DecorView.SystemUiVisibility = (StatusBarVisibility)((int)Window.DecorView.SystemUiVisibility ^ (int)SystemUiFlags.LayoutStable ^ (int)SystemUiFlags.LayoutFullscreen);
#pragma warning restore CS0618 // Type or member is obsolete
            //Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            //Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            base.OnCreate(bundle);
            //System.Threading.Thread.Sleep(1000);
            this.StartActivity(typeof(MainActivity));
        }
    }
}