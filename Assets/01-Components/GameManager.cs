using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Animal currentAnimal;
    public int clickCounter;
    public static GameManager instance { get; private set; }
       
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
    
}
