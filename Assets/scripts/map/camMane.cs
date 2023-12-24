using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMane : MonoBehaviour
{
    

    [SerializeField] float panSpeed = 5.0f;
    

    void Update()
    {
        // ç∂âEÇÃà⁄ìÆ
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 pan = new Vector3(horizontalInput, verticalInput, 0) * panSpeed * Time.deltaTime;
        transform.Translate(pan);

       
    }
}
