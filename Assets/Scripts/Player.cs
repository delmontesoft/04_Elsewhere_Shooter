using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] [Tooltip("In ms^-1")] float movementSpeed = 20f;
    [SerializeField] [Tooltip("In m")] float xRange = 6f;
    [SerializeField] [Tooltip("In m")] float yRange = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RespondToHorizontalInput();
        RespondToVerticalInput();
    }

    private void RespondToHorizontalInput()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * movementSpeed * Time.deltaTime;

        float xRawPos = transform.localPosition.x + xOffset;
        float xClampedPos = Mathf.Clamp(xRawPos, -xRange, xRange);

        transform.localPosition = new Vector3(xClampedPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void RespondToVerticalInput()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * movementSpeed * Time.deltaTime;

        float yRawPos = transform.localPosition.y + yOffset;
        float yClampedPos = Mathf.Clamp(yRawPos, -yRange, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, yClampedPos, transform.localPosition.z);
    }
}
