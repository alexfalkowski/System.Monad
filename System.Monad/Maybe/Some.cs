//
//  Some.cs
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

namespace System.Monad.Maybe
{
    using System;
    using System.Collections.Generic;

    public class Some<T> : OptionBase<T>, IEquatable<Some<T>>
    {
        internal Some(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public override bool HasValue {
            get {
                return true;
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            yield return this.Value;
        }

        public override IOption<TResult> Into<TResult>(Func<T, IOption<TResult>> function)
        {
            return function(this.Value);
        }

        public override IOption<TResult> Into<TResult>(Func<T, TResult> function)
        {
            return Option.SomeOrNone<TResult>(function(this.Value));
        }

        public override void Into(Action<T> action)
        {
            action(this.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public bool Equals(Some<T> other)
        {
            if (object.ReferenceEquals(null, other)) {
                return false;
            }

            return object.ReferenceEquals(this, other) || object.Equals(other.Value, this.Value);
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj)) {
                return false;
            }

            if (object.ReferenceEquals(this, obj)) {
                return true;
            }

            var some = obj as Some<T>;

            return some != null && this.Equals(some);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}