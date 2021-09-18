using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-1, 0, 0);
        //rb = this.gameObject.GetComponent<Rigidbody>();
        /*GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
        gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>(); // Add the rigidbody.*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(-1, 0, Input.acceleration.y);
        Debug.Log(Input.acceleration.x + " " + Input.acceleration.y + " " + Input.acceleration.z);
        rb.velocity = movement * 5;
    }

    string myLog;
    Queue myLogQueue = new Queue();


    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        myLog = logString;
        string newString = "\n [" + type + "] : " + myLog;
        myLogQueue.Enqueue(newString);
        if (type == LogType.Exception)
        {
            newString = "\n" + stackTrace;
            myLogQueue.Enqueue(newString);
        }
        myLog = string.Empty;
        foreach (string mylog in myLogQueue)
        {
            myLog += mylog;
        }
        if (myLogQueue.Count > 5)
        {
            myLogQueue = new Queue();
        }

    }

    void OnGUI()
    {
        GUILayout.Label(myLog);
    }
}
