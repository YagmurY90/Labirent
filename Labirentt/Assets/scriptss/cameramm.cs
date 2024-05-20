using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cameramm : MonoBehaviour
{
 
    private float xRotation = 0.0f;
    public float mouseSensivity = 100f;
    public GameObject oyuncu;

  

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        oyuncu.transform.Rotate(Vector3.up * mouseX);

      
    }
    
}

