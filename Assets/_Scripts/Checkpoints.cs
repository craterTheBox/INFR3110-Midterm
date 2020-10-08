using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#include "PluginMngr.cs"

public class Checkpoints : MonoBehaviour
{

    public Transform checkpoint;
    GameObject player;

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider _player)
    {
        //If the player collides with this, it sets the new checkpoint
        if (_player.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("PLAYER COLLIDED WITH KILL ZONE");
            
            player.transform.position = checkpoint.position + Vector3.up * 5.0f;
            player.transform.rotation = checkpoint.rotation;
        }
    }
}
