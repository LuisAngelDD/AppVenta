using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_renta_libros.modelos;
using App_renta_libros.vistas.menu;
using App_renta_libros.repositorio;

namespace App_renta_libros.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateProducto : ContentPage
    {
        RProducto repository = new RProducto();
        MProductos pr_ = new MProductos();
        public UpdateProducto(MProductos pr)
        {
            InitializeComponent();
            this.pr_ = pr;
            nombre_p.Text = pr.nombre;
            descripcion_p.Text = pr.descripcion;
            precio_p.Text = pr.precio;
        }
        async private void regresar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuApp());
        }
        async private void update(object sender, EventArgs e)
        {
            MProductos product = new MProductos();
            product.Id = pr_.Id;
            product.nombre = nombre_p.Text;
            product.descripcion = descripcion_p.Text;
            product.precio = precio_p.Text;
            product.correoUser = pr_.correoUser;
            var isSaved = await repository.Update(product);
            if (isSaved)
            {
                await this.DisplayToastAsync("Datos actualizados", 2000);
                Clear();
                await Navigation.PushAsync(new MenuApp());
            }
            else
            {
                await this.DisplayToastAsync("Error al actualizar los datos", 2000);
            }
        }
        async private void delete(object sender, EventArgs e)
        {
            var isSaved = await repository.Delete(pr_.Id);
            if (isSaved)
            {
                await this.DisplayToastAsync("Producto Eliminado", 2000);
                Clear();
                await Navigation.PushAsync(new MenuApp());
            }
            else
            {
                await this.DisplayToastAsync("Error al eliminar el producto", 2000);
            }
        }
        public void Clear()
        {
            nombre_p.Text = String.Empty;
            descripcion_p.Text = String.Empty;
            precio_p.Text = String.Empty;
            nombre_p.Text = String.Empty;
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}