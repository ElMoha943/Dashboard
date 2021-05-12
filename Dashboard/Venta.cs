using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class Venta
    {
        uint id;
        float monto;
        DateTime fehca;
        List<VentasProductos> productos;

        public Venta(uint id, float monto, DateTime fehca, List<VentasProductos> productos)
        {
            this.Id = id;
            this.Monto = monto;
            this.Fehca = fehca;
            this.Productos = productos;
        }

        public uint Id { get => id; set => id = value; }
        public float Monto { get => monto; set => monto = value; }
        public DateTime Fehca { get => fehca; set => fehca = value; }
        internal List<VentasProductos> Productos { get => productos; set => productos = value; }
    }
}
