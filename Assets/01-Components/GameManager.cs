using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Animal currentAnimal;
    public int clickCounter = 0;
    public static GameManager instance { get; private set; }

    private int pointPerClick;
       
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

}
