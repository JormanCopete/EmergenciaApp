using System;
using System.Windows.Input;
using AppEmergencia.Services;
using Xamarin.Forms;

namespace AppEmergencia.Models.General
{
    public class MenuModel
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        public ICommand NavigateCommand
        {
            get
            {
                return new Command(Navigate);
            }
        }

        private void Navigate()
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
                    NavigationService.NavigateOnMaster("CopBalancePage");
                    break;
                case "MasterPage":
                    NavigationService.NavigateOnMaster("MasterPage");
                    break;
                case "MenuPage":
                    NavigationService.NavigateOnMaster("MenuPage");
                    break;
                //case "copBalanceTabPage":
                //    NavigationService.NavigateOnMaster("copBalanceTabPage");
                //    break;
                //case "copSimulatorPage":
                //    NavigationService.NavigateOnMaster("copSimulatorPage");
                //    break;
                //case "copLineCatalogPage":
                //    NavigationService.NavigateOnMaster("copLineCatalogPage");
                //    break;
                //case "sysNewsPage":
                //    NavigationService.NavigateOnMaster("sysNewsPage");
                //    break;
                //case "sysMessagesPage":
                //    NavigationService.NavigateOnMaster("sysMessagesPage");
                //    break;
                //case "sysContactPage":
                //    NavigationService.NavigateOnMaster("sysContactPage");
                //    break;
                //case "sysConfigurationPage":
                //    NavigationService.NavigateOnMaster("sysConfigurationPage");
                //    break;

            }
        }
    }
}
