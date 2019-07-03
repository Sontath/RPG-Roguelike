using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public bool IsFrozen = false;
    public bool IsKeyboard = true;
    private bool isPausing;

    public bool GetAttackBtn()
    {
        bool IsAttack = false;

        // Get inputs
        IsAttack = IsAttack || Input.GetButton("Fire");
        IsAttack = IsAttack || Input.GetButton("RightBumper");

        // If we are frozen return false
        return (IsAttack && !IsFrozen);
    }

    public float GetMovementHorizontal()
    {
        float horizontal = 0f;

        horizontal = Input.GetAxisRaw("Horizontal");

        // Get secondary input
        if (horizontal == 0f)
        {
            horizontal = Input.GetAxisRaw("LeftJoyHorz");
            if (horizontal != 0)
            {
                IsKeyboard = false;
            }
        }
        else
        {
            IsKeyboard = true;
        }

        // If we are frozen then do not output anything;
        if (IsFrozen)
        {
            horizontal = 0f;
        }

        return horizontal;
    }

    public float GetMovementVertical()
    {
        float vertical = 0f;

        vertical = Input.GetAxisRaw("Vertical");

        // get secondary inputs
        if (vertical == 0f)
        {
            vertical = Input.GetAxisRaw("LeftJoyVert");
            if (vertical != 0f)
            {
                IsKeyboard = false;
            }
        }
        else
        {
            IsKeyboard = true;
        }

        // If we are frozen then do not output anything
        if (IsFrozen)
        {
            vertical = 0f;
        }

        return vertical;
    }

    public float GetAimHorizontal()
    {
        float horizontal = 0f;

        horizontal = Input.GetAxisRaw("RightJoyHorz");
        
        // If we are frozen then do not output anything
        if (IsFrozen)
        {
            horizontal = 0f;
        }

        return horizontal;
    }

    public float GetAimVertical()
    {
        float vertical = 0f;

        vertical = Input.GetAxisRaw("RightJoyVert");

        // If we are frozen then do not output anything
        if (IsFrozen)
        {
            vertical = 0f;
        }

        return vertical;
    }

    public bool GetPause()
    {
        bool pause = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = true;
        }

        if (Input.GetAxis("StartBtn") != 0)
        {
            if (isPausing == false)
            {
                pause = true;
            }
            isPausing = true;
            Debug.Log("Start");
        }

        if (pause)
        {
            Debug.Log("Frozen: " + IsFrozen);
            IsFrozen = !IsFrozen;
        }

        return pause;
    }
}
