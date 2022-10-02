using App.Utils.Middlewares.Core.PersonalExceptions;

namespace App.Utils.Extensions.Helpers.PersonalExceptions.Extensions
{
    public static class NotFoundExtension
    {
        /// <summary>
        /// Throw a NotFound if the object is null with parameter id is string
        /// </summary>
        /// <typeparam name="T">a generic object</typeparam>
        /// <param name="item">a object to validate if is null</param>
        /// <param name="id">the id of the resource</param>
        /// <exception cref="NotFoundException">throw the personal NotFoundException for convert the result of api in a NotFound</exception>
        public static void ThrowIfNull<T>(T item, string id)
        {
            if (item == null)
                throw new NotFoundException(id);
        }

        /// <summary>
        /// Throw a NotFound if the object is null with parameter id is int
        /// </summary>
        /// <typeparam name="T">a generic object</typeparam>
        /// <param name="item">a object to validate if is null</param>
        /// <param name="id">the id of the resource</param>
        /// <exception cref="NotFoundException">throw the personal NotFoundException for convert the result of api in a NotFound</exception>
        public static void ThrowIfNull<T>(T item, int id)
        {
            if (item == null)
                throw new NotFoundException(id.ToString());
        }

        /// <summary>
        /// Throw a NotFound if the id is larger then 0
        /// </summary>
        /// <param name="id">the id of the resource</param>
        /// <exception cref="NotFoundException">>throw the personal NotFoundException for convert the result of api in a NotFound</exception>
        public static void ThrowIfValueNotValid(int id)
        {
            if (id <= 0)
                throw new NotFoundException(id.ToString());
        }

        /// <summary>
        /// Throw a NotFound if the list has 0 items
        /// </summary>
        /// <typeparam name="T">a generic object</typeparam>
        /// <param name="items">the list of items to comparer</param>
        /// <param name="id">the id of the resource</param>
        /// <exception cref="NotFoundException">throw the personal NotFoundException for convert the result of api in a NotFound</exception>
        public static void ThrowIfNotAny<T>(List<T> items, int id)
        {
            if (items is null || !items.Any())
                throw new NotFoundException(id.ToString());
        }

        /// <summary>
        /// Throw a NotFound if the list has 0 items
        /// </summary>
        /// <typeparam name="T">a generic object</typeparam>
        /// <param name="items">the list of items to comparer</param>
        /// <param name="id">the id of the resource</param>
        /// <exception cref="NotFoundException">throw the personal NotFoundException for convert the result of api in a NotFound</exception>
        public static void ThrowIfNotAny<T>(List<T> items, string id)
        {
            if (items is null || !items.Any())
                throw new NotFoundException(id);
        }
    }
}
