using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Game state manager that runs across all scenes
*/
public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;

    public static GameManager Instance  // Game Manager instance to be accessed from anywhere
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is Null!!!");
            return _instance;
        }
    }
    
    // Current state and all available states 

    public GameBaseState currentState;
    public MainScreenState MainScreenState = new MainScreenState();
    public OverworldState OverworldState = new OverworldState();
    public World1State World1state = new World1State();
    public GameOverState GameOverState = new GameOverState();
    public CatClimbState CatClimbState = new CatClimbState();
    public GamePausedState GamePausedState = new GamePausedState();
    public TargetsState TargetsState = new TargetsState();
    public SettingsState SettingsState = new SettingsState();

    public SceneManager sceneManager;

    // Setting game parameters
    public int lives = 3;
    public bool gameOver = false;
    public bool paused = false;

    // Settings screen and Main screen
    public GameObject settingsPanel, mainPanel, toggleGroup;
    public GameObject gameOverPanel;
    public Toggle easyToggle, amateurToggle, proToggle;
    public Toggle[] toggles;
    public ToggleGroup togglesGroup;
    public Slider slider;
    public bool backButtonIsPressed = false;

    // Settings values
    public string difficulty;
    public float countdownTime = 120f;
    public float sensitivity = 1f;
    public int score = 0;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);  // Ensuring Game Manager runs across all scenes
        Debug.Log("Dont destroy on load activated!");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = MainScreenState; // Setting current state
        currentState.EnterState(this);  // Use state
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this); // Use state
    }

    // Switch current state
    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void SceneLoad(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    // Lives controller. Activates Game Over State when none left
    public void LoseLife()
    {
        if (lives > 1)
        {
            lives -= 1;            
        }
        else if (lives == 1)
        {
            lives -= 1;
            Lives.livesText.text = "Lives: " + (lives).ToString();
            SwitchState(GameOverState);
        }
        
    }

    // Restart game from beginning of current level. Activates when Restart button is pressed in game over menu
    public void ResetGame()
    {
        Debug.Log("entered reset game");
        Time.timeScale = 1; // Re-enabling movement
        paused = false;
        gameOver = false;
        lives = 3;
        GameObject.FindGameObjectWithTag("gameoverpanel").SetActive(false);

        switch (SceneManager.GetActiveScene().name)
        {
            case "World1": SwitchState(World1state); break;
            case "CatClimb": SwitchState(CatClimbState); break;
            case "Targets": SwitchState(TargetsState); break;
        }
        
    }

    // Activates when Overworld button is pressed to take player back to overworld from pause menu
    public void GotoOverworld()
    {
        Debug.Log("entered goto overworld");
        Time.timeScale = 1;
        paused = false;
        SwitchState(OverworldState);
    }

    // Activates when quit button is pressed in pause menu or game over menu
    public void QuitGame()
    {
        Time.timeScale = 1;
        paused = false;
        SwitchState(MainScreenState);
    }
    
    // Sets the sensitivity of the player's rotation from the slider's value in settings
    public void HandleSliderChange()
    {
        sensitivity = slider.value;

        Debug.Log(slider.value);
        
        
    }

    // Sets difficulty according to which toggle is selected in settings
    public void SetDifficultySettings()
    {
        switch (difficulty)
        {
            case "Novice": SetNoviceSettings(); break;
            case "Amateur": SetAmateurSettings(); break;
            case "Pro": SetProSettings(); break;
        }
    }


    public void SetNoviceSettings()
    {
        countdownTime = 120;
    }

    public void SetAmateurSettings()
    {
        countdownTime = 90;
    }

    public void SetProSettings()
    {
        countdownTime = 60;
    }
}
