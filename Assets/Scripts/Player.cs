using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] [Tooltip("In ms^-1")] float movementSpeed = 25f;
    [SerializeField] [Tooltip("In m")] float xRange = 12f;
    [SerializeField] [Tooltip("In m")] float yRange = 8f;

    [SerializeField] float positionPitchFactor = -1.25f;
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float positionYawFactor = 1.5f;

    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Player triggered something!");
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
}
