using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer.Quickstart
{
    public static class DelegationRequiredProperty
    {
        public const string Subject = "subject";
    }

    public class DelegationGrantValidator : IExtensionGrantValidator
    {
        private readonly ITokenValidator _validator;

        public DelegationGrantValidator(ITokenValidator validator)
        {
            _validator = validator;
        }

        public string GrantType => "delegation";

        async Task IExtensionGrantValidator.ValidateAsync(ExtensionGrantValidationContext context)
        {
            // The clinet must be setup with the subject property.
            var prop = context.Request.Client.Properties.FirstOrDefault(a => a.Key.Equals(DelegationRequiredProperty.Subject));
            if (prop.Key == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient);
                return;
            }

            // Grab the subject from the request.
            var subject = context.Request.Raw.Get(DelegationRequiredProperty.Subject);
            if (prop.Value != subject)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest);
                return;
            }

            if (!long.TryParse(subject, out var subjectid))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest);
                return;
            }

            context.Result = new GrantValidationResult(subject, GrantType);
        }
    }
}
