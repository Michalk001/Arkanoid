using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    #region Singleton
    private static AudioManager _instance;

    public static AudioManager Instance => _instance;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
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
    [SerializeField]
    AudioMixerGroup audioMixerGroup;
    void InitSound()
    {

        foreach(var item in Sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;
            item.source.loop = item.loop;
            item.source.outputAudioMixerGroup = audioMixerGroup;
        }
    }
    public float GetLength(string name)
    {
        var sound = Sounds.Find(x => x.name == name);
        if (sound != null)
        {
            return sound.clip.length;

        }
        return 0f;
    }

    public void Play(string name)
    {
        var sound = Sounds.Find(x => x.name == name);
        if(sound != null)
        {
            sound.source.Play();

        }
       
    }
    public void Play(string name,float delay)
    {
        var sound = Sounds.Find(x => x.name == name);
        if (sound != null)
        {
            sound.source.PlayDelayed(delay);

        }

    }
    public void Play(string name,Camera camera)
    {
        var sound = Sounds.Find(x => x.name == name);
        if (sound != null)
        {
            AudioSource.PlayClipAtPoint(sound.clip, camera.transform.position,1.0f);

        }
        
    }
    public void Stop(string name)
    {
        var sound = Sounds.Find(x => x.name == name);
        if (sound != null)
        {

            sound.source.Stop();
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
