using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum Direction
{
    North,
    East,
    South,
    West,
}
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Animator walkAnimator;
    Direction walkDirection = Direction.South;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 inputVector = new Vector3(inputX, inputY, 0) * moveSpeed * Time.deltaTime;

        //Same as transform.position = transform.position + inputVector;
        transform.position += inputVector;
        
        
        PickanimationState(inputX, inputY);

    }
    void PickanimationState(float inputX, float inputY)
    {
        
        if (inputX > 0)
        {
            walkDirection = Direction.East;
        }
        else if (inputX < 0)
        {
            walkDirection = Direction.West;
        }
        else if (inputY > 0)
        {
            walkDirection = Direction.North;
        }
        else if (inputY < 0)
        {
            walkDirection = Direction.West;
        }
        if (inputX == 0 && inputY == 0)
            { walkAnimator.speed = 0;
        }
        else
        {
            walkAnimator.speed = moveSpeed / 4;
        }

        walkAnimator.SetInteger("WalkDirection", (int)walkDirection);
    }
}
