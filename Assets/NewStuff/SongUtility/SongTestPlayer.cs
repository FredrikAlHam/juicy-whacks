using System;
using System.Timers;
using UnityEngine;

namespace AudioUtilities
{
    public class SongTestPlayer : MonoBehaviour
    {
        new AudioSource audio = null;
        Controls controls = null;
        SongPlayer songPlayer = null;

        // Start is called before the first frame update
        void Start()
        {
            songPlayer = new SongPlayer();
            controls = new Controls();
            controls.Whacks.Enable();
            audio = GetComponent<AudioSource>();
            
        }
        public void Play(Song song) //Must be called on main thread
        {
            songPlayer = new SongPlayer();
            songPlayer.Play(song);
            audio.PlayOneShot(song.clip);

        }
        // Update is called once per frame
        void Update()
        {
            if (audio.clip == null && SongImporter.Ready)
            {
                audio.clip = SongImporter.MenuAudioClips[0];
                audio.Play();
            }
            if (!SongImporter.Ready)
            {
                return;
            }
            //Plays song of whack key index pressed
            if (!songPlayer.IsPlaying)
            {
                if (audio.isPlaying)
                {
                    //audio.Stop();
                }
                if (controls.Whacks.Whack1.triggered) Play(SongImporter.Songs[0]);
                if (controls.Whacks.Whack2.triggered) Play(SongImporter.Songs[1]);
                if (controls.Whacks.Whack3.triggered) Play(SongImporter.Songs[2]);
                if (controls.Whacks.Whack4.triggered) Play(SongImporter.Songs[3]);
                if (controls.Whacks.Whack5.triggered) Play(SongImporter.Songs[4]);
                if (controls.Whacks.Whack6.triggered) Play(SongImporter.Songs[5]);
            }
            else
            {
                
                for (int i = 0; i < Holes.holes.Length; i++)
                {
                    Hole hole = Holes.holes[i].GetComponent<Hole>();
                    if (songPlayer.Beat.holeIndecies[i] > 0)
                    {
                        hole.Hit();
                    }
                    else
                    {
                        hole.UnHit();
                    }
                }
            }
        }
    }

    public class SongPlayer
    {
        public Beat Beat { get; private set; } = new Beat() { holeIndecies = new int[] { 0, 0, 0, 0, 0, 0 } };
        public bool IsPlaying { get; private set; } = false;
        private Song song = null;
        public int BeatIndex { get; private set; } = 0;
        private Timer beatTimer = new Timer();


        public void Play(Song song)
        {
            this.song = song;
            Play();
        }
        public void Play()
        {
            BeatIndex = 0;
            beatTimer.Interval = 60000 / Convert.ToDouble(song.bpm)/*ms in minutes*/;
            IsPlaying = true;
            beatTimer.Elapsed += BeatTimer_Elapsed;
            beatTimer.Start();
        }

        private void BeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (BeatIndex >= song.beats.Length)
            {
                IsPlaying = false;
                beatTimer.Stop();
            }
            Beat = song.beats[BeatIndex];
            BeatIndex++;
        }
        public SongPlayer(Song song)
        {
            this.song = song;
        }
        public SongPlayer()
        {

        }

    }

}