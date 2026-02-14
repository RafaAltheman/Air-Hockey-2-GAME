using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public PuckReset puckReset;

    int scoreTop = 0;     
    int scoreBottom = 0;  

    void Start()
    {
        UpdateUI();
    }


    public void GoalTop()
    {
        scoreBottom++;
        UpdateUI();

        if (puckReset)
            puckReset.OnGoalScored(true);
    }


    public void GoalBottom()
    {
        scoreTop++;
        UpdateUI();

        if (puckReset)
            puckReset.OnGoalScored(false);
    }

    void UpdateUI()
    {
        if (scoreText)
            scoreText.text = $"{scoreTop} - {scoreBottom}";
    }
}
