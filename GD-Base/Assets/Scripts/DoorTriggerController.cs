using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    [SerializeField]
    private Animator doorAnimator;

    [SerializeField]
    private Animator cubeAnimator;

    private void Start()
    {
        cubeAnimator.Play("CubeRotationAnim");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorAnimator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorAnimator.SetBool("isOpen", false);
        }
    }
}
