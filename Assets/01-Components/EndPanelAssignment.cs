using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Build.Content;
using TMPro;
using Unity.VisualScripting;

public class EndPanelAssignment : MonoBehaviour
{
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject skillTree;
    [SerializeField] Sprite scene;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(BringEndPanel);

    }
    public void BringEndPanel()
    {
        Debug.Log("end panel called");
        skillTree.SetActive(false);
        UICanvas.instance.DestroyAll();
        endPanel.GetComponent<Image>().sprite = scene;
        endPanel.SetActive(true);
    }
}
