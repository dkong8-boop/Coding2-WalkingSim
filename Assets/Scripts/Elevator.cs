using System.Collections;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float waitTime = 1f;
    public float moveSpeed = 2f;
    public float moveTime = 3f;

    bool moving = false;
    bool used = false;     
    Transform platform;

    void Awake()
    {
        platform = transform.parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if (used) return;

        if (moving) return;
        if (!other.CompareTag("Player")) return;

        StartCoroutine(Elevator(other.gameObject));
    }

    IEnumerator Elevator(GameObject player)
    {
        used = true;         
        moving = true;

        yield return new WaitForSeconds(waitTime);

        // lock player
        PlayerController pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.canMove = false;

        float t = 0f;
        while (t < moveTime)
        {
            Vector3 step = Vector3.up * moveSpeed * Time.deltaTime;

            // move platform
            platform.position += step;

            // move player with platform
            CharacterController cc = player.GetComponent<CharacterController>();
            if (cc != null)
                cc.Move(step);
            else
                player.transform.position += step;

            t += Time.deltaTime;
            yield return null;
        }

        if (pc != null) pc.canMove = true;

        moving = false;
    }
}