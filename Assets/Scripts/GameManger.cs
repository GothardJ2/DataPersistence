using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public string userName;
    public int scoreText;

    private void Awake()
    {
        // start of new code
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();                      
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
    }

    public void SaveHighScore(int newHighScore)
    {
        SaveData data = new SaveData();
        data.highScore = newHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            scoreText = data.highScore;
        }
    }


}
