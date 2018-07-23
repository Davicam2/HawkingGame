using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Calculations : MonoBehaviour
    {
        /// <summary>
        /// calculates the force applied based on gravitational accelleration of an object.
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
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

        /// <summary>
        /// returns the vector direction from a dectected object to this object.
        /// </summary>
        /// <param name="myRB"></param>
        /// <param name="collision"></param>
        /// <returns></returns>
        public Vector2 BackAzimuth(Rigidbody2D myRB,Collider2D collision)
        {            
            Vector2 objPos = collision.gameObject.transform.position;            
            Vector2 bh_DirectionToMe = myRB.position - objPos;
            return bh_DirectionToMe;
        }

        /// <summary>
        /// returns the vector direction from a dectected object to this object.
        /// </summary>
        /// <param name="myRB"></param>
        /// <param name="collision"></param>
        /// <returns></returns>
        public Vector2 BackAzimuth(Rigidbody2D myRB,  Collider collision)
        {
            Vector2 objPos = collision.gameObject.transform.position;             
            Vector2 bh_DirectionToMe = myRB.position - objPos;
            return bh_DirectionToMe;
        }

        /// <summary>
        /// rotation variable of an object about the player.
        /// </summary>
        /// <param name="dirXNorm"></param>
        /// <param name="dirYNorm"></param>
        /// <returns></returns>
        public Quaternion ObjectRotation(float dirXNorm, float dirYNorm )
        {
            Quaternion _rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dirYNorm, dirXNorm) * Mathf.Rad2Deg);
            return _rotation;
        }

        /// <summary>
        /// Acts as the base wave velocity attitude, takes mass into account.
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public float WaveVelocity(float mass)
        {
            mass = mass * 50;
            return mass;
        }
        
    }
}

