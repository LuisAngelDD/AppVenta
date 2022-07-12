using Firebase.Database;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_renta_libros.modelos;

namespace App_renta_libros.repositorio
{
    public class RProducto
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://proyecto-unidad-4-d475a-default-rtdb.firebaseio.com/");
        public async Task<bool> Save(MProductos producto)
        {
            var data = await firebaseClient.Child(nameof(MProductos)).PostAsync(JsonConvert.SerializeObject(producto));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
        public async Task<List<MProductos>> GetAll()
        {
            return (await firebaseClient.Child(nameof(MProductos)).OnceAsync<MProductos>()).Select(item => new MProductos
            {
                nombre = item.Object.nombre,
                descripcion = item.Object.descripcion,
                precio = item.Object.precio,
                correoUser = item.Object.correoUser,
                Id = item.Key
            }).ToList();
        }
        public async Task<List<MProductos>> GetAllByName(string name)
        {
            return (await firebaseClient.Child(nameof(MProductos)).OnceAsync<MProductos>()).Select(item => new MProductos
            {
                nombre = item.Object.nombre,
                descripcion = item.Object.descripcion,
                precio = item.Object.precio,
                correoUser = item.Object.correoUser,
                Id = item.Key
            }).Where(c => c.nombre.ToLower().Contains(name.ToLower())).ToList();
        }
        public async Task<List<MProductos>> GetAllByName(string user,string name)
        {
            return (await firebaseClient.Child(nameof(MProductos)).OnceAsync<MProductos>()).Select(item => new MProductos
            {
                nombre = item.Object.nombre,
                descripcion = item.Object.descripcion,
                precio = item.Object.precio,
                correoUser = item.Object.correoUser,
                Id = item.Key
            }).Where(c => c.nombre.ToLower().Contains(name.ToLower())).Where(c => c.correoUser.ToLower().Contains(user.ToLower())).ToList();
        }
        public async Task<List<MProductos>> GetAllMy(string user)
        {
            return (await firebaseClient.Child(nameof(MProductos)).OnceAsync<MProductos>()).Select(item => new MProductos
            {
                nombre = item.Object.nombre,
                descripcion = item.Object.descripcion,
                precio = item.Object.precio,
                correoUser = item.Object.correoUser,
                Id = item.Key
            }).Where(c => c.correoUser.ToLower().Contains(user.ToLower())).ToList();
        }
        public async Task<MProductos> GetById(string id)
        {
            return (await firebaseClient.Child(nameof(MProductos) + "/" + id).OnceSingleAsync<MProductos>());
        }
        public async Task<bool> Update(MProductos producto)
        {
            await firebaseClient.Child(nameof(MProductos) + "/" + producto.Id).PutAsync(JsonConvert.SerializeObject(producto));
            return true;
        }
        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(MProductos) + "/" + id).DeleteAsync();
            return true;
        }
    }
}
