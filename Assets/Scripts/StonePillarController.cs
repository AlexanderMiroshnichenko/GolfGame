using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game {
    public class StonePillarController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody[] pillarRB;
        [SerializeField]
        private AudioSource sound;
        private bool isDestroyed;
        [SerializeField]
        private GameController gameController;
        [SerializeField]
        private int bonusPoints;
        [SerializeField]
        private ParticleSystem touchEffect;

        private void Start()
        {
            isDestroyed = false;
        }
        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Stone>(out var stone)&&!isDestroyed)
            {
                sound.Play();
                touchEffect.Play();
               foreach(Rigidbody rb in pillarRB)
                {
                    rb.isKinematic = false;
                }
                gameController.m_score += bonusPoints;
                gameController.m_maxScore = Mathf.Max(gameController.m_score, gameController.m_maxScore);
                gameController.RefreshScore(gameController.m_score);
                isDestroyed = true;
            }
        }
    }
}
