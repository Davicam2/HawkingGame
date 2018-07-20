using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class HiggsBosonEmitter : MonoBehaviour
    {
        
        Vector2 hbe_Instatiate;
        Calculations calculate = new Calculations();

       

        
        //=======================================================================================\\
        private void Awake()
        {
            //calculate = gameObject.AddComponent(typeof(Calculations)) as Calculations;
            calculate = GetComponent<Calculations>();
            name = "ElectroWeakSymmetryBreak";
            
        }
        //=======================================================================================//

        //=======================================================================================\\
        public void Use(Vector2 direction, Vector2 myPos, Vector2 cursorPosition)
        {
            GameObject _Projectile;
            Quaternion _rotation = calculate.Rotation(direction.normalized.x, direction.normalized.y);

            hbe_Instatiate = myPos + direction.normalized;
            _Projectile = (GameObject)Instantiate(Resources.Load("HiggsBoson"), hbe_Instatiate, _rotation);
            _Projectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized);
        }
        //=======================================================================================//
    }
}

