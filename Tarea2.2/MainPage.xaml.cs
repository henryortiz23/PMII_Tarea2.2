namespace Tarea2._2
{
    public partial class MainPage : ContentPage
    {
        private Stream streamImage = null;
        public MainPage()
        {
            InitializeComponent();
        }

        private void creandoFirma(object sender, CommunityToolkit.Maui.Core.DrawingLineCompletedEventArgs e)
        {
            ImageView.Dispatcher.Dispatch(async () =>
            {
                var stream = await firma.GetImageStream(300, 300);
                streamImage = stream;
            });
        }
        private async void btnBorrar_Clicked(object sender, EventArgs e)
        {
            borrar();
        }

        private void borrar()
        {
            firma.Lines.Clear();
            streamImage = null;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (streamImage != null && txtDescripcion.Text != null)
            {
                var firma = new Models.Firmas
                {
                    firma = ImageToArrayByte(),
                    descripcion = txtDescripcion.Text
                };
                if (await App.Instancia.AddFirma(firma) > 0)
                {
                    borrar();
                    txtDescripcion.Text = null;
                    await DisplayAlert("Aviso", "Firma guardada correctamente", "Ok");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ocurrio un error", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Debe proporcionar su firma e ingresar una descripcion", "Ok");
            }
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageListFirmas());
        }

        public string ImageToBase64()
        {
            if (streamImage != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = streamImage;//image.GetStream();
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();
                    string base64 = Convert.ToBase64String(data);

                    return base64;
                }
            }

            return null;
        }

        public byte[] ImageToArrayByte()
        {
            if (streamImage != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = streamImage;
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();

                    return data;
                }
            }

            return null;
        }
    }
}