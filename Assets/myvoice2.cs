using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class myvoice2 : MonoBehaviour
{

    
    protected string word = "right";
   

    protected PhraseRecognizer recognizer;
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;

    // keyword array
    public string[] keywords = new string[] { "begin" };
   



    // Use this for initialization
    void Start()
    {

       

        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    private void Update()
    {
      
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;

        if (word == "begin")
        {



            SceneManager.LoadScene("Codeman");



        }

    }
   
               
       
    

}



