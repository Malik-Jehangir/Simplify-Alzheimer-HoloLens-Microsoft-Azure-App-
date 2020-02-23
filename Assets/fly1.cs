using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly1 : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Vector3 moveVector = new Vector3(0, 1, 0);



    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(moveVector * moveSpeed * Time.deltaTime);



    }

  

}

