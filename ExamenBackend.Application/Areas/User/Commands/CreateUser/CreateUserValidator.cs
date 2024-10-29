using FluentValidation;

namespace ExamenBackend.Application.Areas.User.Commands.CreateUser;

internal class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(command => command.FirstName)
            .NotEmpty()
            .WithMessage("Primer nombre es requerido")
            .MaximumLength(50)
            .WithMessage("El maximo de caracteres es 50");

        RuleFor(command => command.LastName)
            .NotEmpty()
            .WithMessage("Primer apellido es requerido")
            .MaximumLength(50)
            .WithMessage("El maximo de caracteres es 50");

        RuleFor(command => command.MiddleName)
            .NotEmpty()
            .WithMessage("Nombre de en medio es requerido")
            .MaximumLength(50)
            .WithMessage("El maximo de caracteres es 50");


        RuleFor(command => command.SecondLastName)
            .NotEmpty()
            .WithMessage("Segundo apellido es requerido")
            .MaximumLength(50)
            .WithMessage("El maximo de caracteres es 50");


        RuleFor(command => command.BirthDate)
            .NotEmpty()
            .WithMessage("Fecha de nacimiento es requerido");
        
    }
}
