using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

    //public Transform checkpoint;
    GameObject player;

    PluginMngr DLL;

    public CheckpointManager checkmanager;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //checkmanager.checkpoints.Add(this);
    }

    private void OnTriggerEnter(Collider _player)
    {
        //If the player collides with this, it sets the new checkpoint
        if (_player.gameObject.tag == "Player")
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();

            //UnityEngine.Debug.Log("PLAYER COLLIDED WITH A CHECKPOINT AT" + checkmanager.lastCheckpoint.position);

            checkmanager.lastCheckpoint = transform;
        }
    }
}
