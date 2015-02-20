using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TN.BLL.Utility
{
    public static class GetModelStateErrors
    {
        public static IEnumerable<ModelError> GetListOfErrors(
            IEnumerable<KeyValuePair<string, ModelState>> modelStateDictionary)
        {
            var errorMessages = new List<ModelError>();
            foreach (var keyValuePair in modelStateDictionary.Where(keyValuePair=>keyValuePair.Value.Errors.Count >0))
            {
                errorMessages.AddRange(keyValuePair.Value.Errors.Where(error => !error.ErrorMessage.Contains("Info")));
            }
            return errorMessages;
        } 

    }
}
