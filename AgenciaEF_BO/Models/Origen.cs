﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("ORIGEN")]
    public class Origen
    {
        //ORI_ID      ORI_CODIGO ORI_DESCRIPCION                          ORI_ESTADO ORI_EMS_GROUP ORI_APP_GROUP ORI_COURIER_GROUP ORI_EQUIVALENTE ORI_CORREO_INT

        [Key]
        public int ORI_ID { set; get; }

        public string ORI_CODIGO { set; get; }
        public string ORI_DESCRIPCION { set; get; }
        public string ORI_ESTADO { set; get; }
        public string ORI_EMS_GROUP { set; get; }
        public string ORI_APP_GROUP { set; get; }
        public string ORI_COURIER_GROUP { set; get; }
        public string ORI_EQUIVALENTE { set; get; }
        public string ORI_CORREO_INT { set; get; }


    }
}
