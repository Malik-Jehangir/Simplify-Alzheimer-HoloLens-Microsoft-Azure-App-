using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly2 : MonoBehaviour
{
    Vector3 originalPos;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;

    private float timer = 0f;
    private int delay;

    void Start()
    {
        delay = 50;

    }

    // Update is called once per frame
    void Update()
    {

        //Increase the value of 'timer' by deltaTime:
        timer += Time.deltaTime;

        //Verify if the timer is greater than delay:
        if (timer > delay)
        {

            //If so, proceed to translate the object:
            gameObject1.transform.position = new Vector3(1.95f, -17.52f, -5.84f);
            gameObject2.transform.position = new Vector3(1.950001f, -29.9f, -5.84f);
            gameObject3.transform.position = new Vector3(1.950001f, -25.7f, -5.42f);
            gameObject4.transform.position = new Vector3(1.950001f, -22.5f, -7.52f);



            timer = 0f;


        }


    }
}
