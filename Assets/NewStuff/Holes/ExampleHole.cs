using UnityEngine;
using System.Collections;

public class ExampleHole : Hole
{
    /*
     Example of inherited hole script, for simplicity's sake we didn't go this route (You should have preached
     about the advantages of inheritance more Tobbe) - F
         */

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
