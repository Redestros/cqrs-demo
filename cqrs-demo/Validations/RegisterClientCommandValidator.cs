using cqrs_demo.Services.Customers.Commands;
using FluentValidation;

namespace cqrs_demo.Validations
{
    public class RegisterClientCommandValidator : AbstractValidator<RegisterClientCommand>
    {
        public RegisterClientCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .Matches("^[0-9a-zA-Z_ ]*$")
                .MaximumLength(18);

            RuleFor(c => c.Name)
                .NotEmpty();
        }
    }
}