using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    public string playerName;

    public string highScorePlayerName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScorePlayerName = highScorePlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highScorePlayerName;
            highScore = data.highScore;
        }
    }
}
