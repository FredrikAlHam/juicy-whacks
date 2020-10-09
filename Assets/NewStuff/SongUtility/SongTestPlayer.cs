using System;
using System.Timers;
using UnityEngine;

namespace AudioUtilities
{
    public class SongTestPlayer : MonoBehaviour
    {
        new AudioSource audio = null;
        Controls controls = null;
        [SerializeField] Beat currentBeat = null;
        [SerializeField] int currentBeatIndex = 0;
        public Song CurrentSong { get => currentSong; set { currentSong = value; } }

        Timer beatTimer = null;
        private Song currentSong = null;

        // Start is called before the first frame update
        void Start()
        {
            controls = new Controls();
            controls.Whacks.Enable();
            audio = GetComponent<AudioSource>();
        }
        private void OnEnable()
        {
            beatTimer = new Timer();
            beatTimer.Elapsed += Beat;
        }

        private void Beat(object sender, ElapsedEventArgs e)
        {
            currentBeat = currentSong.beats[currentBeatIndex];
            currentBeatIndex++;
            if (currentBeatIndex >= CurrentSong.beats.Length) Stop();
        }
#pragma warning disable UNT0006 // Incorrect message signature
        public void Start(Song song)
        {
            Stop();
            currentBeatIndex = 0;
            beatTimer.Interval = 60000 / Convert.ToDouble(song.bpm)/*ms in minutes*/;
            Debug.Log(song.bpm);
            CurrentSong = song;
            audio.PlayOneShot(CurrentSong.clip);
            beatTimer.Start();
        }
#pragma warning restore UNT0006 // Incorrect message signature

        public void Stop()
        {
            audio.Stop();
            beatTimer.Stop();
            currentBeatIndex = 0;
        }

        private void OnDisable()
        {
            beatTimer.Elapsed -= Beat;
            beatTimer.Dispose();
        }

        // Update is called once per frame
        void Update()
        {
            //Plays song of whack key index pressed
            if (SongImporter.Ready && !beatTimer.Enabled)
            {
                if (controls.Whacks.Whack1.triggered) Start(SongImporter.Songs[0]);
                if (controls.Whacks.Whack2.triggered) Start(SongImporter.Songs[1]);
                if (controls.Whacks.Whack3.triggered) Start(SongImporter.Songs[2]);
                if (controls.Whacks.Whack4.triggered) Start(SongImporter.Songs[3]);
                if (controls.Whacks.Whack5.triggered) Start(SongImporter.Songs[4]);
                if (controls.Whacks.Whack6.triggered) Start(SongImporter.Songs[5]);
            }
            if (!beatTimer.Enabled) Stop();
        }
    }

}