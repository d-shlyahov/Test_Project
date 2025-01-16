using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Project
{
    public class Player_Controller : MonoBehaviour
    {
        public Spawner spawner;
        public Moving_Controller moving_controller;

        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("X key down");
                spawner.Spawn();
            }
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Z key down");
                moving_controller.Action();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key down");
            }
        }
    }
}