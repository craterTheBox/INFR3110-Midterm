using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

    //public Transform checkpoint;
    GameObject player;

    public PluginMngr plgnmngr;

    public CheckpointManager checkmanager;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    private void OnTriggerEnter(Collider _player)
    {
        //If the player collides with this, it sets the new checkpoint
        if (_player.gameObject.tag == "Player")
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            checkmanager.lastCheckpoint = transform;

            plgnmngr.CheckpointReached();
        }
    }
}
