using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
        transform.LookAt(player.transform);


        transform.position = player.transform.position + new Vector3(0f, 15f, -10f);
    }
}
