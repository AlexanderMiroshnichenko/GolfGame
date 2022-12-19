using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class VFX : MonoBehaviour
    {
        [SerializeField]
        private Stick m_stick;
        [SerializeField]
        private ParticleSystem touchParticles;
        [SerializeField]
        private AudioSource stoneSound;
        [SerializeField]
        private AudioClip[] stoneSounds;

        void Update()
        {
            if (m_stick.hasTouched)
            {
                touchParticles.Play();
                stoneSound.clip = stoneSounds[Random.Range(0,stoneSounds.Length)];
                stoneSound.Play();
            }

        }
    }
}
