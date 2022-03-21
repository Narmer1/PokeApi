using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi.Model
{
    public class RegionModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
