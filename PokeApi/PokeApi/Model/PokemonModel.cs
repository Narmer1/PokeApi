using PokeApiNet;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PokeApi.Model
{
    public class PokemonModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int IDPokedex { get; set; }
        public string Name { get; set; }
        public String DefaultSprite { get; set; }
        public String Type1 { get; set; }
        public String Type2 { get; set; }
    }
}