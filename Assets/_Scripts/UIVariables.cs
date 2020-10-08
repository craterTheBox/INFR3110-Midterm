using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVariables : MonoBehaviour
{

    PluginMngr plgnmngr;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = plgnmngr._LoadTotalTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
