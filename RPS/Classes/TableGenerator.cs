using BetterConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Classes
{
    internal class TableGenerator
    {
        private Table table;
        public TableGenerator(string[] headers, string[][] rows)
        {
            table = new Table(TableConfiguration.MySql());
            FillHeader(headers);
            FillRows(rows);
        }
        public TableGenerator()
        {
            table = new Table(TableConfiguration.MySql());
        }
        public void FillHeader(string[] headers)
        {
            ColumnHeader[] colHeaders = new ColumnHeader[headers.Length];
            foreach (var header in headers)
            {
                table.AddColumn(header);
            }
        }
        public void FillRows(string[][] rows)
        {
            for (int i = 0; i < rows.GetLength(0); i++)
            {
                table.AddRow(rows[i]);
            }
        }
        public void AddRow(string[] row) 
        {
            table.AddRow(row);
        }
        public void DrawTable()
        {
            Console.WriteLine(table.ToString());
        }
    }
}
