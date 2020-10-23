using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    /*
     This script is literally me being lazy. In retrospect I should have just put them as a static array in Hole.cs as Hole.holes and
     added each one on Start() to the array - F
         */
    public static GameObject[] holes { get; private set; }
    void Start()
    {
        holes = new GameObject[transform.childCount];
        for (int i = 0; i < holes.Length; i++)
        {
            holes[i] = transform.GetChild(i).gameObject;
        }
    }
}
