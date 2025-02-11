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

using Xunit;

namespace OnixLabs.Security.Cryptography.UnitTests
{
    public sealed class HashAsyncTests
    {
        [Fact(DisplayName = "Identical hashes should be considered equal")]
        public async void IdenticalHashesShouldBeConsideredEqual()
        {
            // Arrange
            Hash a = await Hash.ComputeSha2Hash256Async("abcdefghijklmnopqrstuvwxyz");
            Hash b = await Hash.ComputeSha2Hash256Async("abcdefghijklmnopqrstuvwxyz");

            // Assert
            Assert.Equal(a, b);
        }

        [Fact(DisplayName = "Different hashes should not be considered equal")]
        public async void DifferentHashesShouldNotBeConsideredEqual()
        {
            // Arrange
            Hash a = await Hash.ComputeSha2Hash256Async("abcdefghijklmnopqrstuvwxyz");
            Hash b = await Hash.ComputeSha2Hash256Async("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

            // Assert
            Assert.NotEqual(a, b);
        }
    }
}
