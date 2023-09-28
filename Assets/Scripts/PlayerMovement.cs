using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float maxSpeed = 20;
    private Rigidbody2D marioBody;
    public float upSpeed = 10;
    private bool onGroundState = false;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;
    public TextMeshProUGUI scoreText;
    public GameObject enemies;
    public GameObject obstacle;
    public JumpOverGoomba jumpOverGoomba;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;

    public Animator marioAnimator;

    public Transform gameCamera;

    // for audio
    public AudioSource marioAudio;

    public AudioClip marioDeath;
    public float deathImpulse = 15;
    private float previousMoveHorizontal = 0;

    // state
    [System.NonSerialized]
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        marioSprite = GetComponent<SpriteRenderer>();

        // Set to be 30 FPS
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        ResetGame();

    }

    // Update is called once per frame
    void Update()
    {
        // toggle state
        if (alive && Input.GetKeyDown("a") && faceRightState)
        {
            faceRightState = false;
            marioSprite.flipX = true;
            if (marioBody.velocity.x > 0.1f)
                marioAnimator.SetTrigger("onSkid");
        }

        if (alive && Input.GetKeyDown("d") && !faceRightState)
        {
            faceRightState = true;
            marioSprite.flipX = false;
            if (marioBody.velocity.x < -0.1f)
                marioAnimator.SetTrigger("onSkid");
        }

        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
    }

    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7);
    void OnCollisionEnter2D(Collision2D col)
    {

        //if ((col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Enemies") || col.gameObject.CompareTag("Obstacles")) && !onGroundState)
        //{
        //    onGroundState = true;
        //    // update animator state
        //    marioAnimator.SetBool("onGround", onGroundState);
        //}

        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);
        }
    }

    // FixedUpdate is called 50 times a second
    void FixedUpdate()
    {
        if (alive)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            // other code

            if (Mathf.Abs(moveHorizontal) > 0)
            {
                Vector2 movement = new Vector2(moveHorizontal, 0);
                // check if it doesn't go beyond maxSpeed
                if (marioBody.velocity.magnitude < maxSpeed)
                    marioBody.AddForce(movement * speed);
            }

            // stop
            // when Input.GetKeyUp("a") or equivalent to Input.GetKeyUp("d")
            if ((previousMoveHorizontal == -1 && moveHorizontal == 0) || (previousMoveHorizontal == 1 && moveHorizontal == 0))
            {
                // stop
                marioBody.velocity = Vector2.zero;
            }

            // Update previousMoveHorizontal for the next frame
            previousMoveHorizontal = moveHorizontal;

            if ((Input.GetKeyDown("w") || Input.GetKeyDown("space")) && onGroundState)
            {
                marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
                onGroundState = false;
                // update animator state
                marioAnimator.SetBool("onGround", onGroundState);
            }

        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemies") && alive)
        {
            Debug.Log("Collided with goomba!");

            // play death animation
            marioAnimator.Play("mario-die");
            marioAudio.PlayOneShot(marioDeath);
            alive = false;
        }
    }

    public void DisplayGameOverCanvas()
    {
        Debug.Log("Display GameOver Canvas");
        gameOverCanvas.enabled = true;

        // Note: since we're using GetComponentInChildren, the order of the text (tmp) gameobject matters as it will only get the first TextMeshProUGUI object 
        gameOverCanvas.GetComponentInChildren<TextMeshProUGUI>().text = scoreText.text;

    }

    public void HideGameOverCanvas()
    {
        Debug.Log("Hide GameOver Canvas");
        gameOverCanvas.enabled = false;
    }

    public void DisplayInGameCanvas()
    {
        Debug.Log("Display InGame Canvas");
        inGameCanvas.enabled = true;

    }

    public void HideInGameCanvas()
    {
        Debug.Log("Hide InGame Canvas");
        inGameCanvas.enabled = false;
    }

    public void RestartButtonCallback(int input)
    {
        Debug.Log("Restart!");
        // reset everything
        ResetGame();
        // resume time
        Time.timeScale = 1.0f;
    }

    private void ResetGame()
    {
        // reset position
        //marioBody.transform.position = new Vector3(-5.33f, -4.69f, 0.0f);
        HideGameOverCanvas();
        DisplayInGameCanvas();
        marioBody.transform.position = new Vector3(-7.2f, -4.45f, 0.0f);
        // reset sprite direction
        faceRightState = true;
        marioSprite.flipX = false;
        // reset score
        scoreText.text = "Score: 0";
        // reset Goomba
        foreach (Transform eachChild in enemies.transform)
        {
            eachChild.transform.localPosition = eachChild.GetComponent<EnemyMovement>().startPosition;
        }

        //foreach (Transform eachChild in obstacle.transform)
        //{
        //    eachChild.transform.localPosition = eachChild.GetComponent<EnemyMovement>().startPosition;
        //}

        // reset score
        jumpOverGoomba.score = 0;

        // reset animation
        marioAnimator.SetTrigger("gameRestart");
        alive = true;

        // reset camera position
        gameCamera.position = new Vector3(0, 0, -10);

    }

    void PlayJumpSound()
    {
        // play jump sound
        marioAudio.PlayOneShot(marioAudio.clip);
    }

    void PlayDeathImpulse()
    {
        marioBody.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse);
    }

    void GameOverScene()
    {
        // stop time
        Time.timeScale = 0.0f;

        // set gameover scene
        //gameManager.GameOver(); // replace this with whichever way you triggered the game over screen for Checkoff 1
        DisplayGameOverCanvas();
        HideInGameCanvas();

    }


}