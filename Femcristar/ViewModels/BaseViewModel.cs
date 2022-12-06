using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace AppEmergencia.ViewModels
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
