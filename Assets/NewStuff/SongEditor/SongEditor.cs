﻿using AudioUtilities;
using UnityEngine;
using UnityEngine.UI;

public class SongEditor : MonoBehaviour
{
    public GameObject ViewPort = null;
    public GameObject TrackTemplate = null;
    public GameObject LabelTemplate = null;
    public GameObject BeatBtn = null;
    public Color BeatColor = Color.blue;
    public Color OddColor = Color.gray;

    [SerializeField] private Song song = null;
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
        song = SongImporter.Songs[0];
#endif
        for (int tI = 0; tI < song.beats[0].holeIndecies.Length /*Tracks*/; tI++)
        {
            GameObject trackO = Instantiate(TrackTemplate, ViewPort.transform);
            trackO.SetActive(true);
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
                    btnO.transform.GetComponentInChildren<Text>().text = beats.ToString();
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

    private void OnDisable()
    {
        SongImporter.Complete -= SongImporter_Complete;

    }
    // Update is called once per frame
    void Update()
    {

    }
}