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

namespace System.Monad.Specs.Maybe
{
    using System;
    using System.Monad.Maybe;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class OptionExtensionsSpecification
    {
        [Test]
        public void ShouldBeSomeUri()
        {
            string test = "http://test.com";
            var value = test.SomeUriOrNone();
            value.Should().BeAssignableTo<Some<Uri>>();
        }

        [Test]
        public void ShouldBeSomeInteger()
        {
            string test = "0";
            var value = test.SomeIntegerOrNone();
            value.Should().BeAssignableTo<Some<int>>();
        }

        [Test]
        public void ShouldBeNoneForNullableType()
        {
            int? integer = null;
            var value = integer.SomeOrNone();
            value.Should().BeAssignableTo<None<int>>();
        }

        [Test]
        public void ShouldBeNone()
        {
            string test = null;
            var value = test.SomeOrNone();
            value.Should().BeAssignableTo<None<string>>();
        }

        [Test]
        public void ShouldBeNoneWithEmptyString()
        {
            string test = string.Empty;
            var value = test.SomeStringOrNone();
            value.Should().BeAssignableTo<None<string>>();
        }

        [Test]
        public void ShouldBeNoneWithRhiteSpace()
        {
            string test = "   ";
            var value = test.SomeStringOrNone();
            value.Should().BeAssignableTo<None<string>>();
        }

        [Test]
        public void ShouldBeNoneUri()
        {
            string test = "   ";
            var value = test.SomeUriOrNone();
            value.Should().BeAssignableTo<None<Uri>>();
        }

        [Test]
        public void ShouldBeNoneInteger()
        {
            string test = "   ";
            var value = test.SomeIntegerOrNone();
            value.Should().BeAssignableTo<None<int>>();
        }

        [Test]
        public void ShouldGetAlternativeValue()
        {
            var value = Option.None<int>().Or(6);
            value.Should().Equal(6.SomeOrNone());
        }

        [Test]
        public void ShouldNotGetAlternativeValue()
        {
            var value = 5.SomeOrNone().Or(6);
            value.Should().Equal(5.SomeOrNone());
        }
    }
}