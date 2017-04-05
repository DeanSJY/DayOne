using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DayOne.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbUtils
    {
        private static DbHolder _holder;

        /// <summary>
        /// 初始化数据库运行环境
        /// </summary>
        /// <param name="holder">存储数据库实例的方法</param>
        public static void InitializeEnvironment(DbHolder holder = null)
        {
            if (holder == null)
            {
                holder = new WebDbHolder();
            }

            _holder = holder;
        }


        public static DayOneContext CurrentDB
        {
            get
            {
                var dbContext = _holder.CurrentDB;
                if (dbContext == null)
                {
                    _holder.CurrentDB = dbContext = new DayOneContext();
                }
                return dbContext;
            }
        }

        public static void DestroyCurrentDB()
        {
            _holder.DestoryIt();
        }

        /// <summary>
        /// 存储的dbContext实例的抽象方法
        /// </summary>
        public abstract class DbHolder
        {

            /// <summary>
            /// 获取或者设置存储的数据库实例
            /// </summary>
            public abstract DayOneContext CurrentDB { get; set; }

            /// <summary>
            /// 销毁存储的数据库实例
            /// </summary>
            public void DestoryIt()
            {
                var currentDB = CurrentDB;
                if (currentDB != null)
                {
                    CurrentDB = null;
                    currentDB.Dispose();
                }
            }
        }

        /// <summary>
        /// 存储的dbContext实例
        /// </summary>
        public class WebDbHolder : DbHolder
        {
            protected const String DBCONTEXT_KEY = "__dbcontext_storage_key__";

            /// <summary>
            /// 获取httpContext对象
            /// </summary>
            private HttpContext HttpContext
            {
                get
                {
                    var httpContext = HttpContext.Current;
                    if (httpContext == null)
                    {
                        throw new InvalidProgramException("运行环境不支持HttpContext.Current");
                    }
                    return httpContext;
                }
            }

            /// <summary>
            /// 从HttpContext中获取DayOneContext
            /// </summary>
            public override DayOneContext CurrentDB
            {
                get
                {
                    return HttpContext.Items[DBCONTEXT_KEY] as DayOneContext;
                }

                set
                {
                    if (value == null)
                    {
                        HttpContext.Items.Remove(DBCONTEXT_KEY);
                    }
                    else
                    {
                        HttpContext.Items[DBCONTEXT_KEY] = value;
                    }
                }
            }
        }
    }
}
