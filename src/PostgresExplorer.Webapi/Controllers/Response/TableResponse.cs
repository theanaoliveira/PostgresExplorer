namespace PostgresExplorer.Webapi.Controllers.Response
{
    public class TableResponse
    {
        public string Schema { get; set; }
        public string[] Tables { get; set; }

        public TableResponse(string schema, string[] tables)
        {
            Schema = schema;
            Tables = tables;
        }
    }
}
