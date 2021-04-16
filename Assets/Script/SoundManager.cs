//Codigo Desarrollado por Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. 301 733 7051
//Bogotá Colombia.

/*  Funcionamiento
Administra la reproducción de sonido
 */

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
