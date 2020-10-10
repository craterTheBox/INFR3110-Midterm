using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVariables : MonoBehaviour
{

    public PluginMngr plgnmngr;

    public Text timeText;
    float time, startTime;

    public Text checkpointText;
    public GameObject player;
    public GameObject checkpointmanager;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeText != null)
        {
            time = Time.time - startTime; //Since start runs before it shows up

            //Continually updates the time on screen
            timeText.text = System.Math.Round(time, 2).ToString();
        }
    }
}
