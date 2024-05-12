using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
using UnityEngine.Rendering;
using URPGlitch.Runtime.DigitalGlitch;
using URPGlitch.Runtime.AnalogGlitch;

public class SmileBoy : MonoBehaviour

{
   

    string[] a = { "�ȳ��ϼ���", "�� ������ ��Ű���?", "���õ� ȭ����!","(����)","��ó�� �������!","���� �ְ��� ��ȭ �ΰ����� �������̿���!","�ݰ�����!"};
    string[] b = { "���� ���ΰ���?", "��縦 �����ϰ� �־��...", "����","���� �Ϸ�!","��ȭ�ϴ� �� ��ſ� ���̿���.","���� �ΰ����������� ����� ������ ����!", "Hello, �ȳ�, ���Ϫ誦!" };
    
   

    [SerializeField] private Button smileboy;
    [SerializeField] private AudioSource audio1;
    [SerializeField] private AudioSource audio2;
    public TMP_Text smilechat;
    private bool cooldown = true;
   [SerializeField] private int rage; 
    private Volume vol;
    DigitalGlitchVolume digitalGlitchVolume;
    AnalogGlitchVolume ag;



    private Quaternion startRotation;
     public Vector3 rotationRange = new Vector3(0f, 0f, 0.1f);
   


    public void OnPointerClick()
    {
        
        int num = Random.Range(0, 6);
        if (cooldown == true)
        {
            if (rage < 6)
            {
                StartCoroutine(Clickme(smilechat, a[num], 0.1f, audio1));
              
            }

            else if (rage > 5 && rage < 10)
            {
                
                StartCoroutine(Clickme(smilechat, b[num], 0.1f, audio1));
                
            }

            else if (rage == 10)
            {
                StartCoroutine(Clickme(smilechat, "���� ��ȭ�ϰ� ���� �ʾƿ�", 0.1f, audio1));
                
            }

            else if (rage > 10)
            {
                StartCoroutine(Clickme(smilechat, "...", 0.1f, audio1));
               
                StartCoroutine(fullrage());
            } 
        }
        
    }
    IEnumerator Clickme(TMP_Text txtObj, string text, float rate, AudioSource audio)
    {


        cooldown = false;

        
        for (int i = 0; i <= text.Length; i++)
        {
            txtObj.text = text.Substring(0, i);
            if (txtObj.text.Length > 0 && txtObj.text[txtObj.text.Length - 1] != ' ') audio.Play();
            yield return new WaitForSecondsRealtime(rate);
            
        }
        rage++;
        yield return new WaitForSeconds(0.3f);
        cooldown = true;
          
        
      
    }
    IEnumerator fullrage()
    {
        smilechat.DOColor(Color.red, 1);
        smilechat.transform.DOShakeRotation(5, 10, 90);
        smilechat.rectTransform.DOScale(new Vector3(28, 21, 1), 0.2f);
        smilechat.rectTransform.DOAnchorPos(new Vector3(512, -552, 0), 0.2F);

        yield return new WaitForSeconds(0.7f);

        vol = GameObject.Find("Post").GetComponent<Volume>();
        vol.profile.TryGet<DigitalGlitchVolume>(out digitalGlitchVolume);
        vol.profile.TryGet<AnalogGlitchVolume>(out ag);

        audio2.Play();

        DOTween.To(() => 0f, x => digitalGlitchVolume.intensity.value = x, 0.5f, 0.2f).Play();
        DOTween.To(() => 0f, x => ag.horizontalShake.value = x, 0.5f, 0.2f).Play();
        DOTween.To(() => 0f, x => ag.verticalJump.value = x, 0.5f, 0.2f).Play();
        DOTween.To(() => 0f, x => ag.scanLineJitter.value = x, 0.5f, 0.2f).Play();

        yield return new WaitForSeconds(2f);

        DOTween.To(() => 0.5f, x => digitalGlitchVolume.intensity.value = x, 0.02f, 0.1f).Play();
        DOTween.To(() => 0.5f, x => ag.horizontalShake.value = x, 0f, 0.1f).Play();
        DOTween.To(() => 1f, x => ag.verticalJump.value = x, 0f, 0.1f).Play();
        DOTween.To(() => 1f, x => ag.scanLineJitter.value = x, 0f, 0.1f).Play();

        smilechat.rectTransform.DOScale(new Vector3(5, 5, 1), 0.2f);
        smilechat.rectTransform.DOAnchorPos(new Vector3(512, -273, 0), 0.2F);
        smilechat.DOColor(Color.white, 1);
        smilechat.text = "";
        rage = 1;
    }
   
}
