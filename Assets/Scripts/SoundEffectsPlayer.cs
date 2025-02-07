using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public static SoundEffectsPlayer Instance;
    public AudioSource audioSource;
    public AudioSource backgroundMusicSource;

    public AudioClip backgroundMusic;
    public AudioClip correctAnswerSound;
    public AudioClip wrongAnswerSound;
    public AudioClip characterDiedSound;
    public AudioClip characterShotSound;
    public AudioClip wrongCharacterSelectedSound;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayCorrectAnswerSound()
    {
        PlaySoundEffect(correctAnswerSound);
    }

    public void PlayWrongAnswerSound()
    {
        PlaySoundEffect(wrongAnswerSound);
    }

    public void PlayCharacterDiedSound()
    {
        PlaySoundEffect(characterDiedSound);
    }

    public void PlayCharacterShotSound()
    {
        PlaySoundEffect(characterShotSound);
    }

    public void PlayWrongCharacterSelectedSound()
    {
        PlaySoundEffect(wrongCharacterSelectedSound);
    }

    public void PlayBackgroundMusic()
    {
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}