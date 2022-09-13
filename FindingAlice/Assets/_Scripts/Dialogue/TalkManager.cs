﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Position
{
    left = 0,
    right = 1,


    max
}

public class TalkData
{
    public string name;
    public Sprite sprite;
    public string talkContents;

    public Position position;
}

public class TalkManager : MonoBehaviour
{
    Dictionary<int, TalkData[]> talkData;
    private void Awake()
    {
        talkData = new Dictionary<int, TalkData[]>();
        GenerateData();

    }

    private void GenerateData() // 데이터 만드는 함수
    {
        TalkData a = new TalkData() { name = "토끼", sprite = null, talkContents = "윽... 머리야.", position = Position.left };
        TalkData b = new TalkData() { name = "토끼", sprite = null, talkContents = "제대로 온 건가..?", position = Position.left };

        TalkData c = new TalkData() { name = "???", sprite = null, talkContents = "사람 살려!!!", position = Position.right };
        TalkData d = new TalkData() { name = "토끼", sprite = null, talkContents = "무슨 일이 일어나는 거지?", position = Position.left };
        talkData.Add(1, new TalkData[]{ a, b });
        talkData.Add(2, new TalkData[] { c, d });
    }

    public TalkData GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)

            return null;
        else
            return talkData[id][talkIndex];
    }
#if false
    public string GameDataFileName = "FindingAlliceData.json";

    public GameData LoadGameData(){
        string filePath = Application.dataPath + "/SaveFile/" + GameDataFileName;

        if(File.Exists(filePath)){
            Debug.Log("Load Succes");
            string FromJsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else{
            Debug.Log("Create New File");
            return new GameData();
        }
    }

    public void SaveGameData(){
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.dataPath + "/SaveFile/" + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("Save Succes");
        Debug.Log("savePoint"+ gameData.playerPosition);
    }
#endif

}
