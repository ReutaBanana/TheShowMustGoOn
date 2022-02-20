using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]private Color _baseColor;
    [SerializeField] private Color _changeColor;

    [SerializeField] private float _delaySpeed=0.3f;
    public void ChangeColor()
    {
        gameObject.GetComponent<Image>().color = _changeColor;
        StartCoroutine(ChangeToBaseColor());
    }
    
    IEnumerator ChangeToBaseColor()
    {
        yield return new WaitForSeconds(_delaySpeed);
        gameObject.GetComponent<Image>().color = _baseColor;

    }
}
