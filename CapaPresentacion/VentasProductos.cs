using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class VentasProductos
    {
        uint id;
        uint producto_id;

        public VentasProductos(uint id, uint producto_id)
        {
            this.Id = id;
            this.Producto_id = producto_id;
        }

        public uint Id { get => id; set => id = value; }
        public uint Producto_id { get => producto_id; set => producto_id = value; }
    }
}
