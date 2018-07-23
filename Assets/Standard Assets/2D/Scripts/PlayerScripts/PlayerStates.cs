using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlayerStates : MonoBehaviour
    {
        bool Mouse1Down;
        bool Mouse2Down;

        public bool Mouse1
        {
            set { Mouse1Down = value; }
            get { return Mouse1Down; }
        }

        public bool Mouse2
        {
            set { Mouse2Down = value; }
            get { return Mouse2Down; }
        }


    }
}
