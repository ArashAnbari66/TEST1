using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Vector3 camera;
    public Transform player;
    [Range(0.01f, 1f)]
    public float Smooth = 0.5f;
    public bool lookAtPlayer = false;
    
    void Start()
    {
        camera = transform.position - player.position; 
    }

    
    void LateUpdate()
    {
        Vector3 newpos = player.position + camera;
        transform.position = Vector3.Slerp(transform.position, newpos, Smooth);
        if (lookAtPlayer)
            transform.LookAt(player);
    }
}
