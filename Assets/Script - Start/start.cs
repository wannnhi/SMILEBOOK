using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class start : MonoBehaviour
    , IPointerClickHandler
{

    [SerializeField] private GameObject window;
    [SerializeField] private CanvasGroup TurnCanvas;
    [SerializeField] private RawImage back;
    [SerializeField] private TMP_Text welcome;
    public void OnPointerClick(PointerEventData eventData)
    {
        TurnCanvas.DOFade(0, 1);
        StartCoroutine(start1());

    }
    IEnumerator start1()
    {
        yield return new WaitForSeconds(1);
        welcome.DOFade(1, 1);
        
        yield return new WaitForSeconds(2);
        welcome.DOFade(0, 1);
        
        yield return new WaitForSeconds(1);
        back.DOFade(0, 2);
        window.SetActive(true);






    }

}
