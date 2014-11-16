using UnityEngine;
using System.Collections;

public enum SceneState { DeadScreen, Game }

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
                Destroy(this.gameObject);
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
        if (Scenestate == SceneState.DeadScreen)
        {
            // space to replay
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadGame();
            }
        }
        else if (Scenestate == SceneState.Game)
        {
            
        }
    }

    public static void LoadDeadScreen()
    {
        screen_fade.InstantBlack();
        Scenestate = SceneState.DeadScreen;
        Application.LoadLevel(dead_screen_scene);
    }
    public static void LoadGame()
    {
        screen_fade.InstantBlack();
        screen_fade.FadeToClear();
        Scenestate = SceneState.DeadScreen;
        Application.LoadLevel(game_scene);
    }

}
