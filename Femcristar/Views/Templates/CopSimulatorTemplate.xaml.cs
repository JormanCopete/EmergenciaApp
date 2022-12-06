using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace AppEmergencia.Views.Templates
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CopSimulatorTemplate : Grid
    {
        public CopSimulatorTemplate()
        {
            InitializeComponent();
        }
    }
}
