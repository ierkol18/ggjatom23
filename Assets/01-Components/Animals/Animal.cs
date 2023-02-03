using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Animal : MonoBehaviour, IPointerClickHandler
{

    public AnimalData animalData;
    [SerializeField] Image image;
    [SerializeField] RectTransform rectT;

    void Start()
    {
        image.sprite = animalData.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerEnter == this.gameObject)
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
        yield return new WaitForSeconds(0.8f);

        Destroy(ooc.gameObject);

    }

}
