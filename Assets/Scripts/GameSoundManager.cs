using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    private AudioSource[] _audioSources;
    private bool _isSoundEnabled;

    private void Awake()
    {
        _audioSources = GetComponents<AudioSource>();
        _isSoundEnabled = PlayerPrefs.GetInt("sound", 1) == 1;
    }

    private void Update()
    {
        if (!_isSoundEnabled)
        {
            StopAllAudioSources();
        }
        else
        {
            UpdateMenuMusicPlayback();
        }
    }

    public bool IsSoundEnabled => _isSoundEnabled;

    public void PlayJumpSound()
    {
        if (_isSoundEnabled)
        {
            _audioSources[2].Play();
        }
    }

    public void PlayCoinCollectSound()
    {
        if (_isSoundEnabled)
        {
            _audioSources[0].Play();
        }
    }

    public void PlayDeathSound()
    {
        if (_isSoundEnabled)
        {
            _audioSources[1].Play();
        }
    }

    public void PlayGameSound()
    {
        if (_isSoundEnabled)
        {
            _audioSources[3].Play();
        }
    }

    public void PlayMainMenuSound()
    {
        if (_isSoundEnabled)
        {
            _audioSources[4].Play();
        }
    }

    public void ToggleSoundState()
    {
        _isSoundEnabled = !_isSoundEnabled;
        PlayerPrefs.SetInt("sound", _isSoundEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateMenuMusicPlayback()
    {
        if (_audioSources[4].time >= 8)
        {
            PlayMainMenuSound();
        }
    }

    private void StopAllAudioSources()
    {
        foreach (var audioSource in _audioSources)
        {
            audioSource.Stop();
        }
    }
}