using UnityEngine;
using System.Collections;

public class ExampleHole : Hole
{
    SpriteRenderer sR = null;
    // Use this for initialization
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Hit()
    {

    }
    public override void UnHit()
    {

    }
    public override void PrepareToPopup()
    {

    }
    public override void Popup()
    {
        timeSinceLastBeat = 0f;
        sR.color = Color.green;
    }
    public override void UnPopup()
    {
        timeSinceLastBeat += Time.deltaTime;
        sR.color = Color.white;
    }
}
