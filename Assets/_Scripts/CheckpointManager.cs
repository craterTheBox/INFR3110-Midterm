using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    
    public List<Checkpoints> checkpoints = new List<Checkpoints>();
    
    public Transform lastCheckpoint;
    

    // Start is called before the first frame update
    void Start()
    {
        lastCheckpoint = checkpoints[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
