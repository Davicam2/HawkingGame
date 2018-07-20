using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(EventHorizon))]
    public class BlackHole : MonoBehaviour 
    {

        Calculations calculate;
        public CircleCollider2D bh_InfluenceCircle;        
        private Rigidbody2D bh_ForeignBody;
        private Rigidbody2D bh_BlackHoleBody;     
        private bool bh_Explode;
        private float bh_ExplodeTimer;

        string bh_Name = "black hole";        

        [SerializeField] float bh_PullForce;
        [SerializeField] float bh_PushForce;
        [SerializeField] public float bh_Mass;
       

        //========================================================================================\\
        /// <summary>
        /// sets default values for the black hole Physics tool
        /// some of these will be dynamically mutated based on ingame situations.
        /// </summary>
        private void OnEnable()
        {           
            bh_BlackHoleBody = GetComponent<Rigidbody2D>();
            bh_InfluenceCircle = GetComponent<CircleCollider2D>();
            calculate = gameObject.AddComponent(typeof(Calculations)) as Calculations; //new Calculations();
            name = bh_Name;
            bh_Explode = false;

            bh_Mass = 3;
            bh_InfluenceCircle.radius = 5;
            bh_PullForce = 50;
            bh_PushForce = 1250;
            bh_ExplodeTimer = .1f;            
        }
        //========================================================================================//

        //========================================================================================\\
        /// <summary>
        /// this will act as a count down for the dissipation of the black holes.
        /// *add values to HoleMaterial, increase HoleCollider.radius
        /// </summary>
        private void FixedUpdate()
        {
            bh_Mass -= Time.deltaTime * .2f;
            if (bh_Mass > 1)
                bh_InfluenceCircle.radius = (2 * bh_Mass);

            if (bh_Mass <= 0)
                Destroy(gameObject);

            if (bh_Explode)
            {
                bh_ExplodeTimer -= Time.deltaTime;
                if(bh_ExplodeTimer <= 0)
                {
                    Destroy(gameObject);
                }
            }               
        }
        //========================================================================================//

        //========================================================================================\\
        /// <summary>
        /// this function fires when an object with a collider and rigidbody enters the region indicated by HoleCollider.radius
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.isTrigger && collision.gameObject.GetComponent<Rigidbody2D>())
            {
                Debug.Log("colliding with = " + collision.gameObject.name);
                //-----------------------------------------------------------------------------------------\\
                if (collision.gameObject.GetComponent<Rigidbody2D>() && !bh_Explode)
                {
                    switch (collision.gameObject.layer)
                    {
                        case 8://Player
                            PullIn(collision);
                            break;
                        case 9://Enemy                           
                            PullIn(collision);
                            break;
                        case 11://Waves                            
                            PullIn(collision);
                            break;
                    }
                }
                else if (bh_Explode && collision.tag == "Player" || collision.tag == "Enemy")
                {
                    Debug.Log("Blowing Up = " + collision.gameObject.name);
                    bh_ForeignBody = collision.GetComponent<Rigidbody2D>();
                    bh_ForeignBody.AddForce(-calculate.DirectionToMe(bh_BlackHoleBody, collision).normalized * bh_PushForce * bh_ForeignBody.mass);

                    Destroy(gameObject);                    
                }
                else if (bh_Explode )
                {
                    Destroy(gameObject);
                }
                //-----------------------------------------------------------------------------------------//
            }
        }
        //========================================================================================//


        //========================================================================================\\
        /// <summary>
        /// pulls select objects toward the center of the black hole.
        /// </summary>
        /// <param name="collision"></param>
        void PullIn(Collider2D collision)
        {                        
            bh_ForeignBody = collision.GetComponent<Rigidbody2D>();            
            bh_ForeignBody.AddForce(calculate.DirectionToMe(bh_BlackHoleBody, collision).normalized * 
                                                            calculate.MassBasedPull(bh_ForeignBody.mass) );            
        }
        //========================================================================================//

        //========================================================================================\\
        /// <summary>
        /// detonates the black hole, explosive power will be scaled based on black hole mass
        /// </summary>
        public void Explode()
        {            
            bh_Explode = true;
        }
        //========================================================================================//

        //========================================================================================\\
        /// <summary>
        /// adds mass to the black hole, elongating life and strengthening pull.
        /// </summary>
        /// <param name="matter"></param>
        public void Consume(float matter)
        {
            bh_Mass += 1;
        }
        //========================================================================================//


       

    }
}