using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInitializer : MonoBehaviour
{
    public GameObject objectToCreate;

    private void Start()
    {


        Destroy(gameObject);
    }
}
