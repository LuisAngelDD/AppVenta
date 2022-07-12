using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_renta_libros.repositorio;
using App_renta_libros.modelos;
using App_renta_libros.vistas.menu;

namespace App_renta_libros.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicarProducto : ContentPage
    {
        RProducto repository = new RProducto();
        public PublicarProducto()
        {
            InitializeComponent();
        }
        async private void post(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nombre_p.Text) | String.IsNullOrWhiteSpace(descripcion_p.Text) | String.IsNullOrWhiteSpace(precio_p.Text))
            {
                await this.DisplayToastAsync("Los campos no deben de estar vacíos", 2000);
            }
            else {
                MProductos product = new MProductos();
                product.nombre = nombre_p.Text;
                product.descripcion = descripcion_p.Text;
                product.precio = precio_p.Text;
                product.correoUser = Preferences.Get("User", string.Empty);
                var isSaved = await repository.Save(product);
                if (isSaved)
                {
                    await this.DisplayToastAsync("Producto registrado", 2000);
                    Clear();
                    await Navigation.PushAsync(new MenuApp());
                }
                else
                {
                    await this.DisplayToastAsync("Error al registrar el producto", 2000);
                }
            }
        }
        public void Clear()
        {
            nombre_p.Text = String.Empty;
            descripcion_p.Text = String.Empty;
            precio_p.Text = String.Empty;
            nombre_p.Text = String.Empty;
        }
        async private void regresar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuApp());
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}