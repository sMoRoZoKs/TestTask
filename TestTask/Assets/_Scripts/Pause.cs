using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Player player;
    public void OnPause()
    {
        if (player.GetIsGo)
        {
            player.PlayerStop();
        }
        else
        {
            player.PlayerStart();
        }

        pausePanel.SetActive(!player.GetIsGo);
    }
}
