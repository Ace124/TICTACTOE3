using System;
using System.Collections.Generic;

namespace Task3
{
    public class Just<T> : Maybe<T>
    {
        public Just(T jValue) : base(jValue){ }
    }

    public class Nothing<T> : Maybe<T>{ }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="A"></typeparam>
    public abstract class Maybe<A> : IMonad<A>
    {
        public static implicit operator A(Maybe<A> instance)
        {
            return instance.Return();
        }

        public static implicit operator Maybe<A>(A value)
        {
            if (value == null || value.Equals(default(A)))
                return new Nothing<A>();
            else
                return new Just<A>(value);
        }

        #region Maybe_Class_Implementation

        

        public override string ToString()
        {
            string result = "";
            if (isNothing)
                result = "N<" + Return().GetType().Name + ">(" + Return().ToString() + ")";
            else
                result = "J<" + Return().GetType().Name + ">(" + Return().ToString() + ")";
            return result;
        }
        protected Maybe()
        {
            aValue = default(A);        // Nothing/Default constructor creates default(A) as value.
        }

        protected Maybe(A value)
        {
            aValue = value;
        }

        public A Value()
        {
            return aValue;
        }

        public bool isNothing
        {
            get
            {
                return this is Nothing<A>;
            }
        }

        #endregion 

        #region IMonad_Implementation

        public IMonad<B> Fmap<B>(Func<A, B> function)
        {
            Maybe<B> resMaybe = new Nothing<B>();
            if (this is Just<A> && function != null)
                resMaybe = function(aValue);        // implicit operator makes it automatically a Just or a Nothing depending on the function result.
            if (resMaybe == null)
                resMaybe = new Nothing<B>();
            return resMaybe;
        }

        public IMonad<A> Pure(A parameter)
        {
            Maybe<A> result = parameter;        // Use implicit operator to make Just or Nothing 
            return result;
        }

        public A Return()
        {
            return aValue;
        }

        public IMonad<B> App<B>(IMonad<Func<A, B>> functionMonad)
        {
            Maybe<B> result = new Nothing<B>();
            if (this is Just<A> && functionMonad != null)
            {
                foreach (var function in functionMonad)
                {
                    if (function != null)
                        result = new Just<B>(functionMonad.Return()(aValue));
                }
                if (result == null)
                    result = new Nothing<B>();
            }
            return result;
        }
        private A aValue;
        public IMonad<B> App<B>(IMonad<Func<A, IMonad<B>>> functionMonad)
        {
            IMonad<B> result = new Nothing<B>();
            if (this is Just<A> && functionMonad != null)
            {
                result = null;
                //result = functionMonad.Return()(aValue).Return();
                foreach (var function in functionMonad)
                {
                    if (function != null)
                    {
                        if (result == null)  // if first time or first time (and second...) was Nothing
                            result = function(aValue);
                        else
                        {
                            var fResult = function(aValue);
                            if (!(fResult is Nothing<B>))        // skip if result is nothing
                                result = result.Concat(fResult);
                        }
                    }
                }
                if (result == null) // If some function returned null
                    result = new Nothing<B>();
            }

            return result;
        }

        public IMonad<C> Com<B, C>(IMonad<Func<A, B, C>> functionMonad, IMonad<B> mOther)
        {
            Maybe<C> result = new Nothing<C>();

            if (!isNothing && !(mOther is Nothing<B>))         // other no nothing monad.
            {
                foreach (var function in functionMonad)
                {
                    if (function != null)
                        foreach (var otherValue in mOther)
                            result = function(aValue, otherValue);
                }
                if (result == null)
                    result = new Nothing<C>();
            }

            return result;
        }

        public IMonad<C> Com<B, C>(IMonad<Func<A, B, IMonad<C>>> functionMonad, IMonad<B> mOther)
        {
            IMonad<C> result = new Nothing<C>();

            if (!isNothing && !(mOther is Nothing<B>))         // other is no maybe and this is not nothing.
            {
                result = null;
                //resultMaybe = functionMonad.Return()(aValue, mOther.Return());
                foreach (var function in functionMonad)
                {
                    foreach (var otherValue in mOther)
                    {
                        if (result == null)       // Make result monad the monad type of the function result
                            result = function(aValue, otherValue);
                        else
                        {
                            var fResult = function(aValue, otherValue);
                            if (!(fResult is Nothing<B>))
                                result = result.Concat(fResult);
                        }
                    }
                }
                if (result == null)
                    result = new Nothing<C>();
            }

            return result;
        }

        public IMonad<C> Com<B, C>(Func<A, B, C> function, IMonad<B> mOther)
        {
            IMonad<C> resultMonad = new Nothing<C>();  // New Nothing<B> maybe
            if (!isNothing && !(mOther is Nothing<B>))
            {
                foreach (var otherValue in mOther)
                    resultMonad = new Just<C>(function(aValue, otherValue));
            }
            return resultMonad;
        }

        public IMonad<C> Com<B, C>(Func<A, B, IMonad<C>> function, IMonad<B> mOther)
        {
            IMonad<C> result = new Nothing<C>();  // New Nothing<B> maybe
            if (!isNothing && !(mOther is Nothing<B>))
            {
                result = null;
                foreach (var otherValue in mOther)
                {
                    if (result == null)
                        result = function(aValue, otherValue);
                    else
                    {
                        var fResult = function(aValue, otherValue);
                        if (!(fResult is Nothing<B>))
                            result = result.Concat(fResult);
                    }
                }
                if (result == null)
                    result = new Nothing<C>();
            }
            return result;
        }

        public IMonad<A> Visit(Action<A> action)
        {
            if (this is Just<A> && action != null)
                action(aValue);
            return this;
        }

        public IMonad<A> Visit<B>(Action<A, B> action, IMonad<B> mOther)
        {
            if (this is Just<A> && action != null && mOther != null)
                foreach (var element in mOther)
                    action(aValue, element);
            return this;
        }

        /// <summary>
        /// If this is not nothing, then the result monad is a new Maybe<A> with the value inside the other monad.
        /// </summary>
        /// <param name="otherMonad">The other monad.</param>
        /// <returns>The new monad.</returns>
        public IMonad<A> Concat(IMonad<A> otherMonad)
        {
            Maybe<A> resultMonad = new Nothing<A>();
            if (!isNothing)
                resultMonad = new Just<A>(otherMonad.Return());
            return resultMonad;
        }

        #endregion

        #region IEnumerator_Implementation

        public IEnumerator<A> GetEnumerator()
        {
            return new SingleEnumerator<A>(Return());
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new SingleEnumerator<A>(Return());
        }

        #endregion

        #region Linq_Enumerable_Implementation

        public IMonad<A> Where(Func<A, bool> predicate)
        {
            Maybe<A> result = new Nothing<A>();
            if (!this.isNothing && predicate(aValue))
                return new Just<A>(aValue);
            return result;
        }

        public IMonad<A> Where(Func<A, int, bool> predicate)
        {
            Maybe<A> result = new Nothing<A>();
            if (!this.isNothing && predicate(aValue, 0))
                result = new Just<A>(aValue);
            return result;
        }

        public IMonad<B> Select<B>(Func<A, B> f)
        {
            return Fmap<B>(f);
        }

        public IMonad<B> Select<B>(Func<A, int, B> function)
        {
            Maybe<B> resMaybe = new Nothing<B>();
            if (!this.isNothing)
                resMaybe = function(aValue, 0);
            return resMaybe;
        }

        public IMonad<B> SelectMany<B>(Func<A, IMonad<B>> f)
        {
            IMonad<B> result = new Nothing<B>();
            if (!this.isNothing)
                result = f(aValue);
            return result;
        }

        public IMonad<B> SelectMany<B>(Func<A, int, IMonad<B>> f)
        {
            IMonad<B> result = new Nothing<B>();
            if (!this.isNothing)
                result = f(aValue, 0);
            return result;
        }

        public IMonad<B> SelectMany<TMonad, B>(Func<A, IMonad<TMonad>> selector, Func<A, TMonad, B> function)
        {
            return Com<TMonad, B>(function, SelectMany(selector));
        }

        public IMonad<B> SelectMany<TMonad, B>(Func<A, int, IMonad<TMonad>> selector, Func<A, TMonad, B> function)
        {
            return Com<TMonad, B>(function, SelectMany(selector));
        }

        #endregion
    }

    public interface IMonad<A> : IEnumerable<A>
    {

        #region IMonad_Core_Interface_Function_Definitions

        // Haskell fmap from Monad, maps a function over the value inside this monad.
        IMonad<B> Fmap<B>(Func<A, B> function);

        // Haskell pure from Monad. Puts a given value in the minimal context of this monad.
        IMonad<A> Pure(A parameter);

        // Haskell return from Monad. Returns the value inside this monad.
        A Return();

        IMonad<B> App<B>(IMonad<Func<A, B>> functionMonad);

        // Haskell applicative function (operator) from Applicative. 
        // In Haskell its for a ApplicativeFunctor, but it is the same that a monad. The only established the ApplicativeFunctor later.
        IMonad<B> App<B>(IMonad<Func<A, IMonad<B>>> functionMonad);

        // Combination
        IMonad<C> Com<B, C>(Func<A, B, C> function, IMonad<B> mOther);
        IMonad<C> Com<B, C>(Func<A, B, IMonad<C>> function, IMonad<B> mOther);
        IMonad<C> Com<B, C>(IMonad<Func<A, B, C>> functionMonad, IMonad<B> mOther);
        IMonad<C> Com<B, C>(IMonad<Func<A, B, IMonad<C>>> functionMonad, IMonad<B> mOther);

        // Usefull helper function. Do a action on every element in this monad, and return this at the end.
        IMonad<A> Visit(Action<A> function);
        IMonad<A> Visit<B>(Action<A, B> action, IMonad<B> mOther);

        IMonad<A> Concat(IMonad<A> otherMonad);

        #endregion


        #region Linq_Enumerable_Connection

        IMonad<A> Where(Func<A, bool> predicate);   // filter.
        IMonad<A> Where(Func<A, int, bool> predicate);

        IMonad<B> Select<B>(Func<A, B> f);       // fmap
        IMonad<B> Select<B>(Func<A, Int32, B> f);   // fmap with index.

        IMonad<B> SelectMany<B>(Func<A, IMonad<B>> f);
        IMonad<B> SelectMany<B>(Func<A, Int32, IMonad<B>> f);
        IMonad<B> SelectMany<TMonad, B>(Func<A, IMonad<TMonad>> selector,
                                        Func<A, TMonad, B> function);
        IMonad<B> SelectMany<TMonad, B>(Func<A, Int32, IMonad<TMonad>> selector,
                                        Func<A, TMonad, B> function);

        #endregion
    }

    public abstract class AMonadDecorator<A> : IMonad<A>
    {
        #region IMonad_Core_Interface_Function_Definitions

        /*
        #region Operator_overloading

        // applicate with multiplicate operator.
        public static IMonad<A> operator *(AMonadDecorator<A> firstM, IMonad<Func<A, IMonad<A>>> functionMonad)
        {
            return firstM.App(functionMonad);
        }

        public static IMonad<A> operator *(AMonadDecorator<A> firstM, IMonad<Func<A, A>> functionMonad)
        {
            return firstM.App(functionMonad);
        }

        // Combinate with multiplicate operator.
        public static IMonad<A> operator *(AMonadDecorator<A> firstM, Tuple<IMonad<Func<A, A, A>>, IMonad<A>> tupel)
        {
            return firstM.Com<A, A>(tupel.Item1, tupel.Item2);
        }

        public static IMonad<A> operator *(AMonadDecorator<A> firstM, Tuple<IMonad<Func<A, A, IMonad<A>>>, IMonad<A>> tupel)
        {
            return firstM.Com<A, A>(tupel.Item1, tupel.Item2);
        }

        public static IMonad<A> operator /(AMonadDecorator<A> firstM, Func<A, A> functionMonad)
        {
            return firstM.Fmap(functionMonad);
        }

        public static IMonad<A> operator +(AMonadDecorator<A> firstM, ListMonad<A> otherMonad)
        {
            return firstM.Concat(otherMonad);
        }

        #endregion
        */
        // Haskell fmap from Monad, maps a function over the value inside this monad.
        public abstract IMonad<B> Fmap<B>(Func<A, B> function);

        // Haskell pure from Monad. Puts a given value in the minimal context of this monad.
        public abstract IMonad<A> Pure(A parameter);

        // Haskell return from Monad. Returns the value inside this monad.
        public A Return()
        {
            return default(A);
        }

        public abstract IMonad<B> App<B>(IMonad<Func<A, B>> functionMonad);

        // Haskell applicative function (operator) from Applicative. 
        // In Haskell its for a ApplicativeFunctor, but it is the same that a monad. The only established the ApplicativeFunctor later.
        public abstract IMonad<B> App<B>(IMonad<Func<A, IMonad<B>>> functionMonad);

        // Combination
        public abstract IMonad<C> Com<B, C>(IMonad<Func<A, B, C>> functionMonad, IMonad<B> mOther);
        public abstract IMonad<C> Com<B, C>(IMonad<Func<A, B, IMonad<C>>> functionMonad, IMonad<B> mOther);

        // Usefull helper function. Do a action on every element in this monad, and return this at the end.
        public abstract IMonad<A> Visit(Action<A> function);
        public abstract IMonad<A> Visit<B>(Action<A, B> action, IMonad<B> mOther);

        // Zip two values inside of this monad and another monad to a third result value with a given function. And pack this result value inside a new monad and return it.
        // In Haskell ZipWith is only for lists.
        public abstract IMonad<C> Com<B, C>(Func<A, B, C> function, IMonad<B> mOther);

        // same as ZipWith only that the function returns a IMonad itselfs.
        public abstract IMonad<C> Com<B, C>(Func<A, B, IMonad<C>> function, IMonad<B> mOther);

        public abstract IMonad<A> Concat(IMonad<A> otherMonad);

        #endregion

        #region Linq_Enumerable_Connection

        public abstract IMonad<B> Fmap<B>(Func<A, IMonad<B>> f);     // 

        public abstract IMonad<A> Where(Func<A, bool> predicate);   // filter.
        public abstract IMonad<A> Where(Func<A, int, bool> predicate);

        public abstract IMonad<B> Select<B>(Func<A, B> f);       // fmap
        public abstract IMonad<B> Select<B>(Func<A, Int32, B> f);   // fmap with index.

        public abstract IMonad<B> SelectMany<B>(Func<A, IMonad<B>> f);
        public abstract IMonad<B> SelectMany<B>(Func<A, Int32, IMonad<B>> f);
        public abstract IMonad<B> SelectMany<TMonad, B>(Func<A, IMonad<TMonad>> selector, Func<A, TMonad, B> function);
        public abstract IMonad<B> SelectMany<TMonad, B>(Func<A, Int32, IMonad<TMonad>> selector, Func<A, TMonad, B> function);

        #endregion

        public IEnumerator<A> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    // <summary>
    /// MaybeEnumb always has only one element!
    /// The element is default(A) if maybe is Nothing<A>, if its Just<A> then the element is the just value. 
    /// Be carefull default(A) can be null!!!!
    /// </summary>
    /// <typeparam name="A"></typeparam>
    public class SingleEnumerator<A> : IEnumerator<A>
    {
        private A aValue = default(A);
        private bool next = true;

        public SingleEnumerator(A value)
        {
            aValue = value;
        }

        public A Current
        {
            get
            {
                next = false;
                return aValue;
            }
        }

        public void Dispose()
        {
            return;
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                next = false;
                return aValue;
            }
        }

        public bool MoveNext()
        {
            return next;
        }

        public void Reset()
        {
            next = true;
        }
    }
}
