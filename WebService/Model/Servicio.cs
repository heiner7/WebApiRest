using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebSite.Models
{
    // Esta implementación de Singleton se llama "bloqueo de verificación doble". Es seguro
    // en un entorno de subprocesos múltiples(Singleton con seguridad en los hilos)
    public class Servicio
    {
        #region "PATRON SINGLETON"
        private static Servicio? objMenu = null;
        // Ahora tenemos un objeto de bloqueo que se usará para sincronizar hilos
        // durante el primer acceso al Singleton.
        private static readonly object _lock = new object();
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        private Servicio()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(config.GetValue<string>("ServiceUrl:DefaultConnection"));
        }
        public static Servicio getInstance()
        {
            if (objMenu == null)
            {
                // Ahora, imagina que el programa acaba de ser lanzado. Desde
                // todavía no hay una instancia de Singleton, varios subprocesos pueden
                // pasa simultáneamente el condicional anterior y llega a este
                // punto casi al mismo tiempo. El primero de ellos adquirirá
                // bloquear y continuar, mientras que el resto esperará aquí.
                
                lock (_lock)
                {
                    // El primer subproceso en adquirir el bloqueo, llega a este
                    // condicional, entra y crea el Singleton
                    // instancia. Una vez que sale del bloque de bloqueo, un hilo que
                    // podría haber estado esperando la liberación de bloqueo puede entonces
                    // entrar en esta sección. Pero como el campo Singleton es
                    // ya inicializado, el hilo no creará un nuevo
                    // objeto.
                    if (objMenu == null)
                    {
                        objMenu = new Servicio();
                       
                    }
                }
            }
            return objMenu;
        }
        #endregion

        public HttpClient Client { get; set; }
        
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        //Metodo que envia la solicitud de put a la api establecida
        public HttpResponseMessage PutResponse(string url, HttpContent model, string token)
        {
            // Agregar el token al encabezado Authorization
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return Client.PutAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, HttpContent model, string token)
        {
            // Agregar el token al encabezado Authorization
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return Client.PostAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url, string token)
        {
            // Agregar el token al encabezado Authorization
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return Client.DeleteAsync(url).Result;
        }
    }
}