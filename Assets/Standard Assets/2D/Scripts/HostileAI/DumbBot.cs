using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class DumbBot : MonoBehaviour
    {

        private Rigidbody2D db_BotBody;
        Vector2 db_Direction;
        Transform db_GroundCheck;
        bool db_Grounded;
        const float db_GroundedRadius = .6f;
        

        float db_BotX, db_BotY, db_ForiegnBodyX, db_ForiegnBodyY;
        [SerializeField] float db_BotSpeed;
        [SerializeField] private LayerMask db_WhatIsGround;


        //========================================================================================\\
        private void OnEnable()
        {
            db_BotBody = GetComponent<Rigidbody2D>();
            db_GroundCheck = transform.Find("GroundCheck");
            db_WhatIsGround = -1;
            db_BotSpeed = 500 * db_BotBody.mass;
        }
        //========================================================================================//

        //========================================================================================\\
        private void OnTriggerStay2D(Collider2D collision)
        {
            //if (Physics2D.CircleCast(db_BotBody.position, db_GroundedRadius, db_BotBody.position - new Vector2(5, -1)))
               
                    if (collision.gameObject.tag == "Player")
                    {
                        
                    follow(collision);
                    }                  
        }
        //========================================================================================//

        //========================================================================================\\
        void follow(Collider2D collision)
        {
            if (db_Grounded)
            {
                db_BotX = transform.position.x;
                db_BotY = transform.position.y;
                db_ForiegnBodyX = collision.transform.position.x;
                db_ForiegnBodyY = collision.transform.position.y;
                db_Direction = collision.transform.position - transform.position;
                db_BotBody.AddForce(db_Direction.normalized * db_BotSpeed * Time.deltaTime);
            }            
        }
        //========================================================================================//

        public void TakeDamage()
        {
            Destroy(gameObject);
        }

        //========================================================================================\\
        private void FixedUpdate()
        {
            db_Grounded = false;


            db_GroundCheck.position = new Vector3(db_BotBody.position.x + db_BotBody.velocity.x, db_BotBody.position.y);


            Collider2D[] colliders = Physics2D.OverlapCircleAll(db_GroundCheck.position, db_GroundedRadius, db_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    db_Grounded = true;
            }                       
        }
        //========================================================================================//



    }
}

