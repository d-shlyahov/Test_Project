using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Project
{

    public class Cloud : MonoBehaviour
    {
       [SerializeField] private ParticleSystem m_particleSystem;

        private void Start()
        {
            m_particleSystem.Stop();
        }

        public void PlayFX()
        { 
            m_particleSystem.Play();

        }

        public void StopFX()
        {
            m_particleSystem.Stop();
            
        }
    }
}