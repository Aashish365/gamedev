using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRotation : MonoBehaviour
{
    public float rotationSpeed = 5f; // Adjust the speed as needed

    void Update()
    {
        // Rotate the object slowly around its up axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
