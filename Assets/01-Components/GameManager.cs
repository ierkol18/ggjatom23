using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public bool gameOn;

    public Animal currentAnimal;

    public int clickCounter = 0;
    public int autoClickPerSecond = 1;
    public int pointPerClick;


    private void Start()
    {
        StartCoroutine(ClickPerSecond());
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void onClick()
    {
        clickCounter += pointPerClick;
        Debug.Log(message:clickCounter);
    }

    IEnumerator ClickPerSecond()
    {
        while (gameOn)
        {
            clickCounter += autoClickPerSecond;
            yield return new WaitForSeconds(1f);
        }
    }

}
