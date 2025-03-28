﻿using SqlBulkTools.BulkCopy;

namespace SqlBulkTools
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BulkForCollection<T>
    {
        private readonly BulkOperations bulk;
        private readonly IEnumerable<T> _list;
        private Dictionary<string, Type> _propTypes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bulk"></param>
        /// <param name="list"></param>
        public BulkForCollection(BulkOperations bulk, IEnumerable<T> list)
        {
            this.bulk = bulk;
            _list = list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propTypes"></param>
        /// <returns></returns>
        public BulkForCollection<T> WithPropertyTypes(Dictionary<string, Type> propTypes)
        {
            _propTypes = propTypes;
            return this;
        }

        /// <summary>
        /// Set the name of table for operation to take place. Registering a table is Required.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public BulkTable<T> WithTable(string tableName)
        {
            var table = BulkOperationsHelper.GetTableAndSchema(tableName);
            return new BulkTable<T>(bulk, _list, _propTypes, table.Name, table.Schema);
        }
    }
}
