//
//  StringExtensions.cs
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
    public static class StringExtensions
    {
        public static IOption<string> SomeStringOrNone(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) {
                return Maybe.None<string>();
            }
            
            return new Some<string>(value);
        }
        
        public static IOption<Uri> SomeUriOrNone(this string value)
        {
            Uri uri;
            
            if (!Uri.TryCreate(value, UriKind.Absolute, out uri)) {
                return Maybe.None<Uri>();
            }
            
            return new Some<Uri>(uri);
        }
        
        public static IOption<int> SomeIntegerOrNone(this string value)
        {
            int integer;
            
            if (!int.TryParse(value, out integer)) {
                return Maybe.None<int>();
            }
            
            return new Some<int>(integer);
        }
    }
}

