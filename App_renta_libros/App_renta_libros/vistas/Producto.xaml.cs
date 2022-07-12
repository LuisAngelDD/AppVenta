using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_renta_libros.modelos;
using App_renta_libros.vistas.menu;

namespace App_renta_libros.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Producto : ContentPage
    {
        public Producto(MProductos pr)
        {
            InitializeComponent();
            nombre_p.Text = pr.nombre;
            descripcion_p.Text = pr.descripcion;
            precio_p.Text = pr.precio;
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