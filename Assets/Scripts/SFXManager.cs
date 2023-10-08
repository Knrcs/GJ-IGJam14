using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip wakeUpSFX, walkSFX, jumpSFX, damageSFX, pickUpSFX;
    // Start is called before the first frame update

    public void WakeUpSFX()
    {
        audioSource.clip = wakeUpSFX;
    }
    public void WalkSFX()
    {
        audioSource.clip = walkSFX;
        audioSource.Play();
        
    }

    public void JumpSFX()
    {
        audioSource.clip = jumpSFX;
        audioSource.Play();
    }

    public void DamageSFX()
    {
        audioSource.clip = damageSFX;
        audioSource.Play();
        
    }

    public void PickupSFX()
    {
        audioSource.clip = pickUpSFX;
        audioSource.Play();
        
    }
}
