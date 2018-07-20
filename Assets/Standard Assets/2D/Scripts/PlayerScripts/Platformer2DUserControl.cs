using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    //Validates, Mutates and directs all human control inputs.
    public class Platformer2DUserControl : MonoBehaviour
    { 
        private PlatformerCharacter2D hu_Character;
        private bool hu_Jump, hu_Shoot, hu_2Shoot;
        Vector2 hu_CursorPosition;

        private string hu_EquipTool;

        //========================================================================================//
        private void Awake()
        {
            hu_Character = GetComponent<PlatformerCharacter2D>();
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
            hu_Shoot = Input.GetMouseButtonDown(0);
            hu_2Shoot = Input.GetMouseButtonDown(1);                   

            if (Input.GetKeyDown(KeyCode.Alpha1)) { hu_EquipTool = "SpatialModulator"; Debug.Log("Spatial Modulator"); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { hu_EquipTool = "HiggsBosonEmitter"; Debug.Log("Higgs Boson Emitter"); }

            hu_Character.Look(hu_Shoot, hu_2Shoot, hu_EquipTool, hu_CursorPosition);

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
