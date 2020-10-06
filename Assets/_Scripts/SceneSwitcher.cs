using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    [SerializeField] bool debuggingMode = false;

    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("Start Scene");
    }

    // Update is called once per frame
    void Update()
    {
        if (debuggingMode)
        {
            //This was essentially made to ensure scene switching worked properly
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneLoad("Start Scene");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneLoad("Play Scene");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneLoad("End Scene");
            }
        }
    }

    void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
