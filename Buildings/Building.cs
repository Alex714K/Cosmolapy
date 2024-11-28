using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.Buildings
{
    internal abstract class Building : NextMovable
    {
        protected string name;
        abstract public void NextMove();
    }
}
