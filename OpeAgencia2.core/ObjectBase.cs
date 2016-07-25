using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

namespace OpeAgencia2.Core.Base
{
    public class ObjectBase
    {
        // Manuel A. Hernández.  14-1-2014

        /// <summary>
        /// Clase base para las entidades del modelo.
        /// </summary>
        /// 

        #region Miembros
        private IEnumerable<ValidationFailure> _validationErrors;
        private IValidator _validator;
        #endregion

        public ObjectBase()
        {
            _validator = GetValidator();
        }

        /// <summary>
        /// Permite a las entidades obtener los errores de validación que se generan.
        /// </summary>
        public IEnumerable<ValidationFailure> GetErrors
        {
            get
            {
                return _validationErrors;
            }
        }

        /// <summary>
        /// Obtiene la clase (Referencia) que valida las restricciones de las entidades.
        /// </summary>
        /// <returns></returns>
        public virtual IValidator GetValidator()
        {
            throw new NotImplementedException("Esté método no ha sido implementado.");
        }

        /// <summary>
        /// Valida las restricciones que se han establecido para las entidades. 
        /// Ver restricciones en: OperacionesAgencia.Business.Entities.Models.Validation.
        /// </summary>
        public void Validate()
        {
            if (_validator != null)
            {
                FluentValidation.Results.ValidationResult result = _validator.Validate(this);
                _validationErrors = result.Errors;

            }
        }

        /// <summary>
        /// Determina si la entidad cumple con la restricciones establecidas.
        /// </summary>
        /// 
        [ScaffoldColumn(false)]
        public bool IsValid
        {
            get
            {
                if (_validationErrors != null && _validationErrors.Count() > 0)
                    return false;
                else
                    return true;
            }
        }

    }
}
