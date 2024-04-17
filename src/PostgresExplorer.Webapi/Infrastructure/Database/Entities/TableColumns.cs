namespace PostgresExplorer.Webapi.Infrastructure.Database.Entities
{
    public class TableColumns
    {
        public string Column { get; private set; }
        public string Type { get; private set; }

        public TableColumns(string column, string type)
        {
            Column = column;
            Type = type;
        }
    }
}
