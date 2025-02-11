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

using System;
using System.Linq;

namespace OnixLabs.Security.Cryptography
{
    public readonly partial struct Hash
    {
        /// <summary>
        /// Creates an all-zero hash of the specified length. This will create a hash of an unknown type.
        /// </summary>
        /// <param name="length">The length of the hash in bytes.</param>
        /// <returns>Returns an all-zero <see cref="Hash"/> of the specified length.</returns>
        public static Hash CreateAllZeroHash(int length)
        {
            return CreateAllZeroHash(HashAlgorithmType.Unknown, length);
        }

        /// <summary>
        /// Creates an all-zero hash of the specified hash algorithm type.
        /// </summary>
        /// <param name="type">The type of hash to create.</param>
        /// <returns>Returns an all-zero <see cref="Hash"/> of the specified hash algorithm type.</returns>
        public static Hash CreateAllZeroHash(HashAlgorithmType type)
        {
            return CreateAllZeroHash(type, type.Length);
        }

        /// <summary>
        /// Creates an all-zero hash of the specified hash algorithm type and length.
        /// </summary>
        /// <param name="type">The type of hash to create.</param>
        /// <param name="length">The length of the hash in bytes.</param>
        /// <returns>Returns an all-zero <see cref="Hash"/> of the specified hash algorithm type and length.</returns>
        /// <exception cref="ArgumentException">If the length of the hash is unexpected.</exception>
        public static Hash CreateAllZeroHash(HashAlgorithmType type, int length)
        {
            if (type.Length != HashAlgorithmType.UnknownLength && type.Length != length)
            {
                throw new ArgumentException("Unexpected hash algorithm output length.");
            }

            byte[] bytes = Enumerable.Repeat(byte.MinValue, length).ToArray();
            return FromByteArray(bytes, type);
        }
    }
}
