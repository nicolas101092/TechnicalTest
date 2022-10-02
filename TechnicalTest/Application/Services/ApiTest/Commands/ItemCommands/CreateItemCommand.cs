namespace Application.Services.ApiTest.Commands.ItemCommands
{
    public class CreateItemCommand : IRequest<bool>
    {
        #region Properties

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }

        #region Relation properties

        public int IdInventory { get; set; }

        #endregion

        #endregion
    }

    public class CreateItemValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MinimumLength(2).MaximumLength(100);
            RuleFor(x => x.ExpirationDate.Date).GreaterThan(DateTime.UtcNow.Date);
        }
    }
}
