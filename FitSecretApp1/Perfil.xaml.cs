using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitSecretApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        public Perfil()
        {
            InitializeComponent();
            btnAvance.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new Avance());
            };
        }
        public class AlimentoApi
        {
            public int idAlimento { get; set; }
            public int iD_Empresa { get; set; }
            public string nombre { get; set; }
            public int calorias { get; set; }
            public int carbohidratos { get; set; }
            public int proteinas { get; set; }
            public int grasas { get; set; }
            public int codigoQR { get; set; }
        }
        private async void Button_Clicked2 (object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://fitsecret.somee.com/FitSe/api/alimento/obtain/all");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accpet", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<AlimentoApi>>(content);
                ListPerfil.ItemsSource = resultado;
            }

        }
        private async void login(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://fitsecret.somee.com/FitSe/api/alimento/obtain/all");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accpet", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<AlimentoApi>>(content);
                ListPerfil.ItemsSource = resultado;
                
            }

        }
    }
}