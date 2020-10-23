using UnityEngine;
// Script was slightly rushed
public class Score : MonoBehaviour
{
    public static Score instance = null;
    public int score = 0;
    private void Awake()
    {
        if (instance == null) instance = this; else Destroy(this);
    }
}
