using UnityEngine;

public class Sounds : MonoBehaviour
{
    public bool funnySounds = true;

    [Header("Death")]
    [SerializeField] AudioClip deathSound; // Add this
    [SerializeField] [Range(0f, 1f)] float deathSoundVolume = 0.5f; // Optional: Control volume
    [SerializeField] AudioClip deathSoundSerious; // Add this
    [SerializeField] [Range(0f, 1f)] float deathSoundVolumeSerious = 0.5f; // Optional: Control volume

    [Header("Level Complete")]
    [SerializeField] AudioClip levelCompleteSound; // Add this
    [SerializeField] [Range(0f, 1f)] float levelCompleteSoundVolume = 0.5f; // Optional: Control volume
    [SerializeField] AudioClip levelCompleteSoundSerious; // Add this
    [SerializeField] [Range(0f, 1f)] float levelCompleteSoundVolumeSerious = 0.5f; // Optional: Control volume

    [Header("Kill Enemy")]
    [SerializeField] AudioClip killEnemySound; // Add this
    [SerializeField] [Range(0f, 1f)] float killEnemySoundVolume = 0.5f; // Optional: Control volume
    [SerializeField] AudioClip killEnemySoundSerious; // Add this
    [SerializeField] [Range(0f, 1f)] float killEnemySoundVolumeSerious = 0.5f; // Optional: Control volume

    [Header("MushroomBounce")]
    [SerializeField] AudioClip mushroomBounceSound; // Add this
    [SerializeField] [Range(0f, 1f)] float mushroomBounceSoundVolume = 0.5f; // Optional: Control volume
    [SerializeField] AudioClip mushroomBounceSoundSerious; // Add this
    [SerializeField] [Range(0f, 1f)] float mushroomBounceSoundVolumeSerious = 0.5f; // Optional: Control volume

    [Header("Gun Fire")]
    [SerializeField] AudioClip gunFireSound; // Add this
    [SerializeField] [Range(0f, 1f)] float gunFireSoundVolume = 0.5f; // Optional: Control volume
    [SerializeField] AudioClip gunFireSoundSerious; // Add this
    [SerializeField] [Range(0f, 1f)] float gunFireSoundVolumeSerious = 0.5f; // Optional: Control volume

    // Play the dying sound
    public void DeathSoundMethod()
    {
        if (funnySounds == true)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        } else
        {
            AudioSource.PlayClipAtPoint(deathSoundSerious, Camera.main.transform.position, deathSoundVolumeSerious);
        }
    }

    public void LevelCompleteMethod()
    {
        if (funnySounds == true)
        {
            AudioSource.PlayClipAtPoint(levelCompleteSound, Camera.main.transform.position, levelCompleteSoundVolume);
        } else
        {
            AudioSource.PlayClipAtPoint(levelCompleteSoundSerious, Camera.main.transform.position, levelCompleteSoundVolumeSerious);
        }
    }

    public void KillEnemyMethod()
    {
        if (funnySounds == true)
        {
            AudioSource.PlayClipAtPoint(killEnemySound, Camera.main.transform.position, killEnemySoundVolume);
        } else
        {
            AudioSource.PlayClipAtPoint(killEnemySoundSerious, Camera.main.transform.position, killEnemySoundVolumeSerious);
        }
    }

    public void MushroomBounceMethod()
    {
        if (funnySounds == true)
        {
            AudioSource.PlayClipAtPoint(mushroomBounceSound, Camera.main.transform.position, mushroomBounceSoundVolume);
        } else
        {
            AudioSource.PlayClipAtPoint(mushroomBounceSoundSerious, Camera.main.transform.position, mushroomBounceSoundVolumeSerious);            
        }
    }

    public void GunFireMethod()
    {
        if (funnySounds == true)
        {
            AudioSource.PlayClipAtPoint(gunFireSound, Camera.main.transform.position, gunFireSoundVolume);
        } else
        {
            AudioSource.PlayClipAtPoint(gunFireSoundSerious, Camera.main.transform.position, gunFireSoundVolumeSerious);            
        }
    }
}
