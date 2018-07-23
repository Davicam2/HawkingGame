using System;
using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
    //translates user input into virtual feedback inGame.
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float cp_MaxSpeed = 10f;                    // Max Speed For player in the x axis.
        [SerializeField] private float cp_JumpForce = 400f;                  // Normal jump force
        
        [Range(0, 1)] [SerializeField] private float cp_CrouchSpeed = .36f;  // Will be implemented as a factor controlled by outside elements(i.e. poped tire)
        [SerializeField] private bool cp_AirControl = false;                 // implemented to allow for flying upgrade
        [SerializeField] private LayerMask cp_WhatIsGround;                  // Mask to dictate materials as ground to be interacted with
        
        

        private Transform cp_GroundCheck;    // A position marking where to check if the player is grounded.
        const float cp_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool cp_Grounded;            // Whether or not the player is grounded.
        private Transform cp_CeilingCheck;   // A position marking where to check for ceilings
        const float cp_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator cp_Anim;            // Reference to the player's animator component.
        private Rigidbody2D cp_Rigidbody2D;  // Attaches phisics interactions to the object.
        private bool cp_FacingRight = true;  // For determining which way the player is currently facing.str
        private ToolBelt cp_PhysicsTools;
        private string cp_Name = "Player Character";
        private CircleCollider2D cp_Feet;


        

        

        private bool cp_IsAlive;

        //=======================================================================================\\
        private void Awake()
        {
            //references on awake.
            cp_GroundCheck = transform.Find("GroundCheck");
            cp_CeilingCheck = transform.Find("CeilingCheck");
            cp_Anim = GetComponent<Animator>();
            cp_Rigidbody2D = GetComponent<Rigidbody2D>();
            cp_PhysicsTools = GetComponent<ToolBelt>();
            cp_Feet = GetComponent<CircleCollider2D>();
            name = cp_Name;
            cp_IsAlive = true;                        
        }
        //=======================================================================================//

        //=======================================================================================\\
        private void FixedUpdate()
        {
            cp_Grounded = false;                        
            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(cp_GroundCheck.position, cp_GroundedRadius, cp_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    cp_Grounded = true;
            }
            cp_Anim.SetBool("Ground", cp_Grounded);

            // Set the vertical animation
            cp_Anim.SetFloat("vSpeed", cp_Rigidbody2D.velocity.y);              
        }
        //=======================================================================================//


        //=======================================================================================\\
        /// <summary>
        /// made to accomidate look direction animations.
        /// passes the command to shoot due to knowledge of cursor position 
        /// is called by update
        /// </summary>
        /// <param name="m_shoot"></param>
        /// <param name="cursorPosition"></param>
        public void Look(bool m_shoot, bool m_2Shoot,string usedTool ,Vector2 cursorPosition)
        {                                                           
            if (m_shoot)
            {
                cp_PhysicsTools.ChangeCurrentTool(usedTool);
                //TODO: have general check to see what state is equipt to player.
                cp_PhysicsTools.Use( cursorPosition, cp_Rigidbody2D );                
            }
            if (m_2Shoot)
            {
                cp_PhysicsTools.ChangeCurrentTool(usedTool);
                cp_PhysicsTools.SecondaryUse();
            }
        }
        //=======================================================================================//

        //=======================================================================================\\
        private void Flip()
        {
            // Switch the way the player is labeled as facing.
            cp_FacingRight = !cp_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        //=======================================================================================//

        //=======================================================================================\\
        public void Move(float move, bool crouch, bool jump)
        {
            //-------------------------------------------------------------------------------------\\
            if (!crouch && cp_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(cp_CeilingCheck.position, cp_CeilingRadius, cp_WhatIsGround))
                {
                    crouch = true;
                }
            }
            //-------------------------------------------------------------------------------------//
            
            // Set whether or not the character is crouching in the animator
            cp_Anim.SetBool("Crouch", crouch);            

            //-------------------------------------------------------------------------------------\\
            //only control the player if grounded or airControl is turned on
            if (cp_Grounded || cp_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move * cp_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                cp_Anim.SetFloat("Speed", Mathf.Abs(move));


                if (cp_Rigidbody2D.velocity.x > 0)
                    cp_Feet.sharedMaterial.friction = .3f;
                else
                    cp_Feet.sharedMaterial.friction = 1;

                // Move the character
                cp_Rigidbody2D.velocity = new Vector2(move * cp_MaxSpeed, cp_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !cp_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && cp_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            //-------------------------------------------------------------------------------------//

            //-------------------------------------------------------------------------------------\\
            // If the player should jump...
            if (cp_Grounded && jump && cp_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                cp_Grounded = false;
                cp_Anim.SetBool("Ground", false);
                //acts as a normal smooth jump.
                cp_Rigidbody2D.AddForce(new Vector2(0f, cp_JumpForce));                

            }
            //-------------------------------------------------------------------------------------//        
        }
        //=======================================================================================//

        //=======================================================================================\\
        public void TakeDamage()
        {
            if (GetComponent<Rigidbody2D>())
            {
                if (/*check for protections here*/ true)
                {
                    cp_IsAlive = false;
                    Destroy(gameObject);
                }
            }            
        }
        //=======================================================================================//
    }
}
