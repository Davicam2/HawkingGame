using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    [RequireComponent(typeof(PlayerStates))]
    //Validates, Mutates and directs all human control inputs.
    public class Platformer2DUserControl : MonoBehaviour
    { 
        private PlatformerCharacter2D hu_Character;
        private PlayerStates hu_States;
        private bool hu_Jump, hu_LClick, hu_RClick;
        Vector2 hu_CursorPosition;

        private string hu_EquipTool;

        //========================================================================================//
        private void Awake()
        {
            hu_Character = GetComponent<PlatformerCharacter2D>();
            hu_States = GetComponent<PlayerStates>();
            hu_EquipTool = "SpatialModulator";                        
        }
        //========================================================================================//

        //========================================================================================//
        private void Update()
        {
            if (!hu_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                hu_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            hu_CursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hu_LClick = Input.GetMouseButtonDown(0);            
            hu_RClick = Input.GetMouseButtonDown(1);

            //this is the new implementation, must switch all listeners to PlayerState bools, will do with julie.
            hu_States.Mouse1 = Input.GetMouseButtonDown(0);
            hu_States.Mouse2 = Input.GetMouseButtonDown(1);

            if (Input.GetKeyDown(KeyCode.Alpha1)) { hu_EquipTool = "SpatialModulator"; Debug.Log("Spatial Modulator"); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { hu_EquipTool = "HiggsBosonEmitter"; Debug.Log("Higgs Boson Emitter"); }

            hu_Character.Look(hu_LClick, hu_RClick, hu_EquipTool, hu_CursorPosition);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        //========================================================================================//

        //========================================================================================//
        private void FixedUpdate()
        {
            // Read the inputs
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            
            float move = CrossPlatformInputManager.GetAxis("Horizontal");
            
            // Character horiz, movement, and crouch.
            hu_Character.Move(move , crouch, hu_Jump);            
            
            hu_Jump = false;         
        }
        //========================================================================================//
    }
}
