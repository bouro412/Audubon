using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Audubon
{
    class VariableMaker
    {
        private static int _nummberOfVariable = 0;

        public static string NewVariable()
        {
            return "v_" + _nummberOfVariable++;
        }
    }
}