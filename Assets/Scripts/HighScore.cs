using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static HighScore instance;
     private static int bestScore;
    private static string bestPlayer;
    public Text bestPlayerName;
    
    void Awake()
    {
        // if(instance != null)
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        // instance = this;
        // DontDestroyOnLoad(gameObject);

        // LoadScore();

        LoadGameRank();
    }

     private void SetBestPlayer()
    {
        if (bestPlayer == null && bestScore == 0)
        {
            bestPlayerName.text = "";
        }
        else
        {
            bestPlayerName.text = $"Best Score - {bestPlayer}: {bestScore}";
        }

    }

    public void LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.bestPlayerName;
            bestScore = data.highScore;
            SetBestPlayer();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string bestPlayerName;
    }

    // public void SaveScore()
    // {
    //     SaveData data = new SaveData();
        
    //     if(h_score > data.highScore)
    //     {   
    //         data.highScore = h_score;
    //         data.playerName = p_name;
    //     }
        
    //     string json = JsonUtility.ToJson(data);
    
    //     File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    // }

    // public void LoadScore()
    // {
    //     string path = Application.persistentDataPath + "/savefile.json";
    //     if (File.Exists(path))
    //     {
    //         string json = File.ReadAllText(path);
    //         SaveData data = JsonUtility.FromJson<SaveData>(json);

    //         h_score = data.highScore;
    //         p_name = data.playerName;
    //     }
    // }

    // public void SetPlayerName(string str)
    // {   
    //     Debug.Log($"Player input is: {str}");
    //     p_name = str;
    // }

}
