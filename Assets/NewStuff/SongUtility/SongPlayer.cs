﻿using System;
using System.Timers;
using UnityEngine;

namespace AudioUtilities
{
    public class SongPlayer : IDisposable
    {
        /*Whole class written by F*/ 
        public Beat Beat { get; private set; } = new Beat() { holeIndecies = new int[] { 0, 0, 0, 0, 0, 0 } };
        public bool IsPlaying { get; private set; } = false;
        public bool IsDone { get; private set; } = false;
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
            beatTimer.Interval = 60000 / Convert.ToDouble(song.bpm)/*ms per beat*/ / 4 /* to sixteenths*/;
            IsPlaying = true;
            Timer delay = new Timer(song.milliesStartDelay);
            delay.Elapsed += (sender, ctx) => { beatTimer.Start(); delay.Stop(); delay.Dispose(); };
            delay.Start();
            beatTimer.Elapsed += BeatTimer_Elapsed;
        }
        public void Pause()
        {
            if (beatTimer.Enabled)
            {
                beatTimer.Stop();
            }
            else
            {
                beatTimer.Start();
            }
            
        }
        private void BeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (BeatIndex >= song.beats.Length)
            {
                IsPlaying = false;
                beatTimer.Stop();
                IsDone = true;
            }
            else
            {
                Beat = song.beats[BeatIndex];
                BeatIndex++;
                //Debug.Log("on beat " + BeatIndex);
            }
        }

        public void Dispose()
        {
            //Hopefully to stop a memoryleak I discovered and also because beatTimer continued dispite the game being stopped because Timer callbacks aren't run on the main thread
            beatTimer.Stop();
            beatTimer.Dispose();
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