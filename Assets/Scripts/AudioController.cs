using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] m_sprites;
    [SerializeField]
    private Image image;
    [SerializeField]
    private AudioSource[] m_audioSources;
    private bool isTurnedOff;


    private void TurnSoundOff()
    {
        foreach(AudioSource a in m_audioSources)
        {
            a.enabled = false;
        }
        image.sprite = m_sprites[1];
        isTurnedOff = true;
    }
    private void TurnSoundOn()
    {
        foreach (AudioSource a in m_audioSources)
        {
            a.enabled = true;
        }
        image.sprite = m_sprites[0];
        isTurnedOff = false;
    }
    public void SoundSwitch()
    {
        if (isTurnedOff) TurnSoundOn();
        else TurnSoundOff();
    }



}
