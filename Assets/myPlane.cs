using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlane : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 18.0f;
    public Vector3 moveVector = new Vector3(0, 0, -1);



    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(moveVector * moveSpeed * Time.deltaTime);



    }
}
