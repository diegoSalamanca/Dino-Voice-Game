//Developed By: Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. +57 3508232690
//Bogotá Colombia.

using UnityEngine;

public class SoundManager : MonoBehaviour
{
    

    public AudioClip[] audioClips;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void PlayShoot(int index)
    {        
        audioSource.PlayOneShot(audioClips[index]);
    }

    public void StopAllSound()
    {
        audioSource.Stop();
    }
}
