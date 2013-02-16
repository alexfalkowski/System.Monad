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

    public class None<T> : OptionBase<T>, IEquatable<None<T>>
    {
        internal None()
        {
        }

        public override IEnumerator<T> GetEnumerator()
        {
            yield break;
        }

        public override string ToString()
        {
            return "None";
        }

        public bool Equals(None<T> other)
        {
            return !object.ReferenceEquals(null, other);
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj)) {
                return false;
            }

            if (object.ReferenceEquals(this, obj)) {
                return true;
            }

            var type = typeof(None<T>);

            if (obj.GetType() != type) {
                return obj.GetType().GetGenericTypeDefinition() == type.GetGenericTypeDefinition();
            }

            var other = (None<T>)obj;
            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override IOption<TResult> Into<TResult>(Func<T, IOption<TResult>> fn)
        {
            return Option.None<TResult>();
        }

        public override IOption<TResult> Into<TResult>(Func<T, TResult> fn)
        {
            return Option.None<TResult>();
        }

        public override void Into(Action<T> action)
        {
        }
    }
}