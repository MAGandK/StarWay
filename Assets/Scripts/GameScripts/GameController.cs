using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnEnable()
    {
        PlayerController.OnDiedPlayer += PlayerControllerOnDiedPlayer;
    }

    private void PlayerControllerOnDiedPlayer()
    {
        ShowPopups.Instance.ShowPopup();
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        PlayerController.OnDiedPlayer -= PlayerControllerOnDiedPlayer;
    }
    
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
