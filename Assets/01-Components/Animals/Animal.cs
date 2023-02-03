using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{

    [SerializeField] AnimalData animalData;
    [SerializeField] Image image;
    [SerializeField] RectTransform rectT;

    void Start()
    {
        image.sprite = animalData.sprite;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.onClick();
            
          
            StartCoroutine(onObjectClicked());
            
        }

    }

    IEnumerator onObjectClicked()
    {
        ObjectsOnClick ooc = Instantiate(animalData.objectsOnClick_prefab, transform);
        Vector2 mousePos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectT, Input.mousePosition, null, out mousePos))
        {
            ooc.gameObject.transform.position = rectT.TransformPoint(mousePos);
        }
        yield return new WaitForSeconds(1f);

        Destroy(ooc.gameObject);
    }

}
