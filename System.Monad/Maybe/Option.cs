//  Author:
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

namespace System.Monad.Maybe
{
    using System;
    using System.Collections.Generic;

    public static class Option
    {
        public static IOption<T> SomeOrNone<T>(T someValue)
        {
            if (EqualityComparer<T>.Default.Equals(someValue, default(T))) {
                return Option.None<T>();
            }

            return new Some<T>(someValue);
        }

        public static IOption<T> None<T>()
        {
            return new None<T>();
        }
    }
}