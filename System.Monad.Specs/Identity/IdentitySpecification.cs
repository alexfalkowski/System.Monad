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

namespace System.Monad.Specs.Identity
{
    using System;
    using System.Linq;
    using System.Monad.Identity.Extensions;
    using System.Spec;
    using FluentAssertions;

    public class IdentitySpecification : Specification
    {
        protected override void Define()
        {
            Describe("identity values", () => {
                It("should be add two integers", () => {
                    var value = from x in 5.ToIdentity()
                                from y in 6.ToIdentity()
                                select x + y;
                    value.First().Should().Be(11);
                });

                It("should be add an integer and a string", () => {
                    var value = from x in 5.ToIdentity()
                                from y in "test".ToIdentity()
                                select x + y;
                    value.First().Should().Be("5test");
                });

                It("should be add an string, integer and date", () => {
                    var value = from a in "Hello World!".ToIdentity()
                                from b in 7.ToIdentity()
                                from c in (new DateTime(2010, 1, 11)).ToIdentity()
                                select a + ", " + b + ", " + c;
                    value.First().Should().Be("Hello World!, 7, 11/01/2010 12:00:00 AM");
                });
            });
        }
    }
}