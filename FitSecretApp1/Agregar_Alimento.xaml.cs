using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using FitSecretApp1;
using System.Net.Http;
using System.Net;

namespace FitSecretApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agregar_Alimento : ContentPage
    {
        public Agregar_Alimento()
        {
            InitializeComponent();
        }
        public class AlimentoApi
        {
            
            public int iD_Empresa { get; set; }
            public string nombre { get; set; }
            public int calorias { get; set; }
            public int carbohidratos { get; set; }
            public int proteinas { get; set; }
            public int grasas { get; set; }
            public int codigoQR { get; set; }
        }

        private async void btnAlimrntos_Clicked(object sender, EventArgs e)
        {
            //this.txtNombre1.Text = "hola";
            //String valor = this.txtNombre1.Text;
            AlimentoApi ali = new AlimentoApi            
            {
                iD_Empresa = 1,                   
                nombre=   "nuevo",  // txtNombre1.Text,
                calorias =      Convert.ToInt32 (txtCalorias.Text),
                carbohidratos =  Convert.ToInt32(txtCalorias.Text),
                proteinas = Convert.ToInt32(txtProteinas.Text),
                grasas =  Convert.ToInt32(txtGarsas.Text),
                codigoQR = 1234 
            };
            Uri RequestUri = new Uri("https://fitsecret.somee.com/FitSe/api/alimento/insert/dato");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(ali);
            var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJSON);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                 Navigation.PushAsync(new MainPage());
                await DisplayAlert("Alimentos", "Se Agrego el alimento", "OK");

              
            }
            else
            {
                await DisplayAlert("Alimentos", "Ocurrio un error:(", "OK");
            }

        }
    }
}