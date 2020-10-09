using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    public static GameObject[] holes { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        holes = new GameObject[transform.childCount];
        for (int i = 0; i < holes.Length; i++)
        {
            holes[i] = transform.GetChild(i).gameObject;
        }
    }
}
