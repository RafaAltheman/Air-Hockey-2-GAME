using System.Collections;
using UnityEngine;

public class PuckReset : MonoBehaviour
{
    [Header("Positions")]
    public Vector2 puckStartPosition = Vector2.zero;
    public Transform playerBottom;
    public Transform playerTop;

    [Header("Ball")]
    public float startSpeed = 6f;
    public float goalDelay = 2.0f;

    [Header("Freeze")]
    public bool freezePlayersDuringGoal = true;

    Rigidbody2D rb;
    bool resetting = false;

    Vector2 playerBottomStart;
    Vector2 playerTopStart;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (playerBottom) playerBottomStart = playerBottom.position;
        if (playerTop)    playerTopStart    = playerTop.position;

        HardResetImmediate();
        LaunchBall();
    }

    public void OnGoalScored(bool isTopGoal)
    {
        if (resetting) return;
        StartCoroutine(ResetAfterGoal());
    }

    IEnumerator ResetAfterGoal()
    {
        resetting = true;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        Rigidbody2D rbBottom = null, rbTop = null;
        if (freezePlayersDuringGoal)
        {
            if (playerBottom) rbBottom = playerBottom.GetComponent<Rigidbody2D>();
            if (playerTop)    rbTop    = playerTop.GetComponent<Rigidbody2D>();

            if (rbBottom) rbBottom.simulated = false;
            if (rbTop)    rbTop.simulated = false;
        }

        yield return new WaitForSeconds(goalDelay);

        HardResetImmediate();

        if (freezePlayersDuringGoal)
        {
            if (rbBottom) rbBottom.simulated = true;
            if (rbTop)    rbTop.simulated = true;
        }

        LaunchBall();
        resetting = false;
    }

    void HardResetImmediate()
    {
        transform.position = puckStartPosition;

        if (playerBottom) playerBottom.position = playerBottomStart;
        if (playerTop)    playerTop.position    = playerTopStart;
    }

    void LaunchBall()
    {
        Vector2 dir = new Vector2(Random.Range(-0.8f, 0.8f),
                                  Random.value < 0.5f ? 1f : -1f).normalized;

        rb.linearVelocity = dir * startSpeed;
    }
}
