using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjSpin : MonoBehaviour
{
    //Pretty simple: you attach this to something and it spins
    [SerializeField] float speed;

    void Update()
    {
        transform.Rotate(-(Vector3.up * (speed * Time.deltaTime)));
    }
}
