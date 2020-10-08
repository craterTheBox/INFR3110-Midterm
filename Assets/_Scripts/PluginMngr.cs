using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PluginMngr : MonoBehaviour
{
    const string DLL_NAME = "Midterm-DLL";

    //Methods
    [DllImport(DLL_NAME)]
    private static extern void ResetLogger();

    //Setters
    [DllImport(DLL_NAME)]
    private static extern void SaveCheckpointTime(float RTBC);

    //Getters
    [DllImport(DLL_NAME)]
    private static extern float GetTotalTime();
    [DllImport(DLL_NAME)]
    private static extern float GetCheckpointTime(int index);
    [DllImport(DLL_NAME)]
    private static extern int GetNumCheckpoints();

    float lastTime = 0.0f;

    //Functions
    public void _ResetLogger()
    {
        ResetLogger();
    }

    public void _SaveCheckpointTime(float checkpointTime)
    {
        SaveCheckpointTime(checkpointTime);
    }

    public float _LoadTotalTime()
    {
        return GetTotalTime();
    }

    public float _LoadTime(int index)
    {
        if (index >= GetNumCheckpoints())
        {
            return -1.0f;
        }
        else
        {
            return GetCheckpointTime(index);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Testing Functions
        if (Input.GetKeyDown(KeyCode.Return))
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;
            lastTime = currentTime;

            _SaveCheckpointTime(checkpointTime);
        }
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                UnityEngine.Debug.Log(_LoadTime(i));
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            UnityEngine.Debug.Log(_LoadTotalTime());
        }
        //End of Testing Functions (spoilers: they work)*/



    }

    void OnDestroy()
    {
        _ResetLogger();
    }
}
