using System;
using CSVAnalytics;

namespace API
{
    public class Table
    {
        public CSVTable CsvTable { get; set; }
        
        public Table(CSVTable table)
        {
            CsvTable = table;
        }
    }

}