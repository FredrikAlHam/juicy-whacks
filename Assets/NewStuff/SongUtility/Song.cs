using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AudioUtilities
{
    [Serializable]
    public class Beat
    {
        public int[] holeIndecies = new int[] { 0, 0, 0, 0, 0, 0 };
    }
    [CreateAssetMenu(fileName = "SongName", menuName = "Song", order = 1)]
    public class Song : ScriptableObject
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
    }
}
