using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFirePoint : MonoBehaviour
{
    private static float offset = 0;
    [SerializeField]
    private InputHandler input;
    private Transform weaponUser;
    private Vector3 difference;
    private float rotZ;

    private void Start()
    {
        weaponUser = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!input.IsFrozen)
        {
            if (input.IsKeyboard)
            {
                difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weaponUser.position;
                rotZ = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg);
            }
            else
            {
                float horizontalAngle = input.GetAimHorizontal();
                float verticalAngle = input.GetAimVertical();
                if (Mathf.Abs(horizontalAngle) > 0 && Mathf.Abs(verticalAngle) > 0)
                    rotZ = ((Mathf.Atan2(verticalAngle, horizontalAngle) * Mathf.Rad2Deg)) * -1;
            }


            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
    }
}
