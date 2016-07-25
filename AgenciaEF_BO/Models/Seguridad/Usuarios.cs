using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("USUARIOS")]
    public class Usuarios
    {
       /* public Usuarios()
        {
            UsuarioSucursal = new List<UsuarioSucursal>();
        }
        */

        [Key]
        public int USUARIO_ID { set;get;}

        [Required]
        public string NOMBRES { set; get; }

        [Required]
        public string APELLIDOS { set; get; }

        [Required]
        public string USER_NAME { set; get; }

        [Required]
        public int TIPO_ID { set; get; }

        [Required]
        public string CLAVE { set; get; }

        [Required]
        public DateTime FECHA_CLAVE { set; get; }

        [Required]
        public DateTime FECHA_PROX_CAMBIO { set; get; }

        [Required]
        public bool ESTADO { set; get; }

        public virtual Tipos Tipos { set; get; }

        public ICollection<UsuarioSucursal> UsuarioSucursal { set; get; }

        public ICollection<MovCaja> MovCaja { set; get; }

    }
}
