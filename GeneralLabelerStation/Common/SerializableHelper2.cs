//-----------------------------------------------------------------------
// <copyright file="SerializableHelper.cs" company="鸿仕达智能科技有限公司">
// Copyright (C)2013-2018 鸿仕达智能科技有限公司 . All Rights Reserved.
// </copyright>
// <author>Sunlike</author>
// <summary></summary>
//-----------------------------------------------------------------------
namespace GeneralLabelerStation.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// class SerializableHelper{T} Defination
    /// </summary>
    /// <typeparam name="T"> Type to be serialized </typeparam>
    public class SerializableHelper<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableHelper{T}"/> class.
        /// </summary>
        /// <param name="instance">实例</param>
        public SerializableHelper(T instance)
        {
            this.instance = instance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableHelper{T}"/> class.
        /// </summary>
        public SerializableHelper()
        {
        }

        /// <summary>
        /// 实例
        /// </summary>
        private T instance;

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="path">存储路径</param>
        /// <returns>操作是否成功</returns>
        public bool XMLSerialize(string path)
        {
            bool result = false;
            try
            {
                using (TextWriter fileStream = new StreamWriter(path, false))
                {
                    fileStream.Flush();
                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
                    xmlSerialize.Serialize(fileStream, this.instance);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="path">存储路径</param>
        /// <returns>对象</returns>
        public T DeXMLSerialize(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
                        this.instance = (T)xmlSerialize.Deserialize(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.LogHelper.WriteUILog(Log.HostarLogLevel.Info, $"DeXMLSerialize:Exception-{ex.ToString()}");
            }

            return this.instance;
        }


        public string StringSerialize()
        {
            string reuslt = string.Empty;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
                    xmlSerialize.Serialize(ms, this.instance);
                    byte[] content = ms.ToArray();
                    reuslt =Convert.ToBase64String(content);
                }
            }
            catch (Exception ex)
            {
                //Log.LogHelper.WriteUILog(Log.HostarLogLevel.Info, $"StringSerialize:Exception-{ex.ToString()}");
                reuslt = string.Empty;
            }

            return reuslt;
        }

        public T DeStringSerialize(string content)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] datas = Convert.FromBase64String(content);
                    ms.Write(datas,0, datas.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
                    this.instance = (T)xmlSerialize.Deserialize(ms);
                }
            }
            catch (Exception ex)
            {
                //Log.LogHelper.WriteUILog(Log.HostarLogLevel.Info, $"DeStringSerialize:Exception-{ex.ToString()}");
            }

            return this.instance;
        }

    }
}
