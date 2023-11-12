using Tarea2._2.Models;

namespace Tarea2._2.Views;

public partial class PageListFirmas : ContentPage
{

	public PageListFirmas()
	{
		InitializeComponent();
	}
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        list.ItemsSource = await App.Instancia.ListFirmas();
    }

    private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Firmas selectedPersona)
        {
            if (selectedPersona != null)
            {
                //imagenSeleccionado = selectedPersona;
                //mostrarImagen();
            }
        }
    }
}