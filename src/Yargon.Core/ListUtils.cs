using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yargon.Core
{
    /// <summary>
    /// List utility functions.
    /// </summary>
    public static class ListUtils
    {
        /// <summary>
        /// Makes a safety copy of a list, and ensures none of the elements are <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="sequence">The sequence to copy into a list.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <returns>The resulting list.</returns>
        public static IReadOnlyList<T> MakeSafeCopy<T>(this IEnumerable<T> sequence, string paramName)
        {
            if (sequence == null)
                throw new ArgumentNullException(paramName);
            
            var list = sequence.ToArray();
            if (list.Any(e => e == null))
                throw new ArgumentException("The sequence contains a null element.", paramName);
            return list;
        }
    }
}
