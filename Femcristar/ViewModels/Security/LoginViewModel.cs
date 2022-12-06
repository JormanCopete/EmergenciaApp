using AppEmergencia.Models;
using AppEmergencia.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppEmergencia.ViewModels.Security
{
    public class LoginViewModel : BaseViewModel //: LoginNuipViewModel
    {
        #region Fields
        private ApiService apiService;
        private string nuip;
        private Boolean loginIsRunning;
        private string password;
        private Boolean FirstTime;
        private bool tokenValid;
        private bool isInvalidNuip;


        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginViewModel()
        {
            this.LoginCommand = new Command(this.LoginClickedAsync);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.apiService = new ApiService();
        }


        #endregion

        #region property
        public string Nuip
        {
            get
            {
                return this.nuip;
            }

            set
            {
                if (this.nuip == value)
                {
                    return;
                }

                this.nuip = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the entered nuip is valid or invalid.
        /// </summary>
        public bool IsInvalidNuip
        {
            get
            {
                return this.isInvalidNuip;
            }

            set
            {
                if (this.isInvalidNuip == value)
                {
                    return;
                }

                this.isInvalidNuip = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.NotifyPropertyChanged();
            }
        }

        public Boolean LoginIsRunning
        {
            get { return this.loginIsRunning; }
            set
            {
                this.loginIsRunning = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get ; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        #endregion

        #region methods

        private async void RecoveryKey()
        {
            await NavigationService.NavigateOnLogin("sysRecoveryKeyPage");
        }

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void LoginClickedAsync(object obj)
        {
            // Do something
            //App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new MainPage()));
            //App.Current.MainPage = new NavigationPage(new MainPage());
            this.LoginIsRunning = true;
            if (string.IsNullOrEmpty(this.Nuip))
            {
                this.LoginIsRunning = false;
                //this.LoginIsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "No ha digitado su número de documento", "Aceptar");
                //this.NumDocumento = "12";
                return;
            }


            //#$#$#$#$$#$# AQUI DEBE VALIDAR LO SIGUIENTE:
            // Que el documento existe en la base de datos y traer el usuario, el indicar si ya tiene clave asigna y el campo de la clave
            //Si el usuario No existe, mostrar la alerta de que el usuario no existe
            //Si el usuario Existe se hace lo siguiente
            // 1. Si el indicador dice que NO tiene clave asignada, se debe enviar a la pagina de asignacion de clave 
            // 2. Si el indicador dice que SI tiene clave asignada, se debe enviar a la pagina staClavePage para que digite la clave
            //await Application.Current.MainPage.DisplayAlert("Wow", "Very fine", "Aceptar");


            if (await LoadUserAsync() == true)
            {
                //if (LoginIsToggled)
                //{
                //    Settings.RememberId = true;
                //    Settings.LoginId = Nuip;
                //}

                MainStatic.UserNuip = Nuip;
                if (!FirstTime)
                {
                    if (!tokenValid)
                        await Application.Current.MainPage.DisplayAlert("Información", $"Hola {MainStatic.UserName}, El password digitado no es correcto. Intentelo de nuevo", "Aceptar");
                    else
                        NavigationService.SetMainPage("MasterPage");
                        //Application.Current.MainPage = new MasterPage();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Información", $"Hola {MainStatic.UserName}, Debe establecer su password por primera vez", "Aceptar");
                    await NavigationService.NavigateOnLogin("RecoveryPasswordPage");
                    //CodigoRegistroViewModel.StrTitulo = "Registro de clave por primera vez";
                    //await Application.Current.MainPage.DisplayAlert("Informacion", "Le enviaremos un mensaje al correo electrónico que tiene asociado con nosostros, para que registre su clave por primera vez", "Aceptar");
                    //await NavigationService.NavigateOnLogin("staCodigoRegistroPage");  
                }
            }
            this.LoginIsRunning = false;
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;

            await NavigationService.NavigateOnLogin("RecoveryPasswordPage");
        }


        #endregion

       
        private async Task<bool> LoadUserAsync()
        {
            //var connection = await this.apiService.CheckConnection();
            //FirstTime = false;
            //tokenValid = false;

            //if (!connection.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
            //    return false;
            //}

            //var response = await this.apiService.GetUserToken<GenUserToken>(MainStatic.UrlBase, Nuip, Password);


            //if (response == null)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo realizar la conexión, por favor intente nuevamente", "Aceptar");
            //    return false;
            //}
            //else
            //{
            //    if (response.Result != null)
            //    {
            //        var userToken = (GenUserToken)response.Result;

            //        MainStatic.UserNuip = Nuip;
            //        MainStatic.UserName = userToken.genAssociatedUserDto.Ssfirstname;
            //        MainStatic.Period = int.Parse(DateTime.Now.ToString("yyyyMM")); // 202108;
            //        if (userToken.genAssociatedUserDto.Sfstate != "AC")
            //        {
            //            await Application.Current.MainPage.DisplayAlert("Error", "Usuario ingresado se encuentra inactivo, por favor comuníquese con el administrador", "Aceptar");
            //            return false;
            //        }
            //        else if (userToken.genAssociatedUserDto.Sspasswordstate == "0")
            //        {
            //            FirstTime = true;
            //        }
            //        if(!string.IsNullOrEmpty(userToken.token))
            //        {
            //            tokenValid = true;
            //            MainStatic.Token = userToken.token;
            //        }
            //    }
            //    else
            //    {
            //        if(!string.IsNullOrEmpty(response.Message))
            //            await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");

            //        else
            //            await Application.Current.MainPage.DisplayAlert("Error", "Usuario ingresado no existe, por favor intente nuevamente", "Aceptar");

            //        return false;
            //    }
            //}



            return true;

        }
    }
}
