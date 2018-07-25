using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class HiggsBosonEmitter : ToolBelt
    {
        
        Vector2 hbe_Instatiate;
        Calculations calculate = new Calculations();
        
        
              
        //=======================================================================================\\
        private void Awake()
        {
            //calculate = gameObject.AddComponent<Calculations>();
            
            
            
        }
        //=======================================================================================//
        private void OnEnable()
        {
            calculate = GetComponent<Calculations>();
            name = "ElectroWeakSymmetryBreak";
            
        }


        //=======================================================================================\\
        public void Use(Vector2 direction, Vector2 myPos, Vector2 cursorPosition)
        {
            
            GameObject _Projectile;
            Quaternion _rotation = calculate.ObjectRotation(direction.normalized.x, direction.normalized.y);
            hbe_Instatiate = myPos + direction.normalized;
            _Projectile = (GameObject)Instantiate(Resources.Load("HiggsBoson"), hbe_Instatiate, _rotation);

            if (PlayerStates.Mouse1)
                Debug.Log("mouse button 1 is depressed");

           
                if (PlayerStates.Mouse1)
                {

                }
                else
                {
                    _Projectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized);
                }
                                         
        }
        //=======================================================================================//
    }
}

