using UnityEngine;
public class ChooseTool : MonoBehaviour
{
    private GameObject _activePanel;

    public void SetActivePanel(GameObject panel)
    {
        if (_activePanel != null) 
            _activePanel.SetActive(false);
        
        _activePanel = panel;
        _activePanel.SetActive(true);
    }
}
