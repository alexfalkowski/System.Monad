// Author:
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

namespace System.Monad.Specs.Collections
{
    using System.Linq;
    using System.Monad.Collections;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class EnumerableExtensionsSpecification
    {
        [Test]
        public void ShouldMapAndReduceInteger()
        {
            var result = Enumerable.Range(1, 5).Map(x => x).Reduce((x, y) => x + y);
            result.Should().Be(15);
        }

        [Test]
        public void ShouldMapAndReduceString()
        {
            var result = Enumerable.Range(1, 5).Map(x => x.ToString()).Reduce((x, y) => x + y);
            result.Should().Be("12345");
        }
    }
}