using UnityEngine;

public class SoundManagerPlayer : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] public AudioClip hitAudioClip;
    [SerializeField] public AudioClip runAudioClip;
    [SerializeField] public AudioClip jumpAudioClip;


    public void RunSound()
    {
        audioSource.PlayOneShot(runAudioClip);
      
    }


    public void HitSound()
    {
        audioSource.PlayOneShot(hitAudioClip);
    }

    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClip);
    }

}