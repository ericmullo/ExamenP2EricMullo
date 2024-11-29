using System.IO;
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
            string fileName = $"{nombre.Replace(" ", "")}.txt"; // Crear el archivo con el nombre
            string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
            // Escribir en el archivo
            File.WriteAllText(filePath, $"Nombre: {nombre}\nNúmero: {numero}");
            // Mostrar mensaje de confirmación
            await DisplayAlert("Recarga Exitosa", "La recarga se realizó correctamente.", "OK");
            // Actualizar el resumen
            JLbl_ResumenEMullo.Text = $"La última recarga realizada fue:\nNombre: {nombre}\nNúmero: {numero}";
            // Limpiar los campos
            JTex_NumeroEMullo.Text = string.Empty;
            JTex_Nombre.Text = string.Empty;
        }
    }
}