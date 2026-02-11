using UnityEngine;

public class LanternMove : MonoBehaviour
{
    public float moveSpeed = 2f;   
    public float moveTime = 3f;     

    private bool isMoving = false;
    private float timer = 0f;

    void Update()
    {
        if (isMoving)
        {
            // Move upward
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Count time
            timer += Time.deltaTime;

            // Stop after moveTime seconds
            if (timer >= moveTime)
            {
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true;
            timer = 0f;
        }
    }
}