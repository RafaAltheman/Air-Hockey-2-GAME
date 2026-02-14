using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public PuckReset puckReset;

    int scoreTop = 0;     // IA (cima)
    int scoreBottom = 0;  // Mouse (baixo)

    void Start()
    {
        UpdateUI();
    }

    // Chamado quando a bola entra no gol de cima => ponto pro de baixo
    public void GoalTop()
    {
        scoreBottom++;
        UpdateUI();

        if (puckReset)
            puckReset.OnGoalScored(true);
    }

    // Chamado quando a bola entra no gol de baixo => ponto pro de cima
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
