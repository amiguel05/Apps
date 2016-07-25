using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("USUARIOS_SUCURSAL")]
    public  class UsuarioSucursal
    {
        [Key]
        public int USR_SUC_ID { set; get; }

        public int USUARIO_ID { set; get; }

        public int SUC_ID { set; get; }

        public virtual Usuarios Usuarios { set; get; }

        public virtual Sucursales Sucursales { set; get; }
   

    }
}
