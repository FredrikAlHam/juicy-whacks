using UnityEngine;
﻿using System.Collections.Generic;

public class Hole : MonoBehaviour
{
    SpriteRenderer sR;
    [SerializeField] public bool IsHit { get; private set; } = false;

    [SerializeField] public List<int> queue = new List<int>();
    public int beatIndex = 0;
    public float timeSinceLastBeat = 0;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    public void Hit()
    {
        IsHit = true;
        sR.color = Color.red;
    }
    public void UnHit()
    {
        IsHit = false;
        sR.color = Color.white;
    }

    void Update()
    {
        if (queue.Count == 0 || queue.Count < beatIndex) return;
        else if (queue[beatIndex] > 0)
        {
            timeSinceLastBeat = 0f;
            sR.color = Color.green;
        }
        else
        {
            timeSinceLastBeat += Time.deltaTime;
            sR.color = Color.white;
        }
    }
}
