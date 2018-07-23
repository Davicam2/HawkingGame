using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class SpatialModulator : MonoBehaviour
    {
        Calculations calculate = new Calculations();

        #region BlackHole Aspects             
        Queue<GameObject> sm_BlackHolesAlive = new Queue<GameObject>();
        Vector2 sm_Instantiate;
        [SerializeField] float sm_InstantiateRadius = 5; //distance from player blackholes can be placed
        [SerializeField] int sm_BlackHoleCapacity = 2; //amount of black holes that can be alive at once
        #endregion

        private void Awake()
        {
            //calculate = gameObject.AddComponent(typeof(Calculations)) as Calculations;
            
        }


        //=======================================================================================\\
        private void OnEnable()
        {
           // calculate = GetComponent<Calculations>();
            name = "SpatialModulator";
        }
        //=======================================================================================//

        //=======================================================================================\\
        public void Use(Vector2 direction, Vector2 myPos, Vector2 cursorPosition)
        {

            GameObject _projectile;
            Quaternion _rotation = calculate.ObjectRotation(direction.normalized.x, direction.normalized.y);

            ///limits the area a black hole can be instantiated.///
            //-----------------------------------------------------------------------------------------\\
            if (Mathf.Abs(direction.x) >= sm_InstantiateRadius ||
                       Mathf.Abs(direction.y) >= sm_InstantiateRadius)
            {
                sm_Instantiate = myPos + direction.normalized * 5;
            }
            else if (Mathf.Abs(direction.x) <= sm_InstantiateRadius - 4.5f &&
                     Mathf.Abs(direction.y) <= sm_InstantiateRadius - 4.5f)
            {
                sm_Instantiate = myPos + direction.normalized;
            }
            else
                sm_Instantiate = cursorPosition;
            //-----------------------------------------------------------------------------------------//

            CleanQueue(sm_BlackHolesAlive);//makes sure the first instantiated obj alive has focus.

            //-----------------------------------------------------------------------------------------\\
            if (sm_BlackHolesAlive.Count < sm_BlackHoleCapacity)
            {
                _projectile = (GameObject)Instantiate(Resources.Load("BlackHole"), sm_Instantiate, _rotation);
                sm_BlackHolesAlive.Enqueue(_projectile);
            }
            //-----------------------------------------------------------------------------------------//
        }
        //=======================================================================================//

        //=======================================================================================\\
        public void SecondaryUse()
        {
            //-----------------------------------------------------------------------------------------\\
            if (sm_BlackHolesAlive.Count > 0)
            {
                //-----------------------------------------------------------------------------------------\\
                if (sm_BlackHolesAlive.Peek() == null)
                {
                    CleanQueue(sm_BlackHolesAlive);
                    SecondaryUse();
                }
                else
                {
                    sm_BlackHolesAlive.Peek().gameObject.SendMessage("Explode");
                    CleanQueue(sm_BlackHolesAlive);
                }
                //-----------------------------------------------------------------------------------------//
            }
            //-----------------------------------------------------------------------------------------//
        }
        //=======================================================================================//

        //=======================================================================================\\
        /// <summary>
        /// deque's any null values stored in a queue and returns(GameObjects)
        /// </summary>
        /// <param name="objQueue"></param>
        private void CleanQueue(Queue<GameObject> objQueue)
        {
            //-----------------------------------------------------------------------------------------\\
            if (objQueue.Count > 0)
            {
                //-----------------------------------------------------------------------------------------\\
                if (objQueue.Peek() == null)
                {
                    objQueue.Dequeue();
                    CleanQueue(objQueue);
                }
                else
                    return;
                //-----------------------------------------------------------------------------------------//
            }
            //-----------------------------------------------------------------------------------------//
        }
        //=======================================================================================//

    }
}


