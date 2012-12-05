using Persistence.WorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Content;

namespace World.Map
{
    public class Tile : Entity
    {
        public Texture Texture { get; set; }
        public bool Clipping { get; set; }
    }
}
