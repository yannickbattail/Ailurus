using System;

namespace Ailurus.Model
{
    public class Optional<T>
    {
        private T value;

        public T Value
        {
            get { return value; }
        }

        public bool IsPresent
        {
            get { return value == null; }
        }

        private Optional()
        {
        }

        public static Optional<T> For(T val)
        {
            var opt = new Optional<T>();
            opt.value = val;
            return opt;
        }

        public static Optional<T> Empty()
        {
            return new Optional<T>();
        }

        // map makes it easy to work with pure functions
        //public Optional<TOut> Map<TIn, TOut>(Func<TIn, TOut> f) where TIn : T 
        public Optional<TOut> Map<TOut>(Func<T, TOut> f)
        {
            return IsPresent ? Optional<TOut>.For(f(value)) : Optional<TOut>.Empty();
        }

        // foreach is for side-effects
        public Optional<T> Foreach(Action<T> f)
        {
            if (IsPresent) f(value);
            return this;
        }

        // getOrElse for defaults
        public T GetOrElse(Func<T> f)
        {
            return IsPresent ? value : f();
        }

        public T GetOrElse(T defaultValue)
        {
            return IsPresent ? value : defaultValue;
        }

        // orElse for taking actions when dealing with `None`
        public void OrElse(Action f)
        {
            if (!IsPresent) f();
        }
    }
}