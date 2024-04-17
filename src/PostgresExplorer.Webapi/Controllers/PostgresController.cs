using Microsoft.AspNetCore.Mvc;
using PostgresExplorer.Webapi.Controllers.Response;
using PostgresExplorer.Webapi.Infrastructure.Database.Repositories;
using System.ComponentModel.DataAnnotations;

namespace PostgresExplorer.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostgresController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult GetSchemas()
        {
            var repository = new PostgresRepository();

            var schemas = repository.GetSchemas();

            return Ok(schemas.ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(TableResponse), 200)]
        [Route("schema/{schema}")]
        public IActionResult GetTables([FromRoute][Required] string schema)
        {
            var repository = new PostgresRepository();
            var tables = repository.GetTables(schema);
            var response = new TableResponse(schema, tables.ToArray());

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(TableDetailsResponse), 200)]
        [Route("schema/{schema}/table/{table}")]
        public IActionResult GetTableDetails([FromRoute][Required] string schema, [FromRoute][Required] string table)
        {
            var repository = new PostgresRepository();
            var columns = repository.GetTableColumns(schema, table);

            var responseColumns = new List<TableColumns>();

            columns.ForEach(f=> responseColumns.Add(new TableColumns(f.Column, f.Type)));

            var response = new TableDetailsResponse(schema, table, responseColumns.ToArray());

            return Ok(response);
        }
    }
}
