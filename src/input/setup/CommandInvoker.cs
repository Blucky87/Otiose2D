using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otiose2D.Input.Setup
{
    public class CommandInvoker
    {

        public readonly Command _command;

        public CommandInvoker(Command Command)
        {
            _command = Command;
        }

        public void Init()
        {
            _command.Execute();
        }
    }

}
