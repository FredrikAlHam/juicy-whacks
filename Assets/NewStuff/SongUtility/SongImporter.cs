using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SongImporter : MonoBehaviour
{
    List<Song> songs = new List<Song>();
    // Start is called before the first frame update
    void Start()
    {
        //new Song() { beats = new Beat[] { new Beat() } , bpm = 100, songName = "rappasen", timeSig1 = 4, timeSig2 = 4 }.Log();

        foreach (FileInfo fI in new DirectoryInfo(Path.Combine(Application.dataPath, "Resources", "songdata")).GetFiles("*.songdata"))
        {
            StreamReader sR = new StreamReader(fI.OpenRead());
            Song song = Song.fromJson(sR.ReadToEnd());
            songs.Add(song);
            song.Log();
        }


        //Song.fromJson("{\"songName\":\"rappasen\",\"timeSig1\":1,\"timeSig2\":2,\"bpm\":100}").Log();
        //GetComponent<AudioSource>().PlayOneShot(Song.fromJson("{\"songName\":\"rappasen\",\"timeSig1\":1,\"timeSig2\":2,\"bpm\":100}").clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
