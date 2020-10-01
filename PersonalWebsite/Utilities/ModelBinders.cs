using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PersonalWebsite.Utilities
{
    public class SkillRemoveModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var request = bindingContext.HttpContext.Request;

            var dict = request.Form
                .ToDictionary(a => a.Key, a => a.Value);

            dict.Remove("__RequestVerificationToken");

            var ids = dict.Select(flag => 
                Convert.ToInt32(Regex.Match(flag.Key, @"\d+").Value)).ToList();

            bindingContext.Result = ModelBindingResult.Success(ids);
            return Task.CompletedTask;
        }
    }
}
