using UnityEngine;

public class Train2Move : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 10f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move along the X axis
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}