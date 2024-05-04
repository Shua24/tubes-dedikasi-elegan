using System;

namespace API
{
    public class Table
    {
        public List<(object, object)> antibioticsList { get; set; }

        public Table(List<(object, object)> antibioticsList)
        {
            this.antibioticsList = antibioticsList;
        }
    }
}
