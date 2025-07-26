using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.Events;
 
 public class Face : MonoBehaviour, IDropHandler
 {
     public UnityEvent onCreamUsed;
     public UnityEvent onBlushUsed;
     public UnityEvent onEyeshadowUsed;
     public UnityEvent onSpongeUsed;
     public UnityEvent<Sprite> onLipstickUsed;
     
     public void OnDrop(PointerEventData eventData)
     {
         GameObject dragged = eventData.pointerDrag;
         
         if (dragged != null) UseTool(dragged);
     }
     // -------------Вызов метода по тегу------------
     public void UseTool(GameObject dragged)
     {
         string toolTag = dragged.tag;
         switch (toolTag)
         {
             case "Cream":
                 onCreamUsed.Invoke();
                 break;
             
             case "Blush":
                 onBlushUsed.Invoke();
                 break;
             
             case "Eyeshadow":
                 onEyeshadowUsed.Invoke();
                 break;
             
             case "Sponge":
                 onSpongeUsed.Invoke();
                 break;
             
             case "Lipstick":
                 if (dragged.TryGetComponent(out LipstickColor lipstick))
                 {
                     onLipstickUsed?.Invoke(lipstick.Color);
                 }
                 else
                 {
                     Debug.LogWarning("На помаде нет компонента LipstickColor.");
                 }
                 break;
             
             default:
                 Debug.Log("Непредвиденная ошибка");
                 break;
         }
     }
 }