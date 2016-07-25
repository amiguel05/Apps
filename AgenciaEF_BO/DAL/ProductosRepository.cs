using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;


namespace AgenciaEF_BO.DAL
{
    public class ProductosRepository : GenericRepository<Productos>
    {
        public ProductosRepository(AgenciasContext context)
            : base(context)
        {

        }


        public IEnumerable<Productos> ProdIdFromCode(string psOriCodigo, string psSupCodigo, string psProCodigo)
        {

        

            var cods = this.Get(filter: s => s.PRO_CODIGO == psProCodigo && s.Origen.ORI_CODIGO == psOriCodigo && s.Suplidores.SUP_CODIGO == psSupCodigo);


            return cods;

        }
 
 
    }
}
