using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Animator m_animator;
        [SerializeField]
        private GameController m_gameController;
        [SerializeField]
        private GameSettings m_settings;
        [SerializeField]
        private int m_speed = 2;

        public bool m_isDown;
        private void Start()
        {
            m_animator.SetFloat("MoveSpeed", 0);
        }
        void FixedUpdate()
        {
            if (m_isDown)
            {
                MoveToolForward();
            }
            else MoveToolBackward();

            CheckForGameOver();
        }

        private void MoveToolForward()
        {
            m_animator.SetFloat("MoveSpeed", Mathf.Lerp(m_animator.GetFloat("MoveSpeed"), 1, m_settings.speed * Time.deltaTime));
        }
        private void MoveToolBackward()
        {
            if (!m_gameController.isLosed) 
                m_animator.SetFloat("MoveSpeed", Mathf.Lerp(m_animator.GetFloat("MoveSpeed"), 0, m_settings.speed * Time.deltaTime));
        }
        private void CheckForGameOver()
        {
            m_animator.SetBool("isLosed", m_gameController.isLosed);
        }
        public void OnDown()
        {
            m_isDown = true;
        }

        public void OnUp()
        {
            m_isDown = false;
        }
    }
}
