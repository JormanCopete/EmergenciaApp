using AppEmergencia.Models;
using AppEmergencia.Models.ML;
using AppEmergencia.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Net;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppEmergencia.ViewModels.ML
{
    public class emergencia_resumenViewModel : BaseViewModel
    {
        private SerialPort serialPort;
        private ApiService apiService;
        private Boolean loadBalanceIsRunning;
        private Boolean isRefreshing;
        private ObservableCollection<emergencia_resumenModel> emergencia_resumenModels;
        public string mayorLabel { get; set; }
        public decimal mayorValor { get; set; }

        public decimal MayorValor
        {
            get { return mayorValor; }
            set
            {
                mayorValor = value;
                NotifyPropertyChanged();
            }
        }

        public string MayorLabel
        {
            get { return mayorLabel; }
            set
            {
                mayorLabel = value;
                NotifyPropertyChanged();
            }
        }

        public emergencia_resumenViewModel()
        {
            this.apiService = new ApiService(); 

            this.ItemSelectedCommand = new Command(this.ItemSelected);
            this.RefreshCommand = new Command(this.LoadBalanceAsync);

            LoadBalanceAsync();
        }



        #region Properties
        public ObservableCollection<emergencia_resumenModel> Emergencia_resumenModels
        {
            get
            {
                return emergencia_resumenModels;
            }
            set
            {
                emergencia_resumenModels = value;
                NotifyPropertyChanged();
            }

        }

        public Boolean IsRefreshing
        {
            get { return isRefreshing; }
            set {
                isRefreshing= value;
                NotifyPropertyChanged();
            }
        }


        public Boolean LoadBalanceIsRunning
        {
            get { return this.loadBalanceIsRunning; }
            set
            {
                this.loadBalanceIsRunning = value;
                NotifyPropertyChanged();
            }
        }

        public Command ItemSelectedCommand { get; set; }

        public Command RefreshCommand { get; set; }

        #endregion

        #region Methods

        private async void ItemSelected(object selectedItem)
        {            
            try
            {
                var emergencia_resumenModelSelected = selectedItem as emergencia_resumenModel;
                Application.Current.MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, "#713d74");

                Dictionary<string, decimal> prediccionEmergencias = new Dictionary<string, decimal>()
                    {
                        {"Ambulancia", emergencia_resumenModelSelected.Ambulancia},
                        {"Emergencia", emergencia_resumenModelSelected.Emergencia},
                        {"Bomberos", emergencia_resumenModelSelected.Bomberos},
                        {"Policia", emergencia_resumenModelSelected.Policia},
                        {"Transito", emergencia_resumenModelSelected.Transito},
                        {"Ruido", emergencia_resumenModelSelected.Ruido}
                    };

                //MayorPrediccion = prediccionEmergencias.Max(x => x.Value);                 
                MayorLabel = emergencia_resumenModelSelected.MoyorLabel;
                MayorValor = emergencia_resumenModelSelected.MayorValor;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Aceptar");
            }
        }

        #endregion

        private async void LoadBalanceAsync()
        {
            LoadBalanceIsRunning = true;
            IsRefreshing = true;

            string UrlQuery = "/emergencia_resumens";
            
            var response = await this.apiService.GetJson<Dataemergencia_resumenModel>(MainStatic.UrlBase, "/api", UrlQuery);

            if (!response.IsSuccess)
            {
                LoadBalanceIsRunning = false;
                IsRefreshing = false;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Información", response.Message, "Aceptar");
                    NavigationService.SetMainPage("Login");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                }
                return;
            }
            

            try
            {
                var BalancesList = (Dataemergencia_resumenModel)response.Result;
                Emergencia_resumenModels = new ObservableCollection<emergencia_resumenModel>(BalancesList.data);

                if (Emergencia_resumenModels.Count == 0)
                    await Application.Current.MainPage.DisplayAlert("Información", "Usuario no tiene ningún concepto registrado", "Aceptar");
            }
            catch (Exception ex)
            {

            }

            LoadBalanceIsRunning = false;
            IsRefreshing = false;
        }
    }
}
