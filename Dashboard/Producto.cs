using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class Producto
    {
        uint id;
        string nombre;
        float precio;
        int stock;

        public Producto(uint id, string nombre, float precio, int stock)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Stock = stock;
        }

        public uint Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
