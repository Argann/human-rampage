using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
    
    [SerializeField]
    private AudioClip shoot;
    [SerializeField]
    private AudioClip hit;
    [SerializeField]
    private AudioClip die;

    public void PlayShoot() {
        GetComponent<AudioSource>().PlayOneShot(shoot);
    }
    
    public void PlayHit() {
        GetComponent<AudioSource>().PlayOneShot(hit);
    }

    public void PlayDie() {
        GetComponent<AudioSource>().PlayOneShot(die);
    }

    public static AudioManager GetManager() {
        return GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }


}
