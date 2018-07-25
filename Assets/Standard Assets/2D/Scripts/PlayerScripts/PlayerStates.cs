using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public static class PlayerStates 
    {
        static bool Mouse1Down;
        static bool Mouse2Down;

        

        public static bool Mouse1
        {
            set { Mouse1Down = value; }
            get { return Mouse1Down; }
        }

        public static bool Mouse2
        {
            set { Mouse2Down = value; }
            get { return Mouse2Down; }
        }


    }
}
