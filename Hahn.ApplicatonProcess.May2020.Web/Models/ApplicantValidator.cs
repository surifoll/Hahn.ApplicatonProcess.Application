using System;
using FluentValidation;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Domain.Networks;

namespace Hahn.ApplicatonProcess.May2020.Web.Models
{
    public class ApplicantModelValidator : AbstractValidator<ApplicantModel>
    {
        readonly IHttpClientWrapper _client;

        public ApplicantModelValidator(IHttpClientWrapper client)
        {
            _client = client;

            RuleFor(x => x.Name).NotEmpty().WithMessage("The  Name cannot be blank.")
                .MinimumLength(5).WithMessage("The  Name cannot be less than 5 characters.");

            RuleFor(x => x.FamilyName).NotEmpty().WithMessage("The Family Name cannot be blank.")
                .MinimumLength(5).WithMessage("The Family Name cannot be less than 5 characters.");

            RuleFor(x => x.Address).NotEmpty().WithMessage("The Address cannot be blank.")
                .MinimumLength(10).WithMessage("The Address cannot be less than 5 characters.");

            RuleFor(x => x.EMailAddress).NotEmpty().EmailAddress().WithMessage("Provide a valid Email Address")
               ;

            RuleFor(x => x.Age).GreaterThanOrEqualTo(20).WithMessage("Age cannot be less than 20")
                .LessThanOrEqualTo(60).WithMessage("Age cannot be greater than 600");

            RuleFor(x => x.Hired).NotNull().WithMessage("Hired field Can not be null");

            RuleFor(x => x.CountryOfOrigin).MustAsync(async (country, cancellation) =>
            {
                var url = $"https://restcountries.eu/rest/v2/name/{country}?fullText=true";
                var result = await _client.HttpGetAsync(url);
                bool exists = !string.Equals(result, null, StringComparison.InvariantCulture);
                return exists;
            }).WithMessage("country Must be valid");
        }
    }
}