using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    
    [RequireComponent(typeof(BlackHole))]
    public class EventHorizon : MonoBehaviour
    {
        CircleCollider2D eh_Horizon;
        BlackHole eh_BlackHole;

        //========================================================================================\\
        private void OnEnable()
        {
            eh_Horizon = GetComponent<CircleCollider2D>();
            eh_BlackHole = GetComponentInParent<BlackHole>();
            
            eh_Horizon.radius = .2f;
        }
        //========================================================================================//

        //========================================================================================\\
        private void OnCollisionEnter2D(Collision2D collision)
        {            
            switch (collision.gameObject.layer)
            {
                case 9://Enemy
                    Destroy(collision.gameObject);
                    UpdateBlackHole(collision.gameObject.GetComponent<Rigidbody2D>().mass);
                    break;
            }
        }
        //========================================================================================//


        //========================================================================================\\
        private void UpdateBlackHole(float matter)
        {
            eh_BlackHole.Consume(matter);        
        }
        //========================================================================================//

        //========================================================================================\\
        private void FixedUpdate()
        {
            eh_Horizon.radius = eh_BlackHole.bh_InfluenceCircle.radius * .04f;
        }
        //========================================================================================//

    }
}


