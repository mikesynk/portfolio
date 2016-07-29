using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.UI.Interfaces;

namespace SGFlooring.UI.Workflows
{
    public class ExitApplicationWorkflow : IWorkflow
    {
        public void Execute()
        {
            Environment.Exit(5);
        }
    }
}
