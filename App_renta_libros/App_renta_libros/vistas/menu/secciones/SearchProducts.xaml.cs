using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_renta_libros.viewmodel;
using App_renta_libros.modelos;

namespace App_renta_libros.vistas.menu.secciones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchProducts : ContentPage
    {
        public SearchProducts()
        {
            InitializeComponent();
            BindingContext = new VMProducts();
        }
        async private void agregar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PublicarProducto());
        }
        async private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new Producto(e.SelectedItem as MProductos));
        }

        async private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                await(BindingContext as VMProducts).LoadDataS(e.NewTextValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}