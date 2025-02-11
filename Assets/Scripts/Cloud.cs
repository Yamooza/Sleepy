using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 1.0f;
    public float movementAmount = 0.5f;

    private Vector3 originalPosition;
    private float direction = 1.0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float newY = originalPosition.y + Mathf.Sin(Time.time * speed) * movementAmount;

        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }
}