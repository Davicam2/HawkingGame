using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(SpatialModulator))]
    [RequireComponent(typeof(HiggsBosonEmitter))]
    [RequireComponent(typeof(PlayerStates))]
    ///Class acts as the access point for all player Tools. Accessors for all tools live here.
    public class ToolBelt : MonoBehaviour {


         
        Strings names;
        #region Tool Instantiation
        string tb_ToolEquiped;

        SpatialModulator tb_SpatialModulator;
        HiggsBosonEmitter tb_HiggsBosonEmitter;
        public Calculations tb_Calculations;
        
        bool tb_LClick, tb_RClick;

        #endregion

        private void OnEnable()
        {
            tb_Calculations = GetComponent<Calculations>();
            
            names = GetComponent<Strings>();
        }

        //=======================================================================================\\
        private void Awake()
        {
            tb_SpatialModulator = new SpatialModulator();//will have to change this if we want permanant changes possible.
            tb_HiggsBosonEmitter = new HiggsBosonEmitter();
            
        }
        //=======================================================================================//

        //=======================================================================================\\
        /// <summary>
        /// TODO: add graphics to be equiped here.
        /// </summary>
        /// <param name="tool"></param>
        public void ChangeCurrentTool(string tool)
        {
            switch (tool)
            {
                case "SpatialModulator":
                    tb_ToolEquiped = tool;
                    break;
                case "HiggsBosonEmitter":
                    tb_ToolEquiped = tool;
                    break;
                default:
                    tb_ToolEquiped = "";
                    break;

            }
        }
        //=======================================================================================//

        //=======================================================================================\\   
        /// <summary>
        /// TODO: add animation for firing here.
        /// </summary>
        /// <param name="cursorPosition"></param>
        /// <param name="playerBody"></param>
        public void Use( Vector2 cursorPosition, Rigidbody2D playerBody)
        {
            //-----------------------------------------------------------------------------------------\\
            Vector2 _myPos = playerBody.position;
            Vector2 _direction = cursorPosition - _myPos;
            //-----------------------------------------------------------------------------------------//
            
                //-----------------------------------------------------------------------------------------\\
                switch (tb_ToolEquiped)
                {
                    //-----------------------------------------------------------------------------------------\\
                    case "SpatialModulator": //black hole object, will be checking for tool equipt in future rather than object 
                        tb_SpatialModulator.Use(_direction, _myPos, cursorPosition);
                        
                        break;
                    //-----------------------------------------------------------------------------------------//

                    //-----------------------------------------------------------------------------------------\\
                    case "HiggsBosonEmitter": //solid projectile fire
                        tb_HiggsBosonEmitter.Use(_direction, _myPos, cursorPosition);//creates the projectile        
                        
                        break;
                    //-----------------------------------------------------------------------------------------//
                }
                //-----------------------------------------------------------------------------------------//
            

        }
        //=======================================================================================//


      
        //=======================================================================================\\
        public void SecondaryUse()
        {                                   
                //-----------------------------------------------------------------------------------------\\
                switch (tb_ToolEquiped)
                {
                    case "SpatialModulator":
                    tb_SpatialModulator.SecondaryUse();                       
                        break;
                }
                //-----------------------------------------------------------------------------------------//                        
        }
        //=======================================================================================//

        private void Update()
        {
            if (PlayerStates.Mouse1)//if left click is depressed, state is set in Platformer2DUserControl
            {

            }            
            else if (PlayerStates.Mouse2)//if right click is depressed, state is set in Platformer2DUserControl
            {

            }
        }



        //=======================================================================================\\
        public class GenericQueue<T>
        {
            void Enqueue(T input) { }
        }
        //=======================================================================================//

       

    }
}