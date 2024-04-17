using System.ComponentModel.DataAnnotations;

namespace PostgresExplorer.Webapi.Controllers.Response
{
    public class SchemaResponse
    {
        [Required]
        public string Schema { get; set; }
    }
}
