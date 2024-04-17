namespace PostgresExplorer.Webapi.Controllers.Response
{
    public class TableDetailsResponse
    {
        public string Schema { get; set; }
        public string Table { get; set; }
        public TableColumns[] Columns { get; set; }

        public TableDetailsResponse(string schema, string table, TableColumns[] columns)
        {
            Schema = schema;
            Table = table;
            Columns = columns;
        }
    }

    public class TableColumns
    {
        public string Column { get; set; }
        public string ColumnType { get; set; }

        public TableColumns(string column, string columnType)
        {
            Column = column;
            ColumnType = columnType;
        }
    }
}
