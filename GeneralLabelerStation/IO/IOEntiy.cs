using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLabelerStation.IO
{
    /// <summary>
    /// IO 实例
    /// </summary>
    public class IOInput
    {
        public IOInput(ushort axisno, ushort io)
        {
            axisno--;
            _axisno = axisno;
            io--;
            if (io > 2)
                io--;

            _io = io;
        }

        private ushort _axisno = 0;

        private ushort _io = 0;

        /// <summary>
        /// 打开IO
        /// </summary>
        /// <returns></returns>
        public short SetIO()
        {
            return IOManager.Instance.SetIO(this._axisno, this._io);
        }

        /// <summary>
        /// 释放IO
        /// </summary>
        /// <returns></returns>
        public short ResetIO()
        {
            return IOManager.Instance.ResetIO(this._axisno, this._io);
        }

        /// <summary>
        /// 获得IO状态
        /// </summary>
        /// <returns></returns>
        public bool GetIO()
        {
            return IOManager.Instance.GetInput(this._axisno, this._io);
        }
    }

    /// <summary>
    /// IO 实例
    /// </summary>
    public class IOOutput
    {
        public IOOutput(ushort axisno, ushort io)
        {
            axisno--;
            _axisno =axisno;
            _io = io;
        }

        private ushort _axisno = 0;

        private ushort _io = 0;

        /// <summary>
        /// 打开IO
        /// </summary>
        /// <returns></returns>
        public short SetIO()
        {
            return IOManager.Instance.SetIO(this._axisno, this._io);
        }

        /// <summary>
        /// 释放IO
        /// </summary>
        /// <returns></returns>
        public short ResetIO()
        {
            return IOManager.Instance.ResetIO(this._axisno, this._io);
        }
    }
}
