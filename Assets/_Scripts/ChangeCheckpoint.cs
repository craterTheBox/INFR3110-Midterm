using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckpoint : MonoBehaviour
{
    [SerializeField] GameObject checkpoint;

    private void OnTriggerEnter(Collider _player)
    {
        if (_player.gameObject.tag == "Player")
        {
            Destroy(checkpoint);
        }
        Destroy(gameObject);
    }
}
