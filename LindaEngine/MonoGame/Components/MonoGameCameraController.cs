using LindaEngine.Core.Infrastructure;
using LindaEngine.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaEngine.MonoGame.Components
{
    public class MonoGameCameraController : ICameraController
    {
        public V2 Location { get; set; }

        public MonoGameCameraController()
        {
            Center();
        }

        public void Center()
        {
            Location = V2.Zero;
        }
    }
}
