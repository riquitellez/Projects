using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Util.Exceptions
{
    public class ValidationException : Exception
    {
        private string _validationError;

        public ValidationException(string mensaje) : base(mensaje)
        {
            _validationError = mensaje;
        }

        public override string ToString()
        {
            return string.Format("{0} - Detalles: {1}", _validationError, base.ToString());
        }
    }
}
