using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class HiggsBosonEmitter : ToolBelt
    {
        
        Vector2 hbe_Instatiate;
        Calculations calculate = new Calculations();
        PlayerStates PlayerActivity = new PlayerStates();
        
              
        //=======================================================================================\\
        private void Awake()
        {
            //calculate = gameObject.AddComponent<Calculations>();
            calculate = GetComponent<Calculations>();
            name = "ElectroWeakSymmetryBreak";
            PlayerActivity = GetComponent<PlayerStates>();
            
            
        }
        //=======================================================================================//

      

        //=======================================================================================\\
        public void Use(Vector2 direction, Vector2 myPos, Vector2 cursorPosition)
        {
            
            GameObject _Projectile;
            Quaternion _rotation = calculate.ObjectRotation(direction.normalized.x, direction.normalized.y);
            hbe_Instatiate = myPos + direction.normalized;
            _Projectile = (GameObject)Instantiate(Resources.Load("HiggsBoson"), hbe_Instatiate, _rotation);

            if (pt_PlayerActivity.Mouse1)
                Debug.Log("mouse button 1 is depressed");

            while (pt_PlayerActivity.Mouse1)
            {
                if (pt_PlayerActivity.Mouse1)
                {

                }
                else
                {
                    _Projectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized);
                }
            }                                
        }
        //=======================================================================================//
    }
}

