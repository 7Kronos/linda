using LindaEngine.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LindaEngine.Core.Infrastructure
{
    public interface ICameraController
    {
        V2 Location { get; }

        void Center();
    }
}
