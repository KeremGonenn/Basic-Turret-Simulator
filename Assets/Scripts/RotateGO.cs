using UnityEngine;
using UnityEngine.UI;

public class RotateGO : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public float rotationSpeed = 10f;
    public float maxRotationAngle = 30f;
    public float rotationDecay = 0.9f;
    float currentRotationSpeed = 0f;
    float targetRotationAngle = 0f;

    void Start()
    {
        leftButton.onClick.AddListener(TurnLeft);
        rightButton.onClick.AddListener(TurnRight);
    }

    public void TurnLeft()
    {
        targetRotationAngle = Mathf.Clamp(targetRotationAngle - maxRotationAngle, -maxRotationAngle, maxRotationAngle);
        currentRotationSpeed = -rotationSpeed;
    }
    
    public void TurnRight()
    {
        targetRotationAngle = Mathf.Clamp(targetRotationAngle + maxRotationAngle, -maxRotationAngle, maxRotationAngle);
        currentRotationSpeed = rotationSpeed;
    }
    void Update()
    {
        targetRotationAngle = Mathf.Clamp(targetRotationAngle, -maxRotationAngle, maxRotationAngle);
        float currentAngle = transform.localEulerAngles.y;
        if (currentAngle > 180f) currentAngle -= 360f;
        float deltaAngle = targetRotationAngle - currentAngle;
        if (Mathf.Abs(deltaAngle) > 180f) deltaAngle -= Mathf.Sign(deltaAngle) * 360f;
        float acceleration = Mathf.Sign(deltaAngle) * Mathf.Pow(deltaAngle / maxRotationAngle, 2f);
        currentRotationSpeed += acceleration * Time.deltaTime;
        currentRotationSpeed *= Mathf.Pow(rotationDecay, Time.deltaTime);
        transform.localEulerAngles += new Vector3(0f, currentRotationSpeed * Time.deltaTime, 0f);
    }
}
