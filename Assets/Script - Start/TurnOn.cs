using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.Rendering;
using URPGlitch.Runtime.DigitalGlitch;
using URPGlitch.Runtime.AnalogGlitch;

public class TurnOn : MonoBehaviour
     , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerClickHandler
   
{


    [SerializeField] private RectTransform TurnButton;
    [SerializeField] private CanvasGroup TurnCanvas; 
    private Volume vol;
    DigitalGlitchVolume digitalGlitchVolume;
    AnalogGlitchVolume ag;
    [SerializeField] private RawImage windows;
    [SerializeField] private AudioSource audio1;
   



    public void OnPointerEnter(PointerEventData eventData)
    {
        TurnButton.DOScale(new Vector3(0.9f, 0.9f, 0.5f), 0.5f).SetEase(Ease.InSine);
   
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        TurnButton.DOScale(new Vector3(1f, 1f, 1), 0.1f).SetEase(Ease.InSine);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TurnCanvas.DOFade(0, 0.3f);
        vol = GameObject.Find("Post").GetComponent<Volume>();
        vol.profile.TryGet<DigitalGlitchVolume>(out digitalGlitchVolume);
        vol.profile.TryGet<AnalogGlitchVolume>(out ag);

        vol.enabled = true;
       
        StartCoroutine(Lesgo());
    }

    IEnumerator Lesgo()
    {
        DOTween.To(() => 0f, x => digitalGlitchVolume.intensity.value = x, 1f, 1.5f).Play();
        
        yield return new WaitForSeconds(1);
        windows.gameObject.SetActive(true);
        DOTween.To(() => 1f, x => ag.horizontalShake.value = x, 0f, 1.5f).Play();
        yield return new WaitForSeconds(2);
        windows.DOColor(new Color32(63, 108, 161, 255),1);
       
        DOTween.To(() => 0f, x => digitalGlitchVolume.intensity.value = x, 0.02f, 1.5f).Play();

    }

   
}
