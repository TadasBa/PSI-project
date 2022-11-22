using Pantry.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pantry.Utilities
{
    public class ConcurrentHashSet<T> : IDisposable
    {
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        private readonly HashSet<T> _hashSet = new HashSet<T>();
        public bool Add(T item)
        {
            try
            {
                _lock.EnterWriteLock();
                return _hashSet.Add(item);
            }
            finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }
        }

        public void Clear()
        {
            try
            {
                _lock.EnterWriteLock();
                _hashSet.Clear();
            }
            finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }
        }

        public bool Contains(T item)
        {
            try
            {
                _lock.EnterReadLock();
                return _hashSet.Contains(item);
            }
            finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitReadLock();
            }
        }

        public bool Remove(T item)
        {
            try
            {
                _lock.EnterWriteLock();
                return _hashSet.Remove(item);
            }
            finally
            {
                if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
            }
        }

        public void ForEach(Action<T> func)
        {
            try
            {
                _lock.EnterWriteLock();
                foreach (var i in _hashSet)
                {
                    func.Invoke(i);
                }
            }
            finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitWriteLock();
            }
        }

        public int Count
        {
            get
            {
                try
                {
                    _lock.EnterReadLock();
                    return _hashSet.Count;
                }
                finally
                {
                    if (_lock.IsReadLockHeld) _lock.ExitReadLock();
                }
            }
        }
        public void Dispose()
        {
            if (_lock != null) _lock.Dispose();
        }

        public List<T> GetAll()
        {
            try
            {
                _lock.EnterWriteLock();
                return new List<T>(_hashSet);
            }
            finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitWriteLock();
            }
        }

        internal void ForEach(Action<Product> value1, Func<object, Task<bool>> value2)
        {
            Exception e = new NotImplementedException();
            ExceptionLogger.LogExceptionToFile(e, "ForEach method not implemented");
            throw e;
        }
    }
}
