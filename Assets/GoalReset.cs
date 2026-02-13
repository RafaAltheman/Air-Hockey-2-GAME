using UnityEngine;

public class GoalReset : MonoBehaviour
{
    PuckReset puckReset;

    void Start()
    {
        puckReset = FindFirstObjectByType<PuckReset>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Puck")) return;

        if (puckReset != null)
            puckReset.OnGoalScored();
    }
}
