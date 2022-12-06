using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppEmergencia.Models.General;
using AppEmergencia.Services;
using Xamarin.Forms;

namespace AppEmergencia.ViewModels.General
{
    public class MenuViewModel : BaseViewModel
    {
        private ObservableCollection<MenuModel> miMenu;
        public ObservableCollection<MenuModel> MyMenu
        {
            get { return miMenu; }
            set
            {
                miMenu = value;
                NotifyPropertyChanged();
            }
        }

        public MenuModel selectedMenu;
        public MenuModel SelectedMenu
        {
            get { return selectedMenu; }
            set
            {
                selectedMenu = value;
                NotifyPropertyChanged();
            }
        }

        //public ICommand NavigateCommand
        //{
        //    get
        //    {
        //        return new Command(Navigate);
        //    }
        //}

        public MenuViewModel()
        {
            LoadMenu();

            PropertyChanged += MenuViewModel_PropertyChanged;
        }

        private void MenuViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(SelectedMenu))
            {
                Navigate(SelectedMenu.PageName);
                //if(SelectedMenu.PageName == "CopBalancesPage")
                //{
                //    MessagingCenter.Send(this, "CopBalancesPage");
                //}
                //if (SelectedMenu.PageName == "Login")
                //{
                //    MessagingCenter.Send(this, "Login");
                //}
            }
        }

        private void ItemSelected(object selectedItem)
        {
            // Do something
            Navigate(selectedItem.ToString());
        }

        private void LoadMenu()
        {
            MyMenu = new ObservableCollection<MenuModel>();

            MyMenu.Add(new MenuModel
            {
                Icon = "ic_waller",
                PageName = "CopBalancePage",
                Title = "Llamados de Emergencia",
            });

            MyMenu.Add(new MenuModel
            {
                Icon = "ic_projection",
                PageName = "CopSimulatorPage",
                Title = "Detalle llamados",
            });

            MyMenu.Add(new MenuModel
            {
                Icon = "ic_exitsesion",
                PageName = "Login",
                Title = "Cerrar sesión",
            });

            
            //MyMenu.Add(new MenuModel
            //{
            //    Icon = "ic_projection",
            //    PageName = "copSimulatorPage",
            //    Title = "Simulador de crédito",
            //});

            //MyMenu.Add(new MenuModel
            //{
            //    Icon = "ic_linecatalog",
            //    PageName = "copLineCatalogPage",
            //    Title = "Conceptos y servicios",
            //});

            //MyMenu.Add(new MenuModel
            //{
            //    Icon = "ic_news",
            //    PageName = "sysNewsPage",
            //    Title = "Noticias",
            //});

            //MyMenu.Add(new Menu
            //{
            //    Icon = "ic_account_balance_wallet",
            //    PageName = "sysMessagesPage",
            //    Title = "Notificaciones y mensajes",
            //});

            //MyMenu.Add(new Menu
            //{
            //    Icon = "ic_account_balance_wallet",
            //    PageName = "sysMessagesPage",
            //    Title = "Cambiar de entidad",
            //});

            //MyMenu.Add(new MenuModel
            //{
            //    Icon = "ic_contact",
            //    PageName = "sysContactPage",
            //    Title = "Contactenos",
            //});



            //Dentro de la opcion de configuracion, permitir cambiar la clave y editar algunos datos??
            //MyMenu.Add(new Menu
            //{
            //    Icon = "ic_launcher",
            //    PageName = "sysConfigurationPage",
            //    Title = "Configuración",
            //});

        }


        private void Navigate(string PageName)
        {
            switch (PageName)
            {
                case "Login":
                    //Settings.Token = string.Empty;
                    //Settings.TokenType = string.Empty;

                    //MainAppViewModel.Token = string.Empty;
                    //MainAppViewModel.TokenType = string.Empty;
                    ////MainAppViewModel.Period =0;
                    ////MainAppViewModel.IdClientActivo = string.Empty;

                    NavigationService.SetMainPage("Login");
                    break;

                case "CopBalancePage":
                    NavigationService.SetMainPage("MasterPage");
                    //NavigationService.NavigateOnMaster("CopBalancePage");
                    break;
                case "CopSimulatorPage":
                    NavigationService.SetMainPage("MasterProjectionPage");
                    //NavigationService.NavigateOnMaster("CopSimulatorPage");
                    break;
                case "MasterPage":
                    NavigationService.NavigateOnMaster("MasterPage");
                    break;
                case "MenuPage":
                    NavigationService.NavigateOnMaster("MenuPage");
                    break;
            }
        }
    }
}
