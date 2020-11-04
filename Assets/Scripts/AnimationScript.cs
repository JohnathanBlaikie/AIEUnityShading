using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour
{
    public Vector2 movement;
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

