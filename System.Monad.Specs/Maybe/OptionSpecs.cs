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
using System.Monad.Maybe;
using FluentAssertions;
using NUnit.Framework;

namespace System.Monad.Specs.Maybe
{
	[TestFixture]
	public class OptionSpecs
	{
        [Test]
        public void ShouldBeSome()
        {
            var value = Option.SomeOrNone<int>(1);
            value.Should().BeAssignableTo<Some<int>>();
        }

        [Test]
        public void ShouldBeNone()
        {
            var value = Option.None<string>();
            value.Should().BeAssignableTo<None<string>>();
        }

        [Test]
        public void ShouldDoIntoAction()
        {
            var value = Option.SomeOrNone<int>(1);
            var called = false;

            value.Into(test => called = true);
            called.Should().BeTrue();
        }

        [Test]
        public void ShouldNotDoIntoAction()
        {
            var value = Option.None<string>();
            var called = false;

            value.Into(test => called = true);
            called.Should().BeFalse();
        }

        [Test]
        public void ShouldDoIntoFunc()
        {
            var value = Option.SomeOrNone<int>(1);
            var result = value.Into<int>(test => 3);
            result.Should().Equal(Option.SomeOrNone<int>(3));
        }

        [Test]
        public void ShouldDoIntoFuncWithOption()
        {
            var value = Option.SomeOrNone<int>(1);
            var result = value.Into<int>(test => Option.SomeOrNone<int>(3));
            result.Should().Equal(Option.SomeOrNone<int>(3));
        }

        [Test]
        public void ShouldNotDoIntoFunc()
        {
            var value = Option.None<string>();
            var result = value.Into<string>(test => "Nope");
            result.Should().Equal(Option.None<string>());
        }

        [Test]
        public void ShouldNotDoIntoFuncWithOption()
        {
            var value = Option.None<string>();
            var result = value.Into<string>(test => Option.SomeOrNone<string>("Nope"));
            result.Should().Equal(Option.None<string>());
        }

        [Test]
        public void ShouldBeEqual()
        {
            Option.None<object>().Should().Equal(Option.SomeOrNone<object>(null));
            Option.SomeOrNone<int>(1).Should().Equal(Option.SomeOrNone<int>(1));
        }

        [Test]
        public void ShouldHaveNoValue()
        {
            Option.None<object>().HasValue.Should().BeFalse();
            Option.SomeOrNone<int>(0).HasValue.Should().BeFalse();
        }
    }
}