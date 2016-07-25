using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.DAL
{
    public class CodigosRepository : GenericRepository<Codigos>
    {

        public CodigosRepository(AgenciasContext context)
            : base(context)
        {

        }

        public IEnumerable<Codigos> GetByGroupCode(string sGroupCode)
        {
            
           var  cods = this.Get(filter: s => s.GrupoCodigos.CODIGO == sGroupCode);
                  

           return cods;
        
        }


    }
}
