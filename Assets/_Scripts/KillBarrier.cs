using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBarrier : MonoBehaviour
{

    public GameObject player;

    public CheckpointManager checkmanager;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider _player)
    {
        //If the player collides with this, it sets the new checkpoint
        if (_player.gameObject.tag == "Player")
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();

            UnityEngine.Debug.Log("PLAYER COLLIDED WITH KILL ZONE");

            player.transform.position = checkmanager.lastCheckpoint.transform.position;
            UnityEngine.Debug.Log(">Checkpoint Coordinates: " + checkmanager.lastCheckpoint.position);
        }
    }
}
