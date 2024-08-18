using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip mazika;
    public AudioClip pickupsniwa;
    public AudioClip addIncredient;
    public AudioClip ab3tytib;
    public AudioClip rawytib;
    public AudioClip timer;
    public AudioClip wjd;
    public AudioClip rfdTbsi;
    public AudioClip drahemAKAmoney;
    public AudioClip addedorder;
    public AudioClip angryCostumer;
    public AudioClip lharaj;



    void Start()
    {
        musicSource.clip = mazika;
        musicSource.Play();
    }

    public void pLAYsfx (AudioClip clip)
    {
        SFXSource.PlayOneShot (clip);
    }

}