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

namespace System.Monad.Specs.Maybe
{
    using System;
    using System.Monad.Maybe;
    using System.Monad.Maybe.Extensions;
    using System.Spec;
    using FluentAssertions;

    public class OptionExtensionsSpecification : Specification
    {
        public override void Validate()
        {
            Describe("some values", describe => {
                describe.It("should be some uri", () => {
                    string test = "http://test.com";
                    var value = test.SomeUriOrNone();
                    value.Should().BeAssignableTo<Some<Uri>>();
                });

                describe.It("should be some integer", () => {
                    string test = "0";
                    var value = test.SomeIntegerOrNone();
                    value.Should().BeAssignableTo<Some<int>>();
                });
            });

            Describe("none values", describe => {
                describe.It("should be none for nullable type", () => {
                    int? integer = null;
                    var value = integer.SomeOrNone();
                    value.Should().BeAssignableTo<None<int>>();
                });

                describe.It("should be none", () => {
                    string test = null;
                    var value = test.SomeOrNone();
                    value.Should().BeAssignableTo<None<string>>();
                });

                describe.It("should be none with empty string", () => {
                    string test = string.Empty;
                    var value = test.SomeStringOrNone();
                    value.Should().BeAssignableTo<None<string>>();
                });

                describe.It("should be none with white space", () => {
                    string test = "   ";
                    var value = test.SomeStringOrNone();
                    value.Should().BeAssignableTo<None<string>>();
                });

                describe.It("should be none uri", () => {
                    string test = "   ";
                    var value = test.SomeUriOrNone();
                    value.Should().BeAssignableTo<None<Uri>>();
                });

                describe.It("should be none integer", () => {
                    string test = "   ";
                    var value = test.SomeIntegerOrNone();
                    value.Should().BeAssignableTo<None<int>>();
                });
            });

            Describe("alternative values", describe => {
                describe.It("should not get alternative value", () => {
                    var value = 5.SomeOrNone().Or(6);
                    value.Should().Equal(5.SomeOrNone());
                });
                
                describe.It("should get alternative value", () => {
                    var value = Option.None<int>().Or(6);
                    value.Should().Equal(6.SomeOrNone());
                });
            });
        }
    }
}