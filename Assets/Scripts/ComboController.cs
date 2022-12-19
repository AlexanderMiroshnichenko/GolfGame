using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class ComboController : MonoBehaviour
    {
        public bool isPerfect;
        [SerializeField]
        private PlayerController m_player;
        [SerializeField]
        private Stick m_stick;
        void Start()
        {
            isPerfect = false;
        }

       private void IsPerfectCount()
        {
            if (m_player.m_isDown && m_stick.hasTouched)
            {
                isPerfect = true;
            }
            
        }

        private void Update()
        {
            IsPerfectCount();
            Debug.Log(isPerfect);
        }

    }
}
