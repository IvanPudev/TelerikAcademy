using System;
using System.Linq;

namespace InvalidRAngeException
{
    class InvalidRangeException<T> : ApplicationException
    {
        private readonly T begin;
        private readonly T end;

        public InvalidRangeException(T start, T end)
            : this(null, start, end, null)
        {

        }

        public InvalidRangeException(string message, T start, T end)
            : this(message, start, end, null)
        {
        }

        public InvalidRangeException(string message, T start, T end, Exception exception)
            : base(message, exception)
        {
            this.begin = start;
            this.end = end;
        }
        
        public T Begin
        {
            get { return this.begin; }
        }

        public T End
        {
            get { return this.end; }
        }
    }
}
