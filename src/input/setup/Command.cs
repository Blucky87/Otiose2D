using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otiose2D.Input.Setup
{
    public abstract class Command
    {

        protected ControllerProfile controllerProfile;


        public abstract void Execute();
    }



}
