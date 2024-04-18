using UnityEngine;


public class SceneManager : MonoBehaviour
{
    public GUIStyle _bgStyle;
    public GUIStyle _playStyle;
    public GUIStyle _soundUnmuteStyle;
    public GUIStyle _soundMuteStyle;
    public GUIStyle _gameoverstyle;
    public GUIStyle _scorestyle;
    public GUIStyle _homestyle;
    public GUIStyle _restartstyle;
    
    [SerializeField] private GameSoundManager _gameSoundManager;

    
    private void Start()
    {
        _gameSoundManager.PlayMainMenuSound();
    }
    
    private void OnGUI()
    {
        if (IsMainMenu())
        {
            HandleMainMenuUI();
        }
    }
    
    private void HandleMainMenuUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", _bgStyle);

        if (GUI.Button(new Rect(Screen.width * 0.39f, Screen.height * 0.6f, Screen.width * 0.3f, Screen.height * 0.15f), "", _playStyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            _gameSoundManager.PlayGameSound();
        }

        if (_gameSoundManager.IsSoundEnabled)
        {
            if (GUI.Button(new Rect(Screen.width * 0.85f, Screen.height * 0.05f, Screen.width * 0.1f, Screen.height * 0.1f), "", _soundUnmuteStyle))
            {
                _gameSoundManager.ToggleSoundState();
            }
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width * 0.85f, Screen.height * 0.05f, Screen.width * 0.1f, Screen.height * 0.1f), "", _soundMuteStyle))
            {
                _gameSoundManager.ToggleSoundState();
            }
        }
    }
    
    public void ShowGameOverScene(int score)
    {
        _scorestyle.fontSize = Screen.height/10;
        GUI.Box(new Rect( Screen.width*0.2f, Screen.height*0.1f, Screen.width*0.6f, Screen.height*0.45f ),"",_gameoverstyle);
        GUI.Box( new Rect( Screen.width*0.2f, Screen.height*0.4f, Screen.width *0.6f, Screen.height*0.1f ), " "+ score.ToString() , _scorestyle );
        if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.6f, Screen.width * 0.23f, Screen.height * 0.15f), "", _homestyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            _gameSoundManager.PlayMainMenuSound();
        }
        if (GUI.Button(new Rect(Screen.width * 0.52f, Screen.height * 0.6f, Screen.width * 0.23f, Screen.height * 0.15f), "", _restartstyle))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            _gameSoundManager.PlayGameSound();
        }
    }
    private bool IsMainMenu()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu";
    }
}
