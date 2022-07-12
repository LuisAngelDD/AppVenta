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
    public partial class MiProduct : ContentPage
    {
        public MiProduct()
        {
            InitializeComponent();
            BindingContext = new VMMyProducts();
        }

        async private void agregar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PublicarProducto());
        }
        async private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new UpdateProducto(e.SelectedItem as MProductos));
        }
        async private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    await (BindingContext as VMMyProducts).LoadDataS(e.NewTextValue);
                }
                else {
                    await (BindingContext as VMMyProducts).LoadData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}