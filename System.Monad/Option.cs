//
//  Option.cs
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
using System.Collections;
using System.Collections.Generic;

namespace System.Monad
{
	public abstract class Option<T> : IOption<T>
	{
		public virtual bool HasValue
		{
			get
			{
				return false;   
			}
		}
		
		public abstract IEnumerator<T> GetEnumerator();
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		
		public abstract IOption<TResult> Into<TResult>(Func<T, IOption<TResult>> fn);
		
		public abstract IOption<TResult> Into<TResult>(Func<T, TResult> fn);
		
		public abstract void Into(Action<T> action);
	}
}