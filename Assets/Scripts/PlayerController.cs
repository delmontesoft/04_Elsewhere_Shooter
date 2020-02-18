using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] [Tooltip("In ms^-1")] float movementSpeed = 25f;
    [SerializeField] [Tooltip("In m")] float xRange = 12f;
    [SerializeField] [Tooltip("In m")] float yRange = 8f;
    [SerializeField] GameObject[] guns;

    [Header("Screen Position Based")]
    [SerializeField] float positionPitchFactor = -1.25f;
    [SerializeField] float positionYawFactor = 1.5f;

    [Header("Control Throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    private float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * movementSpeed * Time.deltaTime;
        float yOffset = yThrow * movementSpeed * Time.deltaTime;

        float xRawPos = transform.localPosition.x + xOffset;
        float yRawPos = transform.localPosition.y + yOffset;

        float xClampedPos = Mathf.Clamp(xRawPos, -xRange, xRange);
        float yClampedPos = Mathf.Clamp(yRawPos, -yRange, yRange);

        transform.localPosition = new Vector3(xClampedPos, yClampedPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float positionPitch = transform.localPosition.y * positionPitchFactor;
        float controlPitch = yThrow * controlPitchFactor;
        float pitch =  positionPitch + controlPitch;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeActivateGuns();
        }
    }

    private void DeActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    void OnPlayerDeath()        // called by string reference (in case of renaming)
    {
        isControlEnabled = false;

        // do something else when player dies?
    }
}
