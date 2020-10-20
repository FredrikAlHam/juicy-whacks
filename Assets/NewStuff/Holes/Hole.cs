using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] public bool IsHit { get; private set; } = false;

    [SerializeField] public List<int> queue = new List<int>();
    public int beatIndex = 0;
    public float timeSinceLastBeat = 0;
    // Start is called before the first frame update


    public virtual void Hit()
    {

    }
    public virtual void UnHit()
    {

    }
    public virtual void PrepareToPopup()
    {

    }
    public virtual void Popup()
    {

    }
    public virtual void UnPopup()
    {

    }
    protected virtual void Update()
    {
        if (queue.Count == 0 || queue.Count < beatIndex) return;
        else if (queue[beatIndex] > 0)
        {
            Popup();
        }
        else if (queue[beatIndex - 1] > 0)
        {
            UnPopup();
        }
        else if (queue[beatIndex + 1] > 0)
        {
            PrepareToPopup();
        }
    }
}
