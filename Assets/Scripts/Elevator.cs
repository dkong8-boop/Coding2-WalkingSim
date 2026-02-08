using System.Collections;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Transform platformMove;

    public float waitTime = 1f;
    public float moveSpeed = 2f;
    public float moveTime = 3f;

    bool moving = false;
    Rigidbody platformRb;

    void Awake()
    {
        if (platformMove == null && transform.parent != null)
            platformMove = transform.parent;

        if (platformMove != null)
            platformRb = platformMove.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (moving) return;
        if (!other.CompareTag("Player")) return;

        StartCoroutine(Elevator(other.gameObject));
    }

    IEnumerator Elevator(GameObject player)
    {
        moving = true;
        Debug.Log("Elevator start");

        yield return new WaitForSeconds(waitTime);

        // lock player movement
        PlayerController pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.canMove = false;

        // parent player to platform
        player.transform.SetParent(platformMove);

        float t = 0f;
        while (t < moveTime)
        {
            Vector3 step = Vector3.up * moveSpeed * Time.deltaTime;

             if (platformRb != null)
            {
                platformRb.MovePosition(platformRb.position + step);
            }
            else
            {
                platformMove.position += step;
            }


            t += Time.deltaTime;
            yield return null;
        }

        player.transform.SetParent(null);
        if (pc != null) pc.canMove = true;

        Debug.Log("Elevator stop");
        moving = false;
    }
}