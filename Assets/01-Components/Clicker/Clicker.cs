using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    [SerializeField] int pointPerClick;
    private int clickCounter = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            clicks += pointPerClick;
    }

 
}
