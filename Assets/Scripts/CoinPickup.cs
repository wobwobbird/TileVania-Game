using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] [Range(0f, 1f)] float coinPickupSFXVolume = 0.5f; // Optional: Control volume
    [SerializeField] AudioClip coinPickupSeriousSFX;
    [SerializeField] [Range(0f, 1f)] float coinPickupSeriousSFXVolume = 0.5f; // Optional: Control volume

    [SerializeField] int goldCoinValue = 100;

    bool wasCollected = false;

    private Sounds soundsScript;

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Player" && !wasCollected)
    //     {
    //         wasCollected = true;
    //         FindAnyObjectByType<GameSession>().AddToScore(goldCoinValue);
    //         AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
    //         Destroy(gameObject);
    //     }
    // }

    void Start()
    {
        soundsScript = FindAnyObjectByType<Sounds>();

        if (soundsScript == null)
        {
            Debug.LogWarning("Sounds script not found in the scene!");
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindAnyObjectByType<GameSession>().AddToScore(goldCoinValue);
            
            if (soundsScript != null && soundsScript.funnySounds)
            {
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, coinPickupSFXVolume);
            } else
            {
                AudioSource.PlayClipAtPoint(coinPickupSeriousSFX, Camera.main.transform.position, coinPickupSeriousSFXVolume);            
            }

            Destroy(gameObject);
        }
    }
}