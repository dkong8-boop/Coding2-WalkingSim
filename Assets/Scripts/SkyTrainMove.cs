using System.Collections;
using UnityEngine;

public class TrainRide : MonoBehaviour
{
    public float waitBeforeMove = 1f;
    public float moveSpeed = 2f;
    public float moveTime = 3f;

    bool running = false;
    bool used = false;

    Transform train;

    void Awake()
    {
        train = transform.parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if (used) return;

        if (running) return;
        if (!other.CompareTag("Player")) return;

        StartCoroutine(SkyTrain(other.gameObject));


        IEnumerator SkyTrain(GameObject player)
        {
            used = true;
            running = true;

            yield return new WaitForSeconds(waitBeforeMove);

            PlayerController pc = player.GetComponent<PlayerController>();
            CharacterController cc = player.GetComponent<CharacterController>();

            if (pc != null) pc.canMove = false;

            float t = 0f;
            while (t < moveTime)
            {
                Vector3 step = Vector3.left * moveSpeed * Time.deltaTime;

                // move train
                train.position += step;

                // move player with train
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
}
