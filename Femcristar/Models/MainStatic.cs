using System;
namespace AppEmergencia.Models
{

    //json2csharp.com       Paraconvertir unjson a clase en C#

//    {}
//{ 0: C } // --- para divisas
//{ }
//{ 0: D } // --- para valores decimales
//{ }
//{ 0: E } // --- para valores exponenciales
//{ }
//{ 0: X } // --- para valores hexadecimales
//{ }
//{ 0: P } // --- para porcentajes
//{ }
//{ 0:dd / MM / yyyy } // --- para fecha corta
//{ }
//{ 0:hh: mm: ss } // --- para hora simple
public class MainStatic
    {
        public static string Token { get; set; }
        public static string TokenType { get; set; }
        public static string TitleNotification { get; set; }
        public static string MessageNotification { get; set; }
        public static string VarLogoClient { get; set; }
        public static string VerificationCode { get; set; }
        public static string Password { get; set; }

 
        public static string UrlBase = "http://172.20.10.7:5000";

        public static string UserNuip
        {
            get;
            set;
        }

        public static string UserName
        {
            get;
            set;
        }

        public static int Period
        {
            get;
            set;
        }
    }
}
