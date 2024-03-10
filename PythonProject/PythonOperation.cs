using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;

namespace PythonProject
{
    public class PythonOperation
    {
        public PythonOperation() { }

        public void Initialize()
        {
            PythonEngine.Initialize();

        }
    }


}
