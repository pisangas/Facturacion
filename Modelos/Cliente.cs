using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table ("Clientes")]
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Index("CedulaUnica", IsUnique = true)]
        public int Cedula { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
