using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rester3 : MonoBehaviour
{
    Vector3 originalPos;
    public GameObject gameObject1;

    public AudioClip InstructClip;
    public AudioSource InstructSource;


    private float timer = 0f;
    private int delay;

    void Start()
    {
        delay = 30;

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
            gameObject1.transform.position = new Vector3(-63f, 22f, 418.3f);

            InstructSource.clip = InstructClip;
            InstructSource.Play();


            timer = 0f;


        }


    }
}
