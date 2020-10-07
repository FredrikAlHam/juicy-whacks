using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Beat
{
    public int[] holeIndecies = new int[] { 0, 0, 0, 0, 0, 0 };
}
public class Song
{
    public Beat[] beats;
    public string songName;
    public int timeSig1;
    public int timeSig2;
    public int bpm;
    public AudioClip clip;

    public void Log()
    {
        Debug.Log(JsonUtility.ToJson(this));

    }
    public static Song fromJson(string json)
    {
        Song jsonObj = JsonUtility.FromJson<Song>(json);
        jsonObj.clip = (AudioClip)Resources.Load(jsonObj.songName);
        //if (jsonObj.clip == null) Debug.LogWarning("song not found"); // funkar ej
        return jsonObj;
    }
}


