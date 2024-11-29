using System.IO;
using Microsoft.Maui.Controls;

namespace ExamenP2EricMullo
{
    public partial class StackLayout : ContentPage
    {
        public StackLayout()
        {
            InitializeComponent();
        }

        private async void JBtn_Recargar_Click(object sender, EventArgs e)
        {
            string numero = JTex_NumeroEMullo.Text;
            string nombre = JTex_Nombre.Text;

            if (string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(nombre))
            {
                await DisplayAlert("Error", "Por favor, ingrese todos los datos.", "OK");
                return;
            }

            if (numero.Length != 10 || !long.TryParse(numero, out _))
            {
                await DisplayAlert("Error", "El número de teléfono debe tener 10 dígitos válidos.", "OK");
                return;
            }

            string fileName = $"{nombre.Replace(" ", "")}.txt";
            string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
            File.WriteAllText(filePath, $"Nombre: {nombre}\nNúmero: {numero}");
            await DisplayAlert("Recarga Exitosa", "La recarga se realizó correctamente.", "OK");
            JLbl_ResumenEMullo.Text = $"La última recarga realizada fue:\nNombre: {nombre}\nNúmero: {numero}";
            JTex_NumeroEMullo.Text = string.Empty;
            JTex_Nombre.Text = string.Empty;
        }
    }
}
