// Author:
//       alexfalkowski <alexrfalkowski@gmail.com>
//
//  Copyright (c) 2013 GPL3
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace System.Monad.Collections
{
    using System.Collections.Generic;
    using System.Monad.Maybe;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, 
                                                                 Func<TSource, TResult> selector)
        {
            return source.Select(selector);
        }

        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, 
                                                           Func<TSource, bool> predicate)
        {
            return source.Where(predicate);
        }

        public static TSource Reduce<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            return source.Aggregate(func);
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source,
                                            Action<TSource> action)
        {
            foreach (var value in source) {
                action.SomeOrNone().Into(actualAction => actualAction(value));
            }
        }
    }
}