using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    [SerializeField] GameObject market;
  public void disable() {
        GameManager.instance.gameOn = true;
        UICanvas.instance.isHoldingMarketButton = false;
        foreach (Animal animal in UICanvas.instance.currentAnimalsOnScreen)
            animal.gameObject.SetActive(true);
            
        market.SetActive(false);
    }
}
