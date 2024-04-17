using Microsoft.EntityFrameworkCore;
using Npgsql;
using PostgresExplorer.Webapi.Infrastructure.Database.Entities;

namespace PostgresExplorer.Webapi.Infrastructure.Database.Repositories
{
    public class PostgresRepository
    {
        public List<string> GetSchemas()
        {
            using var context = new Context();

            var schemas = new List<string>();

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT schema_name FROM information_schema.schemata WHERE schema_name NOT LIKE 'pg_%' AND schema_name != 'information_schema'";
                context.Database.OpenConnection();

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    schemas.Add(reader.GetString(0));
                }
            }

            return schemas;
        }

        public List<string> GetTables(string schema)
        {
            using var context = new Context();

            var tables = new List<string>();

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT table_name FROM information_schema.tables WHERE table_schema = @schema";
                command.Parameters.Add(new NpgsqlParameter("@schema", NpgsqlTypes.NpgsqlDbType.Text) { Value = schema });

                context.Database.OpenConnection();

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }
            }

            return tables;
        }

        public List<TableColumns> GetTableColumns(string schema, string table)
        {
            using var context = new Context();

            var tables = new List<TableColumns>();

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT column_name, data_type  FROM information_schema.columns where table_schema = @schema and table_name = @table;";
                command.Parameters.Add(new NpgsqlParameter("@schema", NpgsqlTypes.NpgsqlDbType.Text) { Value = schema });
                command.Parameters.Add(new NpgsqlParameter("@table", NpgsqlTypes.NpgsqlDbType.Text) { Value = table });

                context.Database.OpenConnection();

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tables.Add(new TableColumns(reader.GetString(0), reader.GetString(1)));
                }
            }

            return tables;
        }
    }
}
