using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip PickupCrystal;
    public AudioClip playerLand;
    public AudioClip playerFall;
    public AudioClip blueCrystal;
    public AudioClip blueCrystalLoop;
    public AudioClip death;


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
