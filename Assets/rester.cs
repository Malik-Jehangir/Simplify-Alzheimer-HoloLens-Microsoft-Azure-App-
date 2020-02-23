using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rester : MonoBehaviour
{
    Vector3 originalPos;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public GameObject gameObject5;
    public GameObject gameObject6;
    public GameObject gameObject7;
    public GameObject gameObject8;
    public GameObject gameObject9;
    private float timer=0f;
    private int delay;

    void Start()
    {
        delay = 20;

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
            gameObject1.transform.position = new Vector3(13.5f, -0.35f, 1.66f);
            gameObject2.transform.position = new Vector3(17.68f, -0.35f, 3.02f);
            gameObject3.transform.position = new Vector3(17.82f, -0.35f, 0.8800001f);
            gameObject4.transform.position = new Vector3(20.94f, -0.35f, 4.72f);
            gameObject5.transform.position = new Vector3(23.91f, -0.35f, 3.441f);
            gameObject6.transform.position = new Vector3(29.17f, -0.35f, 0.88f);
            gameObject7.transform.position = new Vector3(34.16f, -0.35f, 3.441f);
            gameObject8.transform.position = new Vector3(23.57f, -0.35f, 0.88f);
            gameObject9.transform.position = new Vector3(28.27f, -0.35f, 3.441f);


            timer = 0f;


        }

   
}
}
