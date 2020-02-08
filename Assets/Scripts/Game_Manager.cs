using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {

    public static Game_Manager Instance;

    public bool gamePause;

    public Text currentScore_Text;

    Flappi_Bird_Controller flappi_Bird_Controller;
    Obstacles_Spawner obstacles_Spawner;

    void Awake() {
        Instance = this;
        gamePause = true;
    }

    // Start is called before the first frame update
    void Start() {

        if (!flappi_Bird_Controller) {
            flappi_Bird_Controller = FindObjectOfType<Flappi_Bird_Controller>();
        }
        if (!obstacles_Spawner) {
            obstacles_Spawner = FindObjectOfType<Obstacles_Spawner>();
        }

    }

    // Update is called once per frame
    void Update() {
        //If game not paused or stopped
        if (!gamePause) {

            //Unfreeze flappi bird rigidbody2d
            //(note:that is not the efficient way cause it's in the update method and it should be called once if needed)
            flappi_Bird_Controller.UnFreeze();

            //Jump inputs
            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) {
                flappi_Bird_Controller.Jump();
            }

            //Spawning obstacles
            obstacles_Spawner.Spawning();

        } else {
            //If game is paused or stopped

            //Freeze flappi bird rigidbody2d
            //(note:that is not the efficient way cause it's in the update method and it should be called once if needed)
            flappi_Bird_Controller.Freeze();
        }

    }


    public void PauseGame(bool _Val) {
        gamePause = _Val;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }


}
