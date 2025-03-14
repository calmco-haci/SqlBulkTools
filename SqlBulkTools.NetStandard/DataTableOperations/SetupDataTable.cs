﻿namespace SqlBulkTools;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class SetupDataTable<T>
{
    private readonly DataTableOperations _ext;
    private Dictionary<string, Type> _propTypes;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ext"></param>
    public SetupDataTable(DataTableOperations ext)
    {
        _ext = ext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="propTypes"></param>
    /// <returns></returns>
    public SetupDataTable<T> WithPropertyTypes(Dictionary<string, Type> propTypes)
    {
        _propTypes = propTypes;
        return this;
    }

    /// <summary>
    /// Supply the collection that you want a DataTable generated for.
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public DataTableColumns<T> ForCollection(IEnumerable<T> list)
    {
        return new DataTableColumns<T>(list, _propTypes, _ext);
    }
}
