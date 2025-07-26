using System;
using UnityEngine;
using UnityEngine.UI;

public class ApplyingMakeup : MonoBehaviour
{
    [Header("Целевые области")]
    [SerializeField] private Image blush;
    [SerializeField] private Image lip;
    [SerializeField] private Image eyeshadowRight;
    [SerializeField] private Image eyeshadowLeft;

    [Header("Акне")] [SerializeField] private GameObject acne;
    
    [Header("Спрайты цветов")]
    private Sprite colorBlush;
    private Sprite colorEyeshadowRight;
    private Sprite colorEyeshadowLeft;
    
    
    // -------------Выбор спрайтов на палитре------------
    public void ChooseColorForBlush(Sprite color)
    {
        colorBlush = color;
    }

    public void ChooseColorForEyeshadow(Sprite color)
    {
        colorEyeshadowRight = color; colorEyeshadowLeft = color;
    }
    
    // -------------Использование предметов-----------
    public void UseCream()
    {
        if (acne != null) acne.SetActive(false);
    }

    public void UseBlush()
    {
        ApplySprite(blush, colorBlush);
    }

    public void UseEyeshadow()
    {
        ApplySprite(eyeshadowRight, colorEyeshadowRight);
        ApplySprite(eyeshadowLeft, colorEyeshadowLeft);
    }

    public void UseLipstick(Sprite color)
    {
        ApplySprite(lip, color);
    }

    public void UseSponge()
    {
        blush.gameObject.SetActive(false);
        lip.gameObject.SetActive(false);
        eyeshadowLeft.gameObject.SetActive(false);
        eyeshadowRight.gameObject.SetActive(false);
    }
    
    // -------------Метод изменеия спрайта объекта------------
    private void ApplySprite(Image target, Sprite color)
    {
        if (target == null || color == null) return;
        
        if(!target.gameObject.activeSelf)
            target.gameObject.SetActive(true);

        target.sprite = color;
    }
}