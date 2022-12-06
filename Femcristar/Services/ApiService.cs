using AppEmergencia.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

//#$#$# PAGINA PARA BAJAR LOS ICONOS DE ANDROID  https://romannurik.github.io/AndroidAssetStudio/
//$$·$· ACTIVITY INDICATOR https://www.youtube.com/watch?v=o9rsNgRn0Ts

namespace AppEmergencia.Services
{
    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Por favor active su conexion de internet",
                };
            }

            //verificarotra  manera porque es muy comun que diga  que verifique
            //var isReachable = await CrossConnectivity.Current.IsRemoteReachable("www.google.com");
            //if (!isReachable)
            //{
            //    return new Response
            //    {
            //        IsSuccess = false,
            //        Message = "Verifique su conexion a internet",
            //    };
            //}

            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }

        public async Task<Response> GetList<T>(string urlBase, string servicePrefix, string controller)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", MainStatic.Token);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = "Su sesión ha expirado, debe iniciar sesión nuevamente",
                            StatusCode = HttpStatusCode.Unauthorized,
                        };
                    }

                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = "No se puede tener acceso a la URL(" + controller + "), intente de nuevo mas tarde",
                            StatusCode = HttpStatusCode.NotFound,
                        };
                    }

                    else
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = result,
                            StatusCode = response.StatusCode,
                        };
                    }
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = e.Message,
                };
            }
        }

        public async Task<Response> GetJson<T>(string urlBase, string servicePrefix, string controller)
        {
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", MainStatic.Token);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = "Su sesión ha expirado, debe iniciar sesión nuevamente",
                            StatusCode = HttpStatusCode.Unauthorized,
                        };
                    }

                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = "No se puede tener acceso a la URL(" + controller + "), intente de nuevo mas tarde",
                            StatusCode = HttpStatusCode.NotFound,
                        };
                    }

                    else
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = result,
                            StatusCode = response.StatusCode,
                        };
                    }
                }

                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = e.Message,
                };
            }
        }

    
    }
}
