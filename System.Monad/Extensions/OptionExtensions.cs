//
//  MaybeExtensions.cs
//
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

using System;

namespace System.Monad.Extensions
{
    public static class OptionExtensions
    {
        public static IOption<T> SomeOrNone<T>(this T? value) where T : struct
        {
            return value.HasValue ? value.Value.SomeOrNone() : Maybe.None<T>();
        }
        
        public static IOption<T> SomeOrNone<T>(this T value)
        {
            return Maybe.SomeOrNone(value);
        }

        public static IOption<TResult> Or<TResult, T>(this IOption<T> some, TResult other) where T : TResult
        {
            return some.HasValue ? some as IOption<TResult> : other.SomeOrNone();
        }
    }
}
