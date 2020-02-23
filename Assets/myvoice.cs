using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class myvoice : MonoBehaviour
{

    bool MyFunctionCalled = false;
    public GameObject TextgameObject;
    protected string word = "right";
    public AudioClip InstructClip2;
    public AudioSource InstructSource2;

    private string json2 = "";
    protected float Animation;
    private string json = ""; //here in this you need to make 100,20,55 as the variables so to request different values at everytime


    // Use this for initialization
    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789"; //add the characters you want


    protected PhraseRecognizer recognizer;
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;

    // keyword array
    public string[] keywords = new string[] { "done" };
    private string newJson = "";
    List<string> objects = new List<string>();
    private int printMe = 0;
    private string mynewVal;
    public System.Diagnostics.Stopwatch zeit = new System.Diagnostics.Stopwatch();
    private string myTime;
    private string myTime2;
    public GameObject txt;



    // Use this for initialization
    void Start()
    {

        zeit.Start();

        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    private void Update()
    {
        myTime2 = zeit.Elapsed.Minutes.ToString() + "m " + zeit.Elapsed.Seconds.ToString() + "s";

        txt.GetComponent<UnityEngine.TextMesh>().text = "Test time: "+myTime2 + "\nErrors made: " + TextgameObject.GetComponent<UnityEngine.UI.Text>().text + "\nPlease say DONE to finish";
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        Debug.Log("You said: " + word);

        if (word == "done")
        {

            InstructSource2.clip = InstructClip2;
            InstructSource2.Play();

            json = @"{
		  'Inputs': {
          'input1': {
          'ColumnNames': [
          'error_count',
          'heart_beat',
          'age'
          ],
          'Values': [
          [
          '" + TextgameObject.GetComponent<UnityEngine.UI.Text>().text + @"', 
          '50',
          '45'
          ],
          [
          '0',
          '0',
          '0'
          ]
          ]
          }
          },
         'GlobalParameters': {}}";

            
            doPost();

            

            




        }

    }
        void doPost()
        {
            string URL = "https://ussouthcentral.services.azureml.net/workspaces/78cdf231c2a349bdbff24b561c9f4055/services/ad41943fe1494cf0b30b52e15395d852/execute?api-version=2.0&details=true";
            string myAccessToken = "Gvzezbov0SN9YXXnX6rsPxKpb3yv0nHZcYkQQJ5HGoHxhHWI9s8/dfBiDaifwt4zMzIXJ9yltbpXyU6Fatju/Q==";


            //Auth token for http request
            //Our custom Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            //Encode the access and secret keys
            //Add the custom headers
            headers.Add("Authorization", "Bearer " + myAccessToken);
            headers.Add("Content-Type", "application/json");
            //headers.Add("Content-Length", json.Length.ToString());
            //Replace single ' for double " 
            //Encode the JSON string into a bytes
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
            //Now we call a new WWW request
            WWW www = new WWW(URL, postData, headers);
            //And we start a new co routines in Unity and wait for the response.
            StartCoroutine(WaitForRequest(www));


        }
        //Wait for the www Request
        IEnumerator WaitForRequest(WWW www)
        {

            yield return www;
            if (www.error == null)
            {
                Debug.Log("Hello tomorrow");
                //Print server response
                Debug.Log(www.text);


                //Regex instead of deserilaization
                var reg = new Regex("\".*?\"");
                var matches = reg.Matches(www.text);
                foreach (var item in matches)
                {
                    objects.Add(item.ToString());
                }

                mynewVal = objects[10].Trim('"');
                Debug.Log("The only value we need: " + mynewVal.ToString());
            myTime = zeit.Elapsed.Minutes.ToString() + "m " + zeit.Elapsed.Seconds.ToString() + "s";

            //send data to the Azure tables
            json2 = @"{
                  'PartitionKey':'" + UnityEngine.Random.Range(1, 255).ToString() + @"',
                  'RowKey':'" + glyphs[UnityEngine.Random.Range(0, glyphs.Length)] + @"',
                  'Risk':'" + mynewVal + @"',
                  'Errors':'" + TextgameObject.GetComponent<UnityEngine.UI.Text>().text + @"',
                  'PatientName':'Lisa',
                  'TestDuration':'" + myTime + @"',
                  'TestTakenOn':'" + System.DateTime.Now.ToString("dddd, dd MMMM yyyy") + @"', 
                  'Uploaded':'yes'
                   }";

            doPost2();





        }
            else
            {
                Debug.Log("Hello");
                //Something goes wrong, print the error response
                Debug.Log(www.error);
            }


        }



        void doPost2()
        {


        zeit.Stop();
        //get the time of the timer

        Debug.Log("Minutes: " + zeit.Elapsed.Minutes.ToString() + "\nSeconds: " + zeit.Elapsed.Seconds.ToString());



        string URL = "https://alzheimersapp.table.core.windows.net/alzheimersBackendNew?sv=2019-02-02&ss=bfqt&srt=sco&sp=rwdlacup&se=2021-12-30T21:47:11Z&st=2019-11-26T13:47:11Z&spr=https&sig=LOBsYvqL%2BBj5sEQ3wYWnwEdJJwTG6vfWDAluauCGLOc%3D";


            //Auth token for http request
            //Our custom Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            //Encode the access and secret keys
            //Add the custom headers
            headers.Add("Content-Type", "application/json");
            //headers.Add("Content-Length", json.Length.ToString());
            //Replace single ' for double " 
            //Encode the JSON string into a bytes
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(json2);
            //Now we call a new WWW request
            WWW www = new WWW(URL, postData, headers);
            //And we start a new co routines in Unity and wait for the response.
            StartCoroutine(WaitForRequest2(www));


        }
        //Wait for the www Request
        IEnumerator WaitForRequest2(WWW www)
        {
            yield return www;
            if (www.error == null)
            {
                Debug.Log("Hello new response");
                //Print server response
                Debug.Log(www.text);

            if (www.text != null)
            {
                SceneManager.LoadScene("Final");
            }


        }
        else
            {
                Debug.Log("Hello no response");
                //Something goes wrong, print the error response
                Debug.Log(www.error);
            }


        }

    }



