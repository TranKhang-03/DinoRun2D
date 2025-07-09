using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private AudioSource effectsSource;
    [SerializeField]
    private AudioClip jumpClips;
    [SerializeField]
    private AudioClip tapClips;
    [SerializeField]
    private AudioClip hurtClips;
    [SerializeField]
    private AudioClip crackEggClips;
    private bool hasPlayedEffectsSound = false;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public bool HasPlayedEffectsSound()
    {
            return hasPlayedEffectsSound;
    }
    public void SetHasPlayedEffectsSound(bool value)
    {
        hasPlayedEffectsSound = value;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effectsSource.Stop();
        hasPlayedEffectsSound = true;
    }
    public void PlayJumpClip()
    {
        effectsSource.PlayOneShot(jumpClips);
    }
    public void PlayTapClip()
    {
        effectsSource.PlayOneShot(tapClips);
    }
    public void PlayHurtClip()
    {
        effectsSource.PlayOneShot(hurtClips);
    }
    public void PlayCrackEggClip()
    {
        effectsSource.PlayOneShot(crackEggClips);
    }
}
