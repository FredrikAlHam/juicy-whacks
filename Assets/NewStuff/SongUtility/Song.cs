using System;
using System.Collections.Generic;
using UnityEngine;

namespace AudioUtilities
{
    [Serializable]
    public class Beat
    {
        public int[] holeIndecies = new int[] { 0, 0, 0, 0, 0, 0 };
    }
    [CreateAssetMenu(fileName = "SongName", menuName = "Song", order = 1)]
    public class Song : ScriptableObject //I think I've fallen in love with scriptable objects
    {
        public Beat[] beats;
        public string songName;
        public int timeSig1; //Was planning on using these but no time and lacking music theory
        public int timeSig2; //Was planning on using these but no time and lacking music theory
        public int bpm;
        public float milliesStartDelay = 0.00000001f;
        public AudioClip clip;

        public void Log()
        {
            Debug.Log(JsonUtility.ToJson(this));

        }

        public List<int> GetIntArray(int holeIndex)
        {
            List<int> ints = new List<int>();
            foreach (Beat beat in beats)
            {
                //Debug.Log(beat.holeIndecies[i] + " in " + i);
                ints.Add(beat.holeIndecies[holeIndex]);
            }

            return ints;

        }
    }
}
