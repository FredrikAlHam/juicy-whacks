using System;
using System.Collections.Generic;
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
        public float milliesStartDelay = 0;
        public AudioClip clip;

        public void Log()
        {
            Debug.Log(JsonUtility.ToJson(this));

        }

        public List<int> GetIntArray(int i)
        {
            List<int> ints = new List<int>();
            foreach (Beat beat in beats)
            {
                //Debug.Log(beat.holeIndecies[i] + " in " + i);
                ints.Add(beat.holeIndecies[i]);
            }

            return ints;

        }
    }
}
