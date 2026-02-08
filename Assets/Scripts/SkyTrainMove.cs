using System.Collections;
using UnityEngine;

public class TrainRide : MonoBehaviour
{
    public float waitBeforeMove = 3f;
    public float moveSpeed = 80f;
    public float moveTime = 5f;

    bool running = false;

    Transform train;

    void Awake()
    {
        train = transform.parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if (running) return;
        if (!other.CompareTag("Player")) return;

        StartCoroutine(RideRoutine(other.gameObject));
    }

    IEnumerator RideRoutine(GameObject player)
    {
        running = true;

        yield return new WaitForSeconds(waitBeforeMove);

        PlayerController pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.canMove = false;

        CharacterController cc = player.GetComponent<CharacterController>();

       

        float t = 0f;
        while (t < moveTime)
        {
            Vector3 step = Vector3.left * moveSpeed * Time.deltaTime;

            train.position += step;

            if (cc != null)
                cc.Move(step);
            else
                player.transform.position += step;

            t += Time.deltaTime;
            yield return null;
        }

        if (pc != null) pc.canMove = true;

        running = false;
    }
}