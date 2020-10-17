using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Vector2 leftAmplitude;  //Variable to determine the range/amplitude of the (left) shake    -    Erik
    public Vector2 leftFrequency;  //Variable to determine the rate of which the (left) shake moves/occurs    -    Erik    

    public Vector2 rightAmplitude;  //Variable to determine the range/amplitude of the (right) shake    -    Erik
    public Vector2 rightFrequency;  //Variable to determine the rate of which the (right) shake moves/occurs    -    Erik

    public Vector2 downAmplitude;  //Variable to determine the range/amplitude of the (down) shake    -    Erik
    public Vector2 downFrequency;  //Variable to determine the rate of which the (down) shake moves/occurs    -    Erik

    private Vector2 time = Vector2.zero;  //Variable which determines where the camera should move to at a specific time    -    Erik

    [SerializeField]
    public bool shouldShakeLeft = false;  //True or false statement to determine when the shake should occur    -    Erik
    public bool shouldShakeRight = false;  //same but for the rightShake    -    Erik
    public bool shouldShakeDown = false;  //same but for the downShake    -    Erik

    //public static float shakeTime;  //UnImportant TestVariable    -    Erik


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
        Vector3 shakePos = transform.localPosition;  //"shakePos" is now equal to the local position of this object    -    Erik

        if (shouldShakeLeft == true)  //if this variable is true (if we activate this variable) then...    -    Erik
        {
            time += new Vector2(Time.deltaTime, Time.deltaTime) * leftFrequency;  //the vectorposition determining the y and x axis...    -    Erik
                                                                                  //...will be added to the amount of time passed * variable for frequency    -    Erik
            shakePos = new Vector3(Mathf.Sin(time.x), Mathf.Sin(time.y), -30) * leftAmplitude;  
                                                                                                //shakePos is equal to the vector that...    -    Erik
                                                                                                //...multiplies the sinus curve to the "time" vector    -    Erik
            transform.localPosition = shakePos;  
                                //the localposition of the object is set to equal the local variable "shakePos"..    -    Erik
                               //..which will trigger the camera to move    -    Erik

        }

        /*
        if(shouldShakeLeft == false)
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
        */

        #endregion

        #region rightShake

        if (shouldShakeRight)  //if this variable is true (if we activate this variable) then...    -    Erik
        {
            time += new Vector2(Time.deltaTime, Time.deltaTime) * rightFrequency;  //the vectorposition determining the y and x axis...    -    Erik
                                                                                   //...will be added to the amount of time passed * variable for frequency    -    Erik

            shakePos = new Vector3(-Mathf.Sin(time.x), -Mathf.Sin(time.y), -30) * rightAmplitude;
                                                                                                //shakePos is equal to the vector that...    -    Erik
                                                                                                //...multiplies the negative sinus curve to the "time" vector    -    Erik
            transform.localPosition = shakePos;  
                            //the localposition of the object is set to equal the local variable "shakePos"..    -    Erik
                            //..which will trigger the camera to move    -    Erik
        }

        /*
        if (shouldShakeRight == false)
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
        */

        #endregion

        #region downShake

        if (shouldShakeDown)  //if this variable is true (if we activate this variable) then...    -    Erik
        {
            time += new Vector2(Time.deltaTime, Time.deltaTime) * downFrequency;  //the vectorposition determining the y and x axis...    -    Erik
                                                                                  //...will be added to the amount of time passed * variable for frequency    -    Erik

            shakePos = new Vector3(Mathf.Sin(time.x), Mathf.Sin(time.y), -30) * downAmplitude;
                                                                                                //shakePos is equal to the vector that...    -    Erik
                                                                                                //...multiplies the sinus curve to the "time" vector    -    Erik
            transform.localPosition = shakePos;
            //the localposition of the object is set to equal the local variable "shakePos"..    -    Erik
            //..which will trigger the camera to move    -    Erik
        }

        #endregion


        if (shouldShakeDown == false && shouldShakeRight == false && shouldShakeLeft == false)  //If the camera isn't shaking then...    -    Erik
        {
            transform.localPosition = new Vector3(0, 0, 0);  //reset the position of the camera    -    Erik
            time = new Vector2(0, 0);  //reset the "time" vector which in turns resets the "time" elapsed on the Sin/-Sin curves    -    Erik
        }
        

        




    }
}
