using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// dw dw
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public AudioClip mazika;
    public AudioClip pickupSniwa;
    public AudioClip addIngredient;
    public AudioClip addSauce;
    public AudioClip ab3tytib;
    public AudioClip rawytib;
    public AudioClip timer;
    public AudioClip wjd;
    public AudioClip rfdTbsi;
    public AudioClip drahemAKAmoney;
    public AudioClip addedOrder;
    public AudioClip angryCustomer;
    public AudioClip angryCustomer1;
    public AudioClip angryCustomer2;
    public AudioClip angryCustomer3;
    public AudioClip angryCustomer4;
    public AudioClip khmsalef;
    public AudioClip lharaj;

    void Start()
    {
        if (musicSource != null && mazika != null)
        {
            musicSource.clip = mazika;
            musicSource.loop = true; // Ensure music continues playing
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("MusicSource or Mazika clip not assigned.");
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("SFXSource or AudioClip not assigned.");
        }
    }
}
