using System.Collections;
using TMPro;
using UnityEngine;

public class GoalUI : MonoBehaviour
{
    public TMP_Text goalText;
    public float showSeconds = 1.2f;

    void Start()
    {
        if (goalText) goalText.gameObject.SetActive(false);
    }

    public void ShowGoal(string msg = "GOL!")
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(msg));
    }

    IEnumerator ShowRoutine(string msg)
    {
        goalText.text = msg;
        goalText.gameObject.SetActive(true);

        yield return new WaitForSeconds(showSeconds);

        goalText.gameObject.SetActive(false);
    }

    public void Hide()
    {
        StopAllCoroutines();
        if (goalText) goalText.gameObject.SetActive(false);
    }
}
