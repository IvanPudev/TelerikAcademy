using System;
using System.Collections.Generic;
using System.Linq;

//Implement a set of extension methods for IEnumerable<T> that
//implement the following group functions: sum, product, min, max, average.

namespace IEnumerableExtension
{
    public static class IExtensions
    {
       public static T MySum<T>(this IEnumerable<T> collection) 
       {
           T sum = collection.FirstOrDefault();
           foreach (T item in collection.Skip(1))
           {
               sum += (dynamic)item;
           }
           return sum;
       }

       public static T MyProduct<T>(this IEnumerable<T> collection)
       {
           T product = collection.FirstOrDefault();
           foreach (T item in collection.Skip(1))
           {
               product *= (dynamic)item;
           }
           return product;
       }

       public static T MyMin<T>(this IEnumerable<T> collection) where T : IComparable<T>
       {
           T min = collection.FirstOrDefault();
           foreach (T item in collection)
           {
               if ((dynamic)item.CompareTo(min) < 0)
               {
                   min = (dynamic)item;
               } 
           }
           return min;
       }

       public static T MyMax<T>(this IEnumerable<T> collection) where T : IComparable<T>
       {
           T max = collection.FirstOrDefault();
           foreach (T item in collection)
           {
               if ((dynamic)item.CompareTo(max) > 0)
               {
                   max = (dynamic)item;
               }
           }
           return max;
       }

       public static decimal MyAverage<T>(this IEnumerable<T> collection)
       {
           decimal average = 0;
           int count = 0;
           if (typeof(T) == typeof(string))
           {
               throw new InvalidOperationException("Can not find average of strings.");
           }
           foreach (T item in collection)
           {
               average += (dynamic)item;
               count++;
           }
           if (count == 0)
           {
               throw new DivideByZeroException("Divide by zero.");
           }
           return average/count;
       }
    }
}