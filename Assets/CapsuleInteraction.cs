using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Windows.Speech;

public class CapsuleInteraction : MonoBehaviour
{

   
    public GameObject TextgameObject;
    private int error_count = 0;
    public AudioClip InstructClip;
    public AudioSource InstructSource;


    // Use this for initialization
    void Start()
    {
        Debug.ClearDeveloperConsole(); ///clear console


    }


    //void Start()
    //    {
    //   json2 = @"{
    //  'PartitionKey':'" + UnityEngine.Random.Range(1, 255).ToString() + @"',
    //  'RowKey':'" + glyphs[UnityEngine.Random.Range(0, glyphs.Length)] + @"',
    //  'Risk':'10.253',
    //  'Errors':'15',
    //  'PatientName':'Lisa',
    //  'TestDuration':'1m',
    //  'TestTakenOn':'" + System.DateTime.Now.ToString("dddd, dd MMMM yyyy") + @"', 
    //  'Uploaded':'yes'
    //   }";

    //    doPost2();
    //    }

    // Update is called once per frame
    void Update()
    {

       
    }

    public void PointerEnter()
    {
        Debug.Log("Look away sir !");
        InstructSource.clip = InstructClip;
        InstructSource.Play();

        //doPost();


        //gameObject1.SetActive(false);
        //gameObject2.SetActive(false);


        error_count = int.Parse(TextgameObject.GetComponent<UnityEngine.UI.Text>().text);

        error_count = error_count + 1;

        TextgameObject.GetComponent<UnityEngine.UI.Text>().text = error_count.ToString();



        Debug.Log("The count: "+ TextgameObject.GetComponent<UnityEngine.UI.Text>().text); //shows initial results
    }


   


}
