using UnityEngine;
using UnityEngine.UI;

public class RestartWindow : MonoBehaviour
{
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonExitIcon;
    [SerializeField] private Button _buttonExit;
    private int _stopTime;
    private int _startTime;

    private void Start()
    {
        Time.timeScale = _stopTime;
        _buttonRestart.onClick.AddListener(OnRestartButtonClick);
        _buttonExit.onClick.AddListener(OnExitButtonClick);

    }
    
    private void OnRestartButtonClick()
    {
        Time.timeScale = _startTime;
        GameController.Instance.RestartLevel();
    }

    private void OnExitButtonClickIcon()
    {
        ShowPopups.Instance.ClosePopup();
    

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }
    
    private void OnExitButtonClick()
    {
        ShowPopups.Instance.ClosePopup();
    

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}