using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AjaxPractice
{
    static public partial class Extension
    {
        static public IEnumerable<ValidationError> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = (from m in modelState
                          where m.Value.Errors.Count() > 0
                          select
                             new ValidationError
                             {
                                 PropertyName = m.Key,
                                 ErrorList = (from msg in m.Value.Errors
                                              select msg.ErrorMessage).ToArray()
                             })
                                .AsEnumerable();
            return errors;
        }
    }
}