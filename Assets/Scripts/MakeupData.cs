using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Makeup Data", menuName = "Makeup Data")]
public class MakeupData : ScriptableObject
{
    [SerializeField] private Sprite[] colors;
}
