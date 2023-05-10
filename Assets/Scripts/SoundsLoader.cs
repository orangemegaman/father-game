using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SoundsLoader : MonoBehaviour
{
   [SerializeField] private AudioSource _asSounds;
   [SerializeField] private AudioSource _asMusic;
    [SerializeField] private List<AudioClip> _audioClips;
    private bool _isAssetsLoaded = false;
    private bool _inProcess = false;
    private void Start()
    {
        _isAssetsLoaded = false;
        _inProcess = false;
    }
    public void Init()
    {
        if (_inProcess) return;
        if (_isAssetsLoaded) return;
        _inProcess = true;
        LoadAssets();
    }
    public void PlaySounds(int id)
    {
        if (id >= _audioClips.Count) return;
        if (_audioClips[id] == null) return;
        _asSounds.PlayOneShot(_audioClips[id]);
    }
    public void PlayMusic(int id)
    {
        if (id >= _audioClips.Count) return;
        if (_audioClips[id] == null) return;
        _asMusic.clip = _audioClips[id];
       _asMusic.loop = true;      
        _asMusic.Play(); 
    }
    public void StopMusic()
    {
        _asMusic.Stop();
    }  

    #region -LOAD ASSETS-
    [SerializeField] private List<string> _clipUrl;
    private void LoadAssets()
    {
        var url = Application.streamingAssetsPath + "/";
        foreach (var clip in _clipUrl)
        {
            _audioClips.Add(null);
            StartCoroutine(LoadClip(url + clip + ".mp3", _audioClips.Count - 1));
        }
    }
    IEnumerator LoadClip(string url, int id)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                _audioClips[id] = DownloadHandlerAudioClip.GetContent(www);
                if (IsDone())
                {
                    _inProcess = false;
                    _isAssetsLoaded = true;
                }
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
    private bool IsDone()
    {
        for (int i = 0; i < _audioClips.Count; i++)
        {
            if (_audioClips[i] == null) return false;
        }
        return true;
    }
    #endregion
}
