using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public PluginMngr plgnmngr;

    public Text totalTime;
    public List<Text> checkpoints = new List<Text>();

    // Start is called before the first frame update
    void Start()
    {
        totalTime.text = System.Math.Round(plgnmngr._LoadTotalTime(), 2).ToString();

        for (int i = 0; i < 5; i++)
        {
            checkpoints[i].text = System.Math.Round(plgnmngr._LoadTime(i), 2).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
