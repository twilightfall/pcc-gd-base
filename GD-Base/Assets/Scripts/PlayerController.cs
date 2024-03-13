using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{
    float horizontal, vertical;

    [SerializeField]
    float moveSpd;

    bool isGrounded;

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGravity();
        
        MovePlayer();

    }

    void MovePlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        controller.Move(movement * moveSpd * Time.deltaTime);
    }

    void CheckGravity()
    {
        if (!isGrounded)
        {
            Vector3 movement = new Vector3(0f, Physics.gravity.y, 0f);
            controller.Move(movement * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
