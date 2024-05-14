using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public static AudioManager Instance { get; private set; }

    private Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();
    private AudioSource effectSource;  // General AudioSource for effects
    private AudioSource musicSource;
    private AudioSource walkingSource;

    public float backgroundMusicVolume = 0.62f; // Default volume level, adjust as needed

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            effectSource = gameObject.AddComponent<AudioSource>();
            walkingSource = gameObject.AddComponent<AudioSource>();
            musicSource = gameObject.AddComponent<AudioSource>();
            LoadAllAudioClips();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadAllAudioClips()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");
        foreach (AudioClip clip in clips)
        {
            audioClips[clip.name] = clip;
        }
    }

    public void StartUp()
    {
        if (status == ManagerStatus.Initializing || status == ManagerStatus.Started)
            return;

        status = ManagerStatus.Initializing;
        LoadAllAudioClips(); // Ensure all audio clips are loaded.
        status = ManagerStatus.Started; // Set status to Started once initialization is complete.
        Debug.Log("AudioManager started.");
    }
    void Start()
    {
        AudioManager.Instance.PlayBackgroundMusic("BackgroundAmbience");
    }

    public void PlaySoundEffect(string clipName, Vector3 position)
    {
        if (audioClips.TryGetValue(clipName, out AudioClip clip))
        {
            AudioSource.PlayClipAtPoint(clip, position);
        }
        else
        {
            Debug.LogWarning("Sound clip not found: " + clipName);
        }
    }

    public void PlayBackgroundMusic(string name)
    {
        if (audioClips.TryGetValue(name, out AudioClip clip))
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.volume = backgroundMusicVolume;

            musicSource.Play();
        }
        else
        {
            Debug.LogWarning($"Music clip not found: {name}");
        }
    }
    public void PlayPauseSound(string name)
    {
        if (audioClips.TryGetValue(name, out AudioClip clip))
        {
            effectSource.PlayOneShot(clip);  // Assuming effectSource is your generic AudioSource for sound effects
        }
        else
        {
            Debug.LogWarning($"Pause sound clip not found: {name}");
        }
    }

    public void PlayResumeSound(string name)
    {
        if (audioClips.TryGetValue(name, out AudioClip clip))
        {
            effectSource.PlayOneShot(clip);  // Using the same AudioSource for simplicity
        }
        else
        {
            Debug.LogWarning($"Resume sound clip not found: {name}");
        }
    }

    public void PlayWalkSound(string name)
    {
        if (!walkingSource.isPlaying)
        {
            if (audioClips.TryGetValue(name, out AudioClip clip))
            {
                walkingSource.clip = clip;
                walkingSource.loop = true;
                walkingSource.Play();
            }
        }
    }

    public void StopWalkSound()
    {
        if (walkingSource.isPlaying)
        {
            walkingSource.Stop();
        }
    }

    // Method to check if the walking sound is currently playing
    public bool IsPlayingWalkSound()
    {
        return walkingSource.isPlaying;
    }

    public void PlayJumpSound(Vector3 position)
    {
        string jumpSoundName = "PlayerJumping";
        PlaySoundEffect(jumpSoundName, position);
    }

    public void PlayDoorSound(Vector3 position)
    {
        string doorSoundName = "DoorOpen";
        if (audioClips.TryGetValue(doorSoundName, out AudioClip clip))
        {
            AudioSource.PlayClipAtPoint(clip, position);
        }
        else
        {
            Debug.LogWarning("Door sound clip not found: " + doorSoundName);
        }
    }


}
