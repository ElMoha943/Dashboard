using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class Producto
    {
        string id;
        string nombre;
        string descripcion;
        string marca;
        string precio;
        string stock;

        public Producto(string id, string nombre, string descripcion, string marca, string precio, string stock)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Marca = marca;
            this.Precio = precio;
            this.Stock = stock;
        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Stock { get => stock; set => stock = value; }
    }
}
