using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GeneralLabelerStation.Tool
{
    #region 使用方法 比 lock(object){} 方式 性能高出2倍
    //UsingLock<object> _Lock = new UsingLock<object>();
    //using(_Lock.Write())
    //{
    //    ///写入操作
    //}

    //using(_Lock.Read())
    //{
    //    ///读取操作
    //}

    #endregion

    /// <summary>
    /// 使用 using 代替 lock 操作的对象，可指定写入和读取锁模式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UsingLock<T>
    {
        public UsingLock()
        {
            this.Enable = true;
        }

        public UsingLock(T data)
        {
            Enable = true;
            _Data = data;
        }

        #region 内部类
        private struct Lock:IDisposable
        {
            private ReaderWriterLockSlim _lock;
            private bool _isWrite;
            public Lock(ReaderWriterLockSlim rwl, bool isWrite)
            {
                this._lock = rwl;
                this._isWrite = isWrite;
            }

            public void Dispose()
            {
               if(this._isWrite)
                {
                    if(_lock.IsWriteLockHeld)
                        _lock.ExitWriteLock();
                }
                else
                {
                    if (_lock.IsReadLockHeld)
                        _lock.ExitReadLock();
                }

            }
        }
        #endregion

        #region 用于释放 Using的资源
        private class Disposable : IDisposable
        {
            public static readonly Disposable Empty = new Disposable();
            public void Dispose()
            {
            }
        }

        #endregion

        private ReaderWriterLockSlim _lockSlim = new ReaderWriterLockSlim();

        private T _Data;

        public bool Enable { get; set; }

        public T Data
        {
            get
            {
                if (_lockSlim.IsReadLockHeld || _lockSlim.IsWriteLockHeld)
                {
                    return _Data;
                }

                throw new Exception("请先进入写入或读写锁模式再进行操作");
            }

            set
            {
                if (_lockSlim.IsWriteLockHeld == false)
                    throw new Exception("只有写入中才能改变Data的值");

                _Data = value;
            }
        }

        /// <summary>
        /// 上读取锁的对外接口
        /// </summary>
        /// <returns></returns>
        public IDisposable Read()
        {
            if(Enable == false || _lockSlim.IsReadLockHeld || _lockSlim.IsWriteLockHeld)
            {
                return Disposable.Empty;
            }
            else
            {
                _lockSlim.EnterReadLock();
                return new Lock(_lockSlim, false);
            }
        }

        /// <summary>
        /// 上写入锁的对外接口
        /// </summary>
        /// <returns></returns>
        public IDisposable Write()
        {
            if (Enable == false || _lockSlim.IsWriteLockHeld)
            {
                return Disposable.Empty;
            }
            else if(_lockSlim.IsReadLockHeld)
            {
                throw new Exception("写入状态下不能读取");
            }
            else
            {
                _lockSlim.EnterWriteLock();
                return new Lock(_lockSlim, true);
            }
        }
    }
}
