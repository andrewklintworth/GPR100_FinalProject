using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("- - - - Audio Source - - - - ")] [SerializeField]
    AudioSource musicSource;

    [SerializeField] AudioSource SFXSource;

    [Header("- - - - Audio Clip - - - - ")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip shoot;
    public AudioClip damageTaken;
    public AudioClip fightMusic;
    public AudioClip attack;



    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            musicSource.clip = background;
        }
        else if (SceneManager.GetActiveScene().name == "Level-1")
        {
            musicSource.clip = fightMusic;

        }

        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySFXReference(int list)
    {
        if (list == 1) { PlaySFX(background);}
    }

}

