using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    interface IProblem
    {
        string GetMenuEntry();
        bool Introduction();
        bool Run();
        void ShowError();
    }
}
