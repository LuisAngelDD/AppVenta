using System;

namespace App_renta_libros.modelos
{
    public class MProductos
    {
        public MProductos()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string descripcion { get; set; }
        public string nombre { get; set; }
        public string precio { get; set; }
        public string correoUser { get; set; }
        public string Id { get; set; }
    }
}
