using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour
{
    public float speed, acceleration, jumpHeight;
    public Vector2 movement;
    public enum MOVEMENTSTATE { wForward, wBackward, wLeft, wRight, jump }
    MOVEMENTSTATE moveState;
    [Range (-1f, 1f)] float leftRightBalance, currentLRB;
    [Range (-1f, 1f)] float forwardBackwardBalance, currentFBB;

    Rigidbody modelRB;
    Animator modelAnim;

    public Slider animScrollX;
    public Slider animScrollY;
    public Button startDissolveButton, resetButton;

    // Start is called before the first frame update
    void Start()
    {
        animScrollX.interactable = true;
        animScrollY.interactable = true;
        startDissolveButton.interactable = true;
        resetButton.interactable = true;
        modelAnim = GetComponent<Animator>();
        modelRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        leftRightBalance = animScrollX.value;
        forwardBackwardBalance = animScrollY.value;

        //if (forwardBackwardBalance > .25)
        //{
        //    currentFBB += forwardBackwardBalance * acceleration * Time.deltaTime;
        //}
        //else if (forwardBackwardBalance < -.25f)
        //{
        //    currentFBB -= forwardBackwardBalance * acceleration * Time.deltaTime;
        //}
        //else
        //{
        //    if(currentFBB > forwardBackwardBalance)
        //    {
        //        currentFBB -= forwardBackwardBalance * acceleration * Time.deltaTime;
        //    }
        //    else if (currentFBB < forwardBackwardBalance)
        //    {
        //        currentFBB += forwardBackwardBalance * acceleration * Time.deltaTime;
        //    }
        //}
        //if (leftRightBalance > .25f)
        //{
        //    currentLRB += leftRightBalance * acceleration * Time.deltaTime;

        //}
        //else if (leftRightBalance < -.25f)
        //{
        //    currentLRB -= leftRightBalance * acceleration * Time.deltaTime;
        //}
        //else
        //{
        //    if (currentLRB > leftRightBalance)
        //    {
        //        currentLRB -= leftRightBalance * acceleration * Time.deltaTime;
        //    }
        //    else if (currentLRB < leftRightBalance)
        //    {
        //        currentLRB += leftRightBalance * acceleration * Time.deltaTime;
        //    }
        //}

        movement = new Vector2(leftRightBalance, forwardBackwardBalance);
        //movement.Normalize();

        UpdateAnimation(movement);
    }

    void UpdateAnimation(Vector2 moveDirection)
    {
        modelAnim.SetFloat("Y", moveDirection.y);
        modelAnim.SetFloat("X", moveDirection.x);
    }
}

