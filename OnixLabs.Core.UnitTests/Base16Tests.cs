// Copyright 2020-2021 ONIXLabs
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using OnixLabs.Core.Text;
using Xunit;

namespace OnixLabs.Core.UnitTests
{
    public sealed class Base16Tests
    {
        [Fact(DisplayName = "Identical Base16 values produce identical hash codes.")]
        public void IdenticalBase16ValuesProduceIdenticalHashCodes()
        {
            // Arrange
            Base16 a = Base16.FromString("abcdefghijklmnopqrstuvwxyz");
            Base16 b = Base16.FromString("abcdefghijklmnopqrstuvwxyz");
            
            // Act
            int hashCodeA = a.GetHashCode();
            int hashCodeB = b.GetHashCode();

            // Assert
            Assert.Equal(hashCodeA, hashCodeB);
        }

        [Theory(DisplayName = "Base16_FromString should produce the expected Base-16 value.")]
        [InlineData("31323334353637383930", "1234567890")]
        [InlineData("4142434445464748494a4b4c4d4e4f505152535455565758595a", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [InlineData("6162636465666768696a6b6c6d6e6f707172737475767778797a", "abcdefghijklmnopqrstuvwxyz")]
        public void Base16FromStringShouldProduceTheExpectedBase16Value(string expected, string value)
        {
            // Arrange
            Base16 candidate = Base16.FromString(value);

            // Act
            string actual = candidate.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "Base16_Parse should produce the expected plain text value.")]
        [InlineData("1234567890", "31323334353637383930")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "4142434445464748494a4b4c4d4e4f505152535455565758595a")]
        [InlineData("abcdefghijklmnopqrstuvwxyz", "6162636465666768696a6b6c6d6e6f707172737475767778797a")]
        public void Base16ParseShouldProduceTheExpectedPlainTextValue(string expected, string value)
        {
            // Arrange
            Base16 candidate = Base16.Parse(value);

            // Act
            string actual = candidate.ToPlainTextString();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
