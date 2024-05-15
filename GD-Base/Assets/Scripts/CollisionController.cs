using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitter = collision.collider.gameObject;
        print(hitter.name);
        //if (hitter.CompareTag("Item"))
        //{
        //    //hitter.GetComponent<Rigidbody>().
        //    //    AddForce(new Vector3(0f, 10f, 0f), ForceMode.Impulse);
        //    Destroy(hitter);
        //}

        if (hitter.CompareTag("Player"))
        {
            print(hitter.tag);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}
