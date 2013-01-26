//
//  MaybeExtensionsSpecs.cs
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
using System.Monad.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace System.Monad.Specs
{
    [TestFixture]
    public class MaybeExtensionsSpecs
    {
        [Test]
        public void ShouldBeNoneForNullableType()
        {
            int? integer = null;
            var value = integer.SomeOrNone();
            Assert.IsInstanceOf<None<int>>(value);
        }

        [Test]
        public void ShouldBeNone()
        {
            string test = null;
            var value = test.SomeOrNone();
            Assert.IsInstanceOf<None<string>>(value);
        }

        [Test]
        public void ShouldNotGetAlternativeValue()
        {
            var value = 5.SomeOrNone().Or(6);
            Assert.AreEqual(5.SomeOrNone(), value);
        }
        
        [Test]
        public void ShouldGetAlternativeValue()
        {
            var value = Maybe.None<int>().Or(6);

            Assert.AreEqual(6.SomeOrNone(), value);
        }
    }
}

