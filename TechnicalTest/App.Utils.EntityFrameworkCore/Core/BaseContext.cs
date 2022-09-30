using App.Utils.Extensions.Helpers.PersonalExceptions;

namespace App.Utils.EntityFrameworkCore.Core
{
    /// <summary>
    /// Context Base for extend funcionality of entityframework
    /// </summary>
    public abstract class BaseContext : DbContext
    {
        #region Properties

        /// <summary>
        /// LoggerFactory for debbugs querys EF Core.
        /// </summary>
        public static readonly ILoggerFactory EfCoreLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information);
            builder.AddDebug();
        });

        #endregion

        #region Constructors

        /// <summary>
        /// BaseContext's protected Constructor.
        /// </summary>
        /// <param name="options">DbContextOptions object type</param>
        protected BaseContext(DbContextOptions options) : base(options)
        {
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Method SaveChangesAsync with validation of model.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">bool object type with the changes saved</param>
        /// <param name="cancellationToken">CancellationToken object type for cacelled the action</param>
        /// <returns>int with rows affected</returns>
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ModelValidation();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Method SaveChanges with validation of model.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">bool object type with the changes saved</param>
        /// <returns>int with rows affected</returns>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ModelValidation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method that validate Model of Entity Frameork before save changes in database
        /// </summary>
        private void ModelValidation()
        {
            foreach (EntityEntry recordToValidate in ChangeTracker.Entries())
            {
                object entity = recordToValidate.Entity;
                ValidationContext validationContext = new(entity);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(entity, validationContext, results, true))
                {
                    var messages = results.Select(r => r.ErrorMessage).Aggregate((message, nextMessage) => message + ", " + nextMessage);
                    throw new BadRequestException($"Unable to save changes for {entity.GetType().FullName} due to error(s): {messages}");
                }
            }
        }

        #endregion

    }
}
