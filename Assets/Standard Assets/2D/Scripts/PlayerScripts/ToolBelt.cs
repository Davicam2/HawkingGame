﻿using System.Collections;
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
        string pt_ToolEquiped;

        SpatialModulator pt_SpatialModulator;
        HiggsBosonEmitter pt_HiggsBosonEmitter;
        public Calculations pt_Calculations;
        public PlayerStates pt_PlayerActivity;

        #endregion

        private void OnEnable()
        {
            pt_Calculations = GetComponent<Calculations>();
            pt_PlayerActivity = GetComponent<PlayerStates>();
            names = GetComponent<Strings>();
        }

        //=======================================================================================\\
        private void Awake()
        {
            pt_SpatialModulator = new SpatialModulator();//will have to change this if we want permanant changes possible.
            pt_HiggsBosonEmitter = new HiggsBosonEmitter();
            
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
                    pt_ToolEquiped = tool;
                    break;
                case "HiggsBosonEmitter":
                    pt_ToolEquiped = tool;
                    break;
                default:
                    pt_ToolEquiped = "";
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
                switch (pt_ToolEquiped)
                {
                    //-----------------------------------------------------------------------------------------\\
                    case "SpatialModulator": //black hole object, will be checking for tool equipt in future rather than object 
                        pt_SpatialModulator.Use(_direction, _myPos, cursorPosition);
                        
                        break;
                    //-----------------------------------------------------------------------------------------//

                    //-----------------------------------------------------------------------------------------\\
                    case "HiggsBosonEmitter": //solid projectile fire
                        pt_HiggsBosonEmitter.Use(_direction, _myPos, cursorPosition);//creates the projectile        
                        
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
                switch (pt_ToolEquiped)
                {
                    case "SpatialModulator":
                    pt_SpatialModulator.SecondaryUse();                       
                        break;
                }
                //-----------------------------------------------------------------------------------------//                        
        }
        //=======================================================================================//
        

        //=======================================================================================\\
        public class GenericQueue<T>
        {
            void Enqueue(T input) { }
        }
        //=======================================================================================//

       

    }
}