using UnityEngine;
using System.Collections;

public enum SceneState { DeadScreen, StartScreen, Game }

[RequireComponent(typeof(ScreenFadeInOut))]

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();

                if (_instance == null) Debug.LogError("Missing GameManger");
                else DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }

    // scene management
    private static string game_scene = "test_scene";
    private static string dead_screen_scene = "dead_screen_scene";

    public static SceneState Scenestate { get; private set; }
    public SceneState initial_scene_state = SceneState.Game;

    // camera
    public static ScreenFadeInOut screen_fade;

    // score
    public PlayerMove player_move;
    private static float final_climb_height = 0;




    public void Awake()
    {
        // if this is the first instance, make this the singleton
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);

            Scenestate = initial_scene_state;
        }
        else
        {
            // destroy other instances that are not the already existing singleton
            if (this != _instance)
            {
                if (this.player_move) _instance.player_move = this.player_move; // save player reference of new singleton
                Destroy(this.gameObject);
            }
        }
    }
    public void Start()
    {
        screen_fade = GetComponent<ScreenFadeInOut>();

        screen_fade.InstantBlack();
        screen_fade.FadeToClear();
    }


    public void Update()
    {
        if (Scenestate == SceneState.DeadScreen || Scenestate == SceneState.StartScreen)
        {
            // space to replay
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadGame();
            }
        }
        else if (Scenestate == SceneState.Game)
        {
            // quick restart key
            if (Input.GetKeyDown(KeyCode.Backspace))
                LoadGame();
        }
        
    }

    public static void LoadDeadScreen()
    {
        if (_instance.player_move) final_climb_height = _instance.player_move.GetMaxHeightClimbed();
        else Debug.LogError("Missing PlayerMove component");

        screen_fade.InstantBlack();
        Scenestate = SceneState.DeadScreen;
        Application.LoadLevel(dead_screen_scene);
    }
    public static void LoadGame()
    {
        screen_fade.InstantBlack();
        screen_fade.FadeToClear();
        Scenestate = SceneState.Game;
        Application.LoadLevel(game_scene);
    }



    public static float GetFinalClimbHeight()
    {
        return final_climb_height;
    }

}
