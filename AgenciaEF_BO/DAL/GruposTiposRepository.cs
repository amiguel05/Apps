using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.DAL
{
    public class GruposTiposRepository : GenericRepository<GruposTipos>
    {

        public GruposTiposRepository(AgenciasContext context) :   base(context)
        {

        }
    }
}
