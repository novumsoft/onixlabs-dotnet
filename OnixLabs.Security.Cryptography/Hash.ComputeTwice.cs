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

using System.Security.Cryptography;
using System.Text;

namespace OnixLabs.Security.Cryptography
{
    public readonly partial struct Hash
    {
        /// <summary>
        /// Computes a twice-hashed hash of the specified value using the specified <see cref="HashAlgorithmType"/>.
        /// </summary>
        /// <param name="value">The value for which to compute a hash.</param>
        /// <param name="type">The hash algorithm type of the computed hash.</param>
        /// <returns>Returns a <see cref="Hash"/> representing a twice-hashed hash of the specified value.</returns>
        public static Hash ComputeHashTwice(string value, HashAlgorithmType type)
        {
            return ComputeHashTwice(value, type, Encoding.Default);
        }

        /// <summary>
        /// Computes a twice-hashed hash of the specified value using the specified <see cref="HashAlgorithmType"/>.
        /// </summary>
        /// <param name="value">The value for which to compute a hash.</param>
        /// <param name="type">The hash algorithm type of the computed hash.</param>
        /// <param name="encoding">The encoding which will be used to convert the input string into a byte array.</param>
        /// <returns>Returns a <see cref="Hash"/> representing a twice-hashed hash of the specified value.</returns>
        public static Hash ComputeHashTwice(string value, HashAlgorithmType type, Encoding encoding)
        {
            return ComputeHashTwice(encoding.GetBytes(value), type);
        }

        /// <summary>
        /// Computes a twice-hashed hash of the specified value using the specified <see cref="HashAlgorithmType"/>.
        /// </summary>
        /// <param name="value">The value for which to compute a hash.</param>
        /// <param name="type">The hash algorithm type of the computed hash.</param>
        /// <param name="length">The output length of the computed hash in bytes.</param>
        /// <returns>Returns a <see cref="Hash"/> representing a twice-hashed hash of the specified value.</returns>
        public static Hash ComputeHashTwice(string value, HashAlgorithmType type, int length)
        {
            return ComputeHashTwice(value, type, Encoding.Default, length);
        }

        /// <summary>
        /// Computes a twice-hashed hash of the specified value using the specified <see cref="HashAlgorithmType"/>.
        /// </summary>
        /// <param name="value">The value for which to compute a hash.</param>
        /// <param name="type">The hash algorithm type of the computed hash.</param>
        /// <param name="encoding">The encoding which will be used to convert the input string into a byte array.</param>
        /// <param name="length">The output length of the computed hash in bytes.</param>
        /// <returns>Returns a <see cref="Hash"/> representing a twice-hashed hash of the specified value.</returns>
        public static Hash ComputeHashTwice(string value, HashAlgorithmType type, Encoding encoding, int length)
        {
            return ComputeHashTwice(encoding.GetBytes(value), type, length);
        }

        /// <summary>
        /// Computes a twice-hashed hash of the specified value using the specified <see cref="HashAlgorithmType"/>.
        /// </summary>
        /// <param name="value">The value for which to compute a hash.</param>
        /// <param name="type">The hash algorithm type of the computed hash.</param>
        /// <returns>Returns a <see cref="Hash"/> representing a twice-hashed hash of the specified value.</returns>
        public static Hash ComputeHashTwice(byte[] value, HashAlgorithmType type)
        {
            using HashAlgorithm algorithm = type.GetHashAlgorithm();
            byte[] firstRoundValue = algorithm.ComputeHash(value);
            byte[] secondRoundValue = algorithm.ComputeHash(firstRoundValue);
            return FromByteArray(secondRoundValue, type);
        }

        /// <summary>
        /// Computes a twice-hashed hash of the specified value using the specified <see cref="HashAlgorithmType"/>.
        /// </summary>
        /// <param name="value">The value for which to compute a hash.</param>
        /// <param name="type">The hash algorithm type of the computed hash.</param>
        /// <param name="length">The output length of the computed hash in bytes.</param>
        /// <returns>Returns a <see cref="Hash"/> representing a twice-hashed hash of the specified value.</returns>
        public static Hash ComputeHashTwice(byte[] value, HashAlgorithmType type, int length)
        {
            using HashAlgorithm algorithm = type.GetHashAlgorithm(length);
            byte[] firstRoundValue = algorithm.ComputeHash(value);
            byte[] secondRoundValue = algorithm.ComputeHash(firstRoundValue);
            return FromByteArray(secondRoundValue, type);
        }
    }
}
