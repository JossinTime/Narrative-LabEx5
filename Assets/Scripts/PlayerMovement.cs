using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 inputVector = new Vector3(inputX, inputY, 0) * moveSpeed * Time.deltaTime;

        //Same as transform.position = transform.position + inputVector;
        transform.position += inputVector;

        
    }
}
