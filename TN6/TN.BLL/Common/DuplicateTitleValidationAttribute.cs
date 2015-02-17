using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TN.DAL;

namespace TN.BLL.Common
{

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DuplicateTitleValidationAttribute: ValidationAttribute, IClientValidatable
    {
        private readonly IBlogRepository _db;

        public DuplicateTitleValidationAttribute(IBlogRepository db)
        {
            _db = db;
        }

        public override bool IsValid(object value)
        {
            bool validTitle = _db.ValidateDuplicateTitle(value.ToString());
            if (validTitle)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {


            yield return new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessage,
                ValidationType = "duplicateTitle"

            };
        }
    }
 
}
