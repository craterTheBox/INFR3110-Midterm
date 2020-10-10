using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTransition : MonoBehaviour
{
    public PluginMngr plgnmngr;
    public SceneSwitcher sceneswitch;

    public Text prompt;

    private void OnTriggerStay(Collider _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            plgnmngr.CheckpointReached();
            prompt.text = "Press E to end";

            //UnityEngine.Debug.Log("End Collision Stay - press E");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.Confined;
                sceneswitch.SceneLoad("End Scene");
            }
        }
    }
}
