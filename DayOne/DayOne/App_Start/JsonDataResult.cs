using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayOne.App_Start
{
    public class JsonDataList
    {

        public static Result<T> CreateResult<T>(IQueryable<T> statement, int start = 0, int limit = 10)
        {
            var result = new Result<T>
            {
                Start = start,
                Total = statement.Count(),
                DataList = statement.Skip(start).Take(limit).ToList()
            };
            
            return result;
        }

        public static Result<TResult> CreateResult<T, TResult>(IQueryable<T> statement, Func<T, TResult> selector,
            int start = 0, int limit = 10)
        {
            var result = new Result<TResult>
            {
                Start = start,
                Total = statement.Count(),
                DataList = statement.Select(selector).Skip(start).Take(limit).ToList()
            };

            return result;
        }

        public static Result<TResult> CreateTransformResult<T, TResult>(IQueryable<T> statement,
            Func<T, TResult> transformFn, int start = 0, int limit = 10)
        {
            var totalCount = statement.Count();
            var dataList = statement.Skip(start).Take(limit).ToList();

            return new Result<TResult>
            {
                Start = start,
                Total = totalCount,
                DataList = dataList.ConvertAll(o => transformFn(o))
            };
        }

        public class Result<T>
        {
            public int Total { get; set; }

            public int Start { get; set; }

            public IList<T> DataList { get; set; }
        }
    }
}