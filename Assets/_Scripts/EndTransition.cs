using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTransition : MonoBehaviour
{
    public GameObject switcher;
    public SceneSwitcher sceneswitch;

    // Start is called before the first frame update
    void Start()
    {
        sceneswitch = switcher.GetComponent<SceneSwitcher>();
    }

    private void OnTriggerStay(Collider _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            //UnityEngine.Debug.Log("End Collision Stay - press E");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.Confined;
                sceneswitch.SceneLoad("End Scene");
            }
        }
    }
}
