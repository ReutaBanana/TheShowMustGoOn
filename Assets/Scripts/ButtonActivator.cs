using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    [SerializeField]private Color _baseColor;
    [SerializeField] private Color _changeColor;

    [SerializeField] private float _delaySpeed=0.3f;

    [SerializeField] private AudioSource soundEffect;
    public void ActivateBtn()
    {
        gameObject.GetComponent<Image>().color = _changeColor;
        soundEffect.Play();
        StartCoroutine(ChangeToBaseColor());
    }
    
    IEnumerator ChangeToBaseColor()
    {
        yield return new WaitForSeconds(_delaySpeed);
        gameObject.GetComponent<Image>().color = _baseColor;

    }

    public void SetToInteractable()
    {
        this.gameObject.GetComponent<Button>().interactable = true;
    } 
    public void SetToNonInteractable()
    {
        this.gameObject.GetComponent<Button>().interactable = false;
    }
}
