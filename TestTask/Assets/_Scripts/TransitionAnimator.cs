using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionAnimator : MonoBehaviour
{
    [SerializeField] private Image transitionPanel;
    public void ShowTransition()
    {
        gameObject.SetActive(true);
        StartCoroutine(StartTransition());
    }
    public void HideTransition()
    {
        gameObject.SetActive(true);
        StartCoroutine(EndTransition());
    }
    private IEnumerator StartTransition()
    {
        transitionPanel.color = new Color(transitionPanel.color.r, transitionPanel.color.g, transitionPanel.color.b, 0);
        while (transitionPanel.color.a < 100)
        {
            transitionPanel.color = new Color(transitionPanel.color.r, transitionPanel.color.g, transitionPanel.color.b, transitionPanel.color.a + Time.deltaTime);
            yield return null;
        }
        gameObject.SetActive(false);
    }
    private IEnumerator EndTransition()
    {

        transitionPanel.color = new Color(transitionPanel.color.r, transitionPanel.color.g, transitionPanel.color.b, 100);
        while (transitionPanel.color.a > 0)
        {
            transitionPanel.color = new Color(transitionPanel.color.r, transitionPanel.color.g, transitionPanel.color.b, transitionPanel.color.a - Time.deltaTime);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
