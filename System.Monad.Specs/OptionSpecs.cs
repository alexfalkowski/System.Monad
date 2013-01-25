//
//  OptionSpecs.cs
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
using System.Monad;
using FluentAssertions;
using NUnit.Framework;

namespace System.Monad.Specs
{
	[TestFixture]
	public class OptionSpecs
	{
		[Test]
		public void ShouldBeSome()
		{
			var value = Maybe.SomeOrNone<int>(1);
			Assert.IsInstanceOf<Some<int>>(value);
		}

		[Test]
		public void ShouldBeNone()
		{
			var value = Maybe.None<string>();
			Assert.IsInstanceOf<None<string>>(value);
		}

		[Test]
		public void ShouldDoIntoAction()
		{
			var value = Maybe.SomeOrNone<int>(1);
			var called = false;

			value.Into(test => called = true);
			Assert.IsTrue(called);
		}

		[Test]
		public void ShouldNotDoIntoAction()
		{
			var value = Maybe.None<string>();
			var called = false;
			
			value.Into(test => called = true);
			Assert.IsFalse(called);
		}

		[Test]
		public void ShouldDoIntoFunc()
		{
			var value = Maybe.SomeOrNone<int>(1);
			var result = value.Into<int>(test => 3);
			Assert.AreEqual(Maybe.SomeOrNone<int>(3), result);
		}

		[Test]
		public void ShouldDoIntoFuncWithOption()
		{
			var value = Maybe.SomeOrNone<int>(1);
			var result = value.Into<int>(test => Maybe.SomeOrNone<int>(3));
			Assert.AreEqual(Maybe.SomeOrNone<int>(3), result);
		}

		[Test]
		public void ShouldNotDoIntoFunc()
		{
			var value = Maybe.None<string>();
			var result = value.Into<string>(test => "Nope");
			Assert.AreEqual(Maybe.None<string>(), result);
		}
		
		[Test]
		public void ShouldNotDoIntoFuncWithOption()
		{
			var value = Maybe.None<string>();
			var result = value.Into<string>(test => Maybe.SomeOrNone<string>("Nope"));
			Assert.AreEqual(Maybe.None<string>(), result);
		}

		[Test]
		public void ShouldBeEqual()
		{
			Assert.AreEqual(Maybe.None<object>(), Maybe.SomeOrNone<object>(null));
			Assert.AreEqual(Maybe.SomeOrNone<int>(1), Maybe.SomeOrNone<int>(1));
		}

		[Test]
		public void ShouldHaveNoValue()
		{
			Assert.IsFalse(Maybe.None<object>().HasValue);
			Assert.IsFalse(Maybe.SomeOrNone<int>(0).HasValue);
		}
	}
}