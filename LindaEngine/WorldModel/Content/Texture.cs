using LindaEngine.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LindaEngine.WorldModel.Content
{
    public class Texture
    {
        public string ContentSet { get; set; }
        public string ContentName { get; set; }
        public object Content { get; set; }
        
        public Rect GetSourceRectangle()
        {
            return Rect.Empty;
        }
    }
}
