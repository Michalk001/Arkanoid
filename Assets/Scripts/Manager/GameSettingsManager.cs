using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Audio;

public class GameSettingsManager : MonoBehaviour
{

    #region Singleton
    private static GameSettingsManager _instance;

    public static GameSettingsManager Instance => _instance;

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
       
    }
    #endregion

    public GameSettings gameSettings;
    [HideInInspector]
    public string pathSettings;
    public AudioMixer audioMixer;
    void Start()
    {
        gameSettings = new GameSettings();
        pathSettings = Application.persistentDataPath + "/settings.json";
        if(Load())
        {
            Config();
        }
       
        
    }

    private void Config()
    {
        audioMixer.SetFloat("volume", gameSettings.Volume);
    }

    public void Save()
    {
       
        string jsonString;
        jsonString = JsonUtility.ToJson(gameSettings);
        using (FileStream file = new FileStream(pathSettings, FileMode.OpenOrCreate))
        {
            byte[] saveString = new UTF8Encoding(true).GetBytes(jsonString);
            file.Write(saveString, 0, saveString.Length);
            file.Close();
        }

    }

    public bool Load()
    {
        if (File.Exists(pathSettings))
        {
            FileStream file = new FileStream(pathSettings, FileMode.Open);
            byte[] buffor = new byte[file.Length];
            file.Read(buffor, 0, (int)file.Length);
            string jsonString = new UTF8Encoding(true).GetString(buffor);
            gameSettings = JsonUtility.FromJson<GameSettings>(jsonString);
            file.Close();
            return true;
        }
        else
            return false;

    }

}
