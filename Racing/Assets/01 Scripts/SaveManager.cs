using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

[Serializable]
public class PlayerData
{
    public string PlayerName;
    public int Gold;
    public string CurEngine;
    public string CurWheel;
    public List<string> HaveWheels;
    public List<string> HaveEngines;

    public PlayerData(string name)
    {
        PlayerName = name;
        Gold = 0;
        CurEngine = "V4Engine";
        CurWheel = "NormalWheel";
        HaveWheels = new List<string>();
        HaveWheels.Add(CurWheel);
        HaveEngines = new List<string>();
        HaveEngines.Add(CurEngine);
    }

    public bool IsHaveMoney(int price)
    {
        if(Gold >= price)
        {
            Gold -= price;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetGold(int gold)
    {
        Gold += gold;
    }
}

[Serializable]
public class RankData
{
    public string PlayerName;
    public int PlayerScore;

    public RankData()
    {

    }

    public RankData(string name, int score)
    {
        PlayerName = name;
        PlayerScore = score;
    }
}


[Serializable]
public class Ranking
{
    public List<RankData> rankingData;
    public Ranking()
    {
        rankingData = new List<RankData>();
    }
}

public class SaveManager : Singletone<SaveManager>
{
    private PlayerData curData;
    public PlayerData CurData => curData;

    public string CurName;
    public string DataPath;
    public int Score;

    public Ranking RankingData;

    public void Init()
    {
        SaveData();
        curData = new PlayerData("");
        CurName = string.Empty;
        DataPath = string.Empty;
        Score = 0;
    }

    public void SaveData()
    {
        if (!Directory.Exists(Application.dataPath + "/data"))
        {
            Directory.CreateDirectory(Application.dataPath + "/data/");
        }

        string jsonData = "";
        if (!File.Exists(DataPath))
        {
            curData = new PlayerData(CurName);
            jsonData = JsonUtility.ToJson(curData);
            File.WriteAllText(DataPath, jsonData);
            return;
        }

        jsonData = JsonUtility.ToJson(curData);
        File.WriteAllText(DataPath, jsonData);
    }

    public void LoadData(string name, Action callback = null)
    {
        CurName = name;
        DataPath = Path.Combine(Application.dataPath + "/data/" + name + ".json");
        if (!File.Exists(DataPath))
        {
            SaveData();
            LoadData(name, () =>
            {
                SceneManager.LoadScene("Story");
            });
            return;
        }

        string jsonData = File.ReadAllText(DataPath);
        curData = JsonUtility.FromJson<PlayerData>(jsonData);
        callback?.Invoke();
    }

    public void LoadRank()
    {
        if (!File.Exists(Application.dataPath + "/Rank/rank.json"))
        {
            SaveRank();
            LoadRank();
            return;
        }

        string jsonData = File.ReadAllText(Application.dataPath + "/Rank/rank.json");
        RankingData = JsonUtility.FromJson<Ranking>(jsonData);
        Debug.Log("저장된 랭킹 불러오기");
    }

    public void SaveRank()
    {
        if (!File.Exists(Application.dataPath + "/Rank/rank.json"))
        {
            if (!Directory.Exists(Application.dataPath + "/Rank/"))
            {
                Directory.CreateDirectory(Application.dataPath + "/Rank/");
            }
            RankingData = new Ranking();
            string newJson = JsonUtility.ToJson(RankingData);
            File.WriteAllText(Application.dataPath + "/Rank/rank.json", newJson);
            Debug.Log("저장 완료");
            return;
        }

        RankData rankData = new RankData(CurName, Score);
        int index = RankingData.rankingData.FindIndex(i => i.PlayerName == rankData.PlayerName);
        if(index != -1)
        {
            if(RankingData.rankingData[index].PlayerScore <= rankData.PlayerScore)
            {
                RankingData.rankingData[index].PlayerScore = rankData.PlayerScore;
            }
        }
        else
        {
            RankingData.rankingData.Add(rankData);
        }
        if(RankingData.rankingData.Count > 5)
        {
            RankingData.rankingData.RemoveAt(5);
        }
        RankingData.rankingData.OrderBy(i => i.PlayerScore);
        string jsonData = JsonUtility.ToJson(RankingData);
        File.WriteAllText(Application.dataPath + "/Rank/rank.json", jsonData);
        Debug.Log("저장 완료");
    }
    
}
