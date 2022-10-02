namespace Application.Services.ApiTest.Commands.ItemCommands
{
    public class RemoveByNameItemCommand : IRequest<bool>
    {
        public string Name { get; set; } = null!;
    }

    public class RemoveByNameItemValidator : AbstractValidator<RemoveByNameItemCommand>
    {
        public RemoveByNameItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
        }
    }
}
