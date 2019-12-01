using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{

    #region Singleton
    private static AudioManager _instance;

    public static AudioManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        InitSound();
    }
    #endregion

    [SerializeField]
    public List<Sound> Sounds;

    void InitSound()
    {

        foreach(var item in Sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;
            item.source.pitch = 1f;
        }
    }

    public void Play(string name)
    {
        var sound = Sounds.Find(x => x.name == name);
        if(sound != null)
        {
            sound.source.ignoreListenerPause = true;
            sound.source.Play();
        }
       
    }
    public void Pause(string name)
    {
        var sound = Sounds.Find(x => x.name == name);
        if (sound != null)
        {

            sound.source.Pause();
        }

    }
    public void UnPause(string name)
    {
        var sound = Sounds.Find(x => x.name == name);
        if (sound != null)
        {

            sound.source.UnPause();
        }

    }

}
