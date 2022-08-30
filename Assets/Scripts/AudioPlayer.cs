using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 100f)] float damageVolume;

    static AudioPlayer instance;

  

    private void Awake()
    {
        ManageSingleton();
    }


    void ManageSingleton()
    {
       // int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingClip()
    {
        if (shootingClip  != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }


    public void PlayDamageClip()
    {
        if (damageClip != null)
        {
            AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, damageVolume);
        }
    }
}