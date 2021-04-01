using UnityEngine;
///////////////////////////////////////////////////
//
//
//
//
//
////////////////////////////////////////////////////
public class ManagerSFX : MonoBehaviour
{
#region Singleton
    public static ManagerSFX Instance { get; private set; }
#endregion
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioBarbarians;
    [SerializeField] private AudioClip audioAchivement;
#region Players
    // Barbarian
    
#endregion
    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        DontDestroyOnLoad(this);
    }
    public void AudioPlayAchivement()
    {
        audioSource.clip = audioAchivement;
        audioSource.Play();
    }

    public void SoundActive(int id)
    {
        audioSource.clip = audioBarbarians[id];
    }
}
