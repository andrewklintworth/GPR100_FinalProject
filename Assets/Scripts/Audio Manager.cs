using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("- - - - Audio Source - - - - ")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("- - - - Audio Clip - - - - ")]
    public AudioClip backround;
    public AudioClip death;
    public AudioClip shoot;
    public AudioClip damageTaken;
    public AudioClip fightMusic;
    public AudioClip attack;



    private void Start()
    {
        musicSource.clip = backround;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}