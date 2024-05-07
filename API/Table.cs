using System;
using CSVAnalytics;

namespace API
{
    public class Table
    {
        public CSVTable table { get; set; }
        
        public Table(CSVTable table)
        {
            this.table = table;
        }
    }

}