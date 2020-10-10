using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    
    public List<Checkpoints> checkpoints = new List<Checkpoints>();
    public GameObject player;
    public Transform lastCheckpoint;
    
    void Start()
    {
        lastCheckpoint = checkpoints[0].transform;
    }

    public void Respawn()
    {
        Debug.Log("Respawn Called");
        player.transform.position = lastCheckpoint.transform.position;
        player.transform.rotation = lastCheckpoint.transform.rotation;
    }
}
