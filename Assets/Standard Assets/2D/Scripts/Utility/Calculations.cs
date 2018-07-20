using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Calculations : MonoBehaviour
    {
        
        public float MassBasedPull(float mass)
        {
            float pullForce = 50;
            pullForce *= mass;
            return pullForce;
        }

        //TODO: calculate the dynamic radius of the black hole.
        public float BlackHoleInfluence(float mass)
        {

            return 1;
        }

        public Vector2 DirectionToMe(Rigidbody2D myRB,Collider2D collision)
        {            
            Vector2 objPos = collision.gameObject.transform.position;            
            Vector2 bh_DirectionToMe = myRB.position - objPos;
            return bh_DirectionToMe;
        }

        public Vector2 DirectionToMe(Rigidbody2D myRB,  Collider collision)
        {
            Vector2 objPos = collision.gameObject.transform.position;             
            Vector2 bh_DirectionToMe = myRB.position - objPos;
            return bh_DirectionToMe;
        }

        public Quaternion Rotation(float dirXNorm, float dirYNorm )
        {
            Quaternion _rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dirYNorm, dirXNorm) * Mathf.Rad2Deg);
            return _rotation;
        }

        public float WaveVelocity(float mass)
        {
            mass = mass * 50;
            return mass;
        }
        
    }
}

