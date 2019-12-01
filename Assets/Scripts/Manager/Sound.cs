using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound 
{
    [SerializeField]
    public Type type;
    public enum Type { Music, EFX };
    public string name;
    public AudioClip clip;
    public bool loop = false;
    [HideInInspector]
    public AudioSource source;

}
