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
            value.Should().BeAssignableTo<Some<int>>();
        }

        [Test]
        public void ShouldBeNone()
        {
            var value = Maybe.None<string>();
            value.Should().BeAssignableTo<None<string>>();
        }

        [Test]
        public void ShouldDoIntoAction()
        {
            var value = Maybe.SomeOrNone<int>(1);
            var called = false;

            value.Into(test => called = true);
            called.Should().BeTrue();
        }

        [Test]
        public void ShouldNotDoIntoAction()
        {
            var value = Maybe.None<string>();
            var called = false;

            value.Into(test => called = true);
            called.Should().BeFalse();
        }

        [Test]
        public void ShouldDoIntoFunc()
        {
            var value = Maybe.SomeOrNone<int>(1);
            var result = value.Into<int>(test => 3);
            result.Should().Equal(Maybe.SomeOrNone<int>(3));
        }

        [Test]
        public void ShouldDoIntoFuncWithOption()
        {
            var value = Maybe.SomeOrNone<int>(1);
            var result = value.Into<int>(test => Maybe.SomeOrNone<int>(3));
            result.Should().Equal(Maybe.SomeOrNone<int>(3));
        }

        [Test]
        public void ShouldNotDoIntoFunc()
        {
            var value = Maybe.None<string>();
            var result = value.Into<string>(test => "Nope");
            result.Should().Equal(Maybe.None<string>());
        }

        [Test]
        public void ShouldNotDoIntoFuncWithOption()
        {
            var value = Maybe.None<string>();
            var result = value.Into<string>(test => Maybe.SomeOrNone<string>("Nope"));
            result.Should().Equal(Maybe.None<string>());
        }

        [Test]
        public void ShouldBeEqual()
        {
            Maybe.None<object>().Should().Equal(Maybe.SomeOrNone<object>(null));
            Maybe.SomeOrNone<int>(1).Should().Equal(Maybe.SomeOrNone<int>(1));
        }

        [Test]
        public void ShouldHaveNoValue()
        {
            Maybe.None<object>().HasValue.Should().BeFalse();
            Maybe.SomeOrNone<int>(0).HasValue.Should().BeFalse();
        }
    }
}