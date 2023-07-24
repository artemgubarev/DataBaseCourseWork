using System.Collections.Generic;

namespace DataBaseCourseWork.TestDataGenerator
{
    /// <summary>
    /// 
    /// </summary>
    internal class TestDataRow
    {
        public TestDataRow(string query, IEnumerable<object> data, string[] parameterNames)
        {
            Query = query;
            Data = data;
            ParameterNames = parameterNames;
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<object> Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string[] ParameterNames { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Query { get; set; }
    }
}
