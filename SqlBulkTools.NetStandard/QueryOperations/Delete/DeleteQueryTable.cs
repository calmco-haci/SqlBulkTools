﻿namespace SqlBulkTools;

/// <summary>
/// Configurable options for table. 
/// </summary>
/// <typeparam name="T"></typeparam>
public class DeleteQueryTable<T>
{
    private HashSet<string> Columns { get; set; }
    private string _schema;
    private readonly string _tableName;
    private Dictionary<string, string> CustomColumnMappings { get; set; }
    private int _sqlTimeout;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tableName"></param>
    public DeleteQueryTable(string tableName)
    {
        _sqlTimeout = 600;
        _schema = Constants.DefaultSchemaName;
        Columns = new HashSet<string>();
        CustomColumnMappings = new Dictionary<string, string>();
        _tableName = tableName;
        _schema = Constants.DefaultSchemaName;
        Columns = new HashSet<string>();
        CustomColumnMappings = new Dictionary<string, string>();
    }

    /// <summary>
    /// All rows matching the condition(s) selected will be deleted. If you need to delete a collection of objects that can't be
    /// matched by a generic condition, use the BulkDelete method instead. 
    /// </summary>
    /// <returns></returns>
    public DeleteQueryCondition<T> Delete()
    {
        return new DeleteQueryCondition<T>(_tableName, _schema, _sqlTimeout);
    }

    /// <summary>
    /// Explicitly set a schema. If a schema is not added, the system default schema name 'dbo' will used.
    /// </summary>
    /// <param name="schema"></param>
    /// <returns></returns>
    public DeleteQueryTable<T> WithSchema(string schema)
    {
        _schema = schema;
        return this;
    }

    /// <summary>
    /// Default is 600 seconds. See docs for more info. 
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    public DeleteQueryTable<T> WithSqlCommandTimeout(int seconds)
    {
        _sqlTimeout = seconds;
        return this;
    }
}
