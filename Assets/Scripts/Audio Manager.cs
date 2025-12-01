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
    public AudioClip melee;
    public AudioClip laser;
    public AudioClip slash;
    public AudioClip death;
    public AudioClip damage;
    public AudioClip fightMusic;
    public AudioClip fightMusic2;
    //If needed  public AudioClip fightMusic3; 

    public enum soundEffects
    {
        background,
        melee,
        laser,
        slash,
        death,
        damage,
        fightMusic,
        fightMusic2,
    }




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

    public void PlaySFXReference(soundEffects se)
    {
        switch (se)
        {
            case soundEffects.background:
                PlaySFX(background);
                break;
            case soundEffects.melee:
                PlaySFX(melee);
                break;
            case soundEffects.laser:
                PlaySFX(laser);
                break;
            case soundEffects.damage:
                PlaySFX(damage);
                break;
            case soundEffects.fightMusic:
                PlaySFX(fightMusic);
                break;
        }
        
    }

}

