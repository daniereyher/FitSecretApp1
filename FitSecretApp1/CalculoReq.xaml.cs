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
    public partial class CalculoReq : ContentPage
    {
        public CalculoReq()
        {
            InitializeComponent();
        }
        public class Requerimientos
        {
            public int idRequerimiento { get; set; }
            public int idUsuario { get; set; }
            public int idCatNutxPeso { get; set; }
            public float Estatura { get; set; }
            public int Edad { get; set; }
            public int sexo { get; set; }
            public int NivAct { get; set; }
            public int idPadecimiento { get; set; }
            public float Peso { get; set; }



        }
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Requerimientos req = new Requerimientos
            {
                idRequerimiento = 1,
                idUsuario = 1,
                sexo = Convert.ToInt32(idSexo),
                idCatNutxPeso = 1,
                Estatura = Convert.ToInt32(txtEstatura),
                Edad = Convert.ToInt32(txtEdad.Text),
                Peso = Convert.ToInt32(txtPeso.Text),
                NivAct = Convert.ToInt32(nivelAct),
                idPadecimiento = 1

            };

            var generoList = new List<string>();
            generoList.Add("Masculino");
            generoList.Add("Femenino");

            var picker = new Picker { Title = "Seleccione su género" };
            picker.ItemsSource = generoList;

            var actividadList = new List<string>();
            actividadList.Add("Muy activo");
            actividadList.Add("Poco activo");

            var picker2 = new Picker { Title = "Seleccione su nivel de actividad" };
            picker.ItemsSource = actividadList;

            var request = new HttpRequestMessage();
            Uri RequestUri = new Uri("https://fitsecret.somee.com/FitSe/api/requerimiento/insert/dato");

            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(req);
            var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJSON);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Requerimientos", "Se guardó su información", "OK");
                txtEdad.Text = "";
                txtEstatura.Text = "";

            }
            else
            {
                await DisplayAlert("Requerimientos", "Ocurrió un error", "OK");
            }



        }


    }
}