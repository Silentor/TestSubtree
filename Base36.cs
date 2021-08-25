using System;
using System.Collections.Generic;

namespace Flexy.Utils3.Runtime
{
    public static class Base36
    {
        private const string CHARACTERS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static UInt32 Decode(string value)
        {
            if ( String.IsNullOrEmpty( value ) )
                return 0;
            value = value.TrimStart( '0' ).ToUpperInvariant();
            Int64 number = 0;
            foreach(char c in value.ToUpperInvariant())
                number = number * 36 + CHARACTERS.IndexOf(c);

            return (UInt32)number;
        }

        public static String Encode(UInt32 input)
        {
            var result = new Stack<char>();
            while (input != 0)
            {
                result.Push(CHARACTERS[(Int32)(input % 36)]);
                input /= 36;
            }
            return new string(result.ToArray());
        }
    }
}
