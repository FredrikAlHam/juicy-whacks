using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MidiPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MidiFile.Read(Path.Combine("C:", "testmidi.midi")).GetPlayback(new MidiClockSettings());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
