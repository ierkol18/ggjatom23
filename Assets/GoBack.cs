using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    [SerializeField] GameObject market;
  public void disable() {
        GameManager.instance.gameOn = true;
        UICanvas.instance.isHoldingMarketButton = false;
        market.SetActive(false);
    }
}
