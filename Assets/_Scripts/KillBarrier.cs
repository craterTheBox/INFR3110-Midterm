using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBarrier : MonoBehaviour
{
    public GameObject player;

    public CheckpointManager checkmanager;

    private void OnTriggerEnter(Collider _player)
    {
        if (_player.gameObject.tag == "Player")
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }

    void OnTriggerStay(Collider _player)
    {
        //If the player collides with this, it sets the new checkpoint
        if (_player.gameObject.tag == "Player")
            checkmanager.Respawn();
    }
}
