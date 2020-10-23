using AudioUtilities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongEditor : MonoBehaviour
{
    /*This is about to be obsoletet, but it works atleast, also needs some multithreading to not freeze the entire 
     game/the whole of unity when loading and saving. I'm working on my free time on this as a side project so that maybe in the future it
     just work by reading MIDI instead (Progress on that front might exist on another branch) - F


     *** IMPORTANT!! DO NOT REFRESH/RECOMPILE SOLUTION WHILE THE EDITOR IS RUNNING!!! THE GAME/EDITOR WILL CRASH ***
     */

    public GameObject ViewPort = null;
    public GameObject TrackTemplate = null;
    public GameObject LabelTemplate = null;
    public GameObject BeatBtn = null;
    public Color BeatColor = Color.blue;
    public Color OddColor = Color.gray;

#if UNITY_EDITOR
    [SerializeField] bool LoadFirstSongFound = false;
#endif
    [SerializeField] private Song song = null;
    private List<GameObject> trackObjs = new List<GameObject>();
    private void Start()
    {
        if (SongImporter.Ready)
        {
            SongImporter_Complete();
        }

    }
    private void OnEnable()
    {
        SongImporter.Complete += SongImporter_Complete;
    }

    private void SongImporter_Complete()
    {

#if UNITY_EDITOR
        /*For testing only*/
        if (LoadFirstSongFound) song = SongImporter.Songs[0];
#endif
        for (int tI = 0; tI < song.beats[0].holeIndecies.Length /*Tracks*/; tI++)
        {
            GameObject trackO = Instantiate(TrackTemplate, ViewPort.transform);
            trackO.SetActive(true);
            trackObjs.Add(trackO);
            GameObject label = Instantiate(LabelTemplate, trackO.transform);
            label.transform.GetComponentInChildren<Text>().text = $"Track\n{tI + 1}";
            label.SetActive(true);
            int beats = 0;

            for (int bI = 0; bI < song.beats.Length; bI++)
            {
                GameObject btnO = Instantiate(BeatBtn, trackO.transform);
                btnO.SetActive(true);
                SongEditorBtn btn = btnO.GetComponent<SongEditorBtn>();

                if (bI % 4 == 0)
                {
                    btnO.transform.GetComponentInChildren<Text>().text = (beats + 1).ToString();
                    beats++;
                    btn.SetDefaultColor(BeatColor);
                }
                else if (bI % 2 == 0)
                {
                    btn.SetDefaultColor(OddColor);
                }
                btn.SetValue(song.beats[bI].holeIndecies[tI]);
            }
        }
    }
    public void SongSave()
    {
        for (int bI = 0; bI < ViewPort.transform.GetChild(3).GetComponentsInChildren<SongEditorBtn>().Length; bI++)
        {
            List<int> indecies = new List<int>();
            for (int tI = 0; tI < trackObjs.Count; tI++)
            {
                indecies.Add(trackObjs[tI].transform.GetComponentsInChildren<SongEditorBtn>()[bI].GetValue());
            }
            song.beats[bI] = new Beat() { holeIndecies = indecies.ToArray() };
        }


    }

    private void OnDisable()
    {
        SongImporter.Complete -= SongImporter_Complete;

    }
}
