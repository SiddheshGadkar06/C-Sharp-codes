using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public interface IOpenable
    {
        string OpenSesame();
    }
    public class TreasureBox : IOpenable
    {
        public string OpenSesame()
        {
            throw new NotImplementedException();
        }
    }
}
