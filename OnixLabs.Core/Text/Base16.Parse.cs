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

namespace OnixLabs.Core.Text
{
    public readonly partial struct Base16
    {
        /// <summary>
        /// Parses a Base-16 (hexadecimal) value into a <see cref="Base16"/> instance.
        /// </summary>
        /// <param name="value">The Base-16 (hexadecimal) value to parse.</param>
        /// <returns>Returns a new <see cref="Base16"/> instance.</returns>
        public static Base16 Parse(string value)
        {
            ReadOnlySpan<char> characters = value.AsSpan();
            return Parse(characters);
        }

        /// <summary>
        /// Parses a Base-16 (hexadecimal) value into a <see cref="Base16"/> instance.
        /// </summary>
        /// <param name="value">The Base-16 (hexadecimal) value to parse.</param>
        /// <returns>Returns a new <see cref="Base16"/> instance.</returns>
        public static Base16 Parse(char[] value)
        {
            ReadOnlySpan<char> characters = value.AsSpan();
            return Parse(characters);
        }

        /// <summary>
        /// Parses a Base-16 (hexadecimal) value into a <see cref="Base16"/> instance.
        /// </summary>
        /// <param name="value">The Base-16 (hexadecimal) value to parse.</param>
        /// <returns>Returns a new <see cref="Base16"/> instance.</returns>
        public static Base16 Parse(ReadOnlySpan<char> value)
        {
            byte[] bytes = Convert.FromHexString(value);
            return FromByteArray(bytes);
        }
    }
}
