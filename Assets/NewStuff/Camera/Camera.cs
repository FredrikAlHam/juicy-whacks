using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Vector2 leftAmplitude;
    public Vector2 leftFrequency;

    public Vector2 rightAmplitude;
    public Vector2 rightFrequency;

    public Vector2 downAmplitude;
    public Vector2 downFrequency;

    private Vector2 time = Vector2.zero;

    [SerializeField]
    public bool shouldShakeLeft = false;
    public bool shouldShakeRight = false;
    public bool shouldShakeDown = false;

    public static float shakeTime;


   /* public IEnumerator Shake(float duration, float magnitude) //Coroutine used for shaking the camera
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    } */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region leftShake
        Vector3 shakePos = transform.localPosition;

        if(shouldShakeLeft == true)
        {
            time += new Vector2(Time.deltaTime, Time.deltaTime) * leftFrequency;

            shakePos = new Vector3(Mathf.Sin(time.x), Mathf.Sin(time.y), -30) * leftAmplitude;

            transform.localPosition = shakePos;

            
        }

        /*
        if(shouldShakeLeft == false)
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
        */

        #endregion

        #region rightShake

        if (shouldShakeRight)
        {
            time += new Vector2(Time.deltaTime, Time.deltaTime) * rightFrequency;

            shakePos = new Vector3(Mathf.Sin(time.x), Mathf.Sin(time.y), -30) * rightAmplitude;

            transform.localPosition = shakePos;
        }

        /*
        if (shouldShakeRight == false)
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
        */

        #endregion

        #region downShake

        if (shouldShakeDown)
        {
            time += new Vector2(Time.deltaTime, Time.deltaTime) * downFrequency;

            shakePos = new Vector3(Mathf.Sin(time.x), Mathf.Sin(time.y), -30) * downAmplitude;

            transform.localPosition = shakePos;
        }
        
        /*
        if (shouldShakeDown == false)
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
        */

        #endregion




    }
}
