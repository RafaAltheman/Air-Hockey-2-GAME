using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public bool isTopGoal = true;
    public GameManager gameManager;

    void Start()
    {
        if (!gameManager)
            gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Puck")) return;
        if (!gameManager) return;

        if (isTopGoal) gameManager.GoalTop();
        else           gameManager.GoalBottom();
    }
}
