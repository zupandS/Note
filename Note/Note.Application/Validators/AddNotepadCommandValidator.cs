using FluentValidation;
using Note.Application.Commands.AddNotepadCommand;

namespace Note.Application.Validators
{
    public class AddNotepadCommandValidator : AbstractValidator<AddNotepadCommand>
    {
        public AddNotepadCommandValidator()
        {
            RuleFor(n => n.Title).NotEmpty().WithMessage("Title Required").NotNull().MaximumLength(10).WithMessage("Entities must not exceed 100");
        }
    }
}