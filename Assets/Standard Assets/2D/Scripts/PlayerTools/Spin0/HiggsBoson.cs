using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class HiggsBoson : MonoBehaviour
    {

        [SerializeField] float s0_PullForce;
        [SerializeField] float s0_PushForce;
        [SerializeField] float s0_Distance;
        float s0_velocity;
        Calculations calculate;
        
        Rigidbody2D s0_Body;

        private void Awake()
        {
            calculate = gameObject.AddComponent(typeof(Calculations)) as Calculations; 
        }
        //=======================================================================================\\
        private void OnEnable()
        {                        
            //-------------------------------------------------------------------------------------\\
            
            s0_PullForce = 500;
            s0_PushForce = 500;
            s0_Distance = .5f;

            s0_Body = GetComponent<Rigidbody2D>();
            name = "HiggsBoson";
            s0_Body.mass = 40;
            
            s0_velocity = calculate.WaveVelocity(s0_Body.mass);

            //-------------------------------------------------------------------------------------//
        }
        //=======================================================================================//

        //=======================================================================================\\
        private void FixedUpdate()
        {
            s0_Body.velocity = new Vector2(s0_Body.velocity.normalized.x * 25 , s0_Body.velocity.normalized.y * 25);
            //-------------------------------------------------------------------------------------\\
            s0_Distance -= Time.deltaTime;
            if (s0_Distance <= 0)
            {
                Destroy(gameObject);
            }
            //-------------------------------------------------------------------------------------//
        }
        //=======================================================================================//

        //=======================================================================================\\
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.collider.isTrigger)
            {
                //-------------------------------------------------------------------------------------\\
                switch (collision.gameObject.layer)
                {
                    //-------------------------------------------------------------------------------------\\
                    case 9://Enemy                        
                           //collision.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(s0_Body.velocity.normalized * s0_PushForce, ForceMode2D.Impulse);
                        collision.gameObject.GetComponentInParent<Rigidbody2D>().mass += s0_Body.mass;
                        Destroy(gameObject);
                        break;
                    default:
                        Destroy(gameObject);
                        break;
                        //-------------------------------------------------------------------------------------//
                }
                //-------------------------------------------------------------------------------------//
            }

        }
        //=======================================================================================//

        private void OnTriggerEnter2D(Collider2D collision)
        {

           
        }

    }


}


