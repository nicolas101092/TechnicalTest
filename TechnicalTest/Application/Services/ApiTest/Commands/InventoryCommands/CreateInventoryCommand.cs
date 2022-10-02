namespace Application.Services.ApiTest.Commands.InventoryCommands
{
    public class CreateInventoryCommand : IRequest<bool>
    {
        #region Properties

        public string Name { get; set; } = null!;

        #endregion
    }

    public class CreateInventoryValidator : AbstractValidator<CreateInventoryCommand>
    {
        public CreateInventoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
        }
    }
}
