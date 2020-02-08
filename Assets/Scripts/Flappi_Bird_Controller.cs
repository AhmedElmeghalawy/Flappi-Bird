using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappi_Bird_Controller : MonoBehaviour
{

    public float currentScore = 0f;

    public float jump_Speed = 6f;

    private Rigidbody2D flappi_RB;


    // Start is called before the first frame update
    void Start()
    {
        flappi_RB = GetComponent<Rigidbody2D>();

    }

    public void Jump() {
        flappi_RB.velocity = new Vector2(0, 1) * jump_Speed;
    }


    public void Freeze() {
        flappi_RB.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
    public void UnFreeze() {
        flappi_RB.constraints = RigidbodyConstraints2D.None;
    }



    void OnTriggerEnter2D(Collider2D Other) {

        if (Other.gameObject.tag == "non_obstacle") {
            currentScore++;
            Game_Manager.Instance.currentScore_Text.text = "Score: " + currentScore.ToString();

        } else if (Other.gameObject.tag == "obstacle") {
            Game_Manager.Instance.RestartGame();
        }
    }

}
