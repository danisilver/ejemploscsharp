using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using e53.Models;
using Newtonsoft.Json;
namespace e53.Helpers
{
    public class HelperDoctorAzure
    {
        private const String DireccionApi = "https://apicruddoctores.azurewebsites.net/";

        private HttpClient CrearCliente()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            Doctor listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + $"api/doctores/{id}";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<Doctor>(contenido);
            }
            return listadatos;
        }
    }
}
