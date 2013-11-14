using System;
using System.Linq;
using System.Text;

//Implement an extension method Substring(int index, int length)
//for the class StringBuilder that returns new StringBuilder and
//has the same functionality as Substring in the class String.

namespace ExtensionMethodsLamdaAndLINQ
{
    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder builder, int index, int length)
        {
            StringBuilder result = new StringBuilder();

            for (int i = index; i < index + length; i++)
			{
                result.Append(builder[i]);
			}
            
            return result;
        }
    }
}
