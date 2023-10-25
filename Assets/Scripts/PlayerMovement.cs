using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IPowerupApplicable
{

    public GameConstants gameConstants;
    float deathImpulse;
    float upSpeed;
    float maxSpeed;
    float speed;


    //public float speed = 10;
    //public float maxSpeed = 20;
    private Rigidbody2D marioBody;
    //public float upSpeed = 10;
    private bool onGroundState = false;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;
    public TextMeshProUGUI scoreText;
    public GameObject enemies;
    public GameObject obstacle;

    public Animator marioAnimator;

    public Transform gameCamera;

    // for audio
    public AudioSource marioAudio;

    public AudioSource marioDeathAudio;
    //public float deathImpulse = 15;
    private float previousMoveHorizontal = 0;

    private bool moving = false;
    private bool jumpedState = false;

    // state
    [System.NonSerialized]
    public bool alive = true;
    bool isMarioStomping = false;

    void Awake()
    {
        // subscribe to Game Restart event
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set constants
        speed = gameConstants.speed;
        maxSpeed = gameConstants.maxSpeed;
        deathImpulse = gameConstants.deathImpulse;
        upSpeed = gameConstants.upSpeed;


        // Set to be 30 FPS
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();
        marioAnimator.SetBool("onGround", onGroundState);

        //ResetGame();

        // Subscribe to see if mario has valid JumpOverGoomba conditions
        GameManager.instance.OnMarioValidStompNotifier += setMarioStompingTrue;

        //// subscribe to scene manager scene change
        //SceneManager.activeSceneChanged += SetStartingPosition;

    }

    public void SetStartingPosition(Scene current, Scene next)
    {
        if (next.name == "World 1-2")
        {
            // change the position accordingly in your World-1-2 case
            this.transform.position = new Vector3(-7.75f, -4.468305f, 0.0f);
        }
    }

    private void setMarioStompingTrue()
    {
        isMarioStomping = true;
    }


    // Update is called once per frame
    void Update()
    {
        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));

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

    void FlipMarioSprite(int value)
    {
        if (alive && value == -1 && faceRightState)
        {
            faceRightState = false;
            marioSprite.flipX = true;
            if (marioBody.velocity.x > 0.05f)
                marioAnimator.SetTrigger("onSkid");
        }

        else if (alive && value == 1 && !faceRightState)
        {
            faceRightState = true;
            marioSprite.flipX = false;
            if (marioBody.velocity.x < -0.05f)
                marioAnimator.SetTrigger("onSkid");
        }
    }

    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7);
    void OnCollisionEnter2D(Collision2D col)
    {

        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);
            isMarioStomping = false;
        }
    }

    // FixedUpdate is called 50 times a second
    void FixedUpdate()
    {

        if (alive && moving)
        {
            Move(faceRightState == true ? 1 : -1);
        }

    }

    void Move(int value)
    {

        Vector2 movement = new Vector2(value, 0);
        // check if it doesn't go beyond maxSpeed
        if (marioBody.velocity.magnitude < maxSpeed)
            marioBody.AddForce(movement * speed);
    }
    public void Jump()
    {
        if (alive && onGroundState)
        {
            // jump
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            jumpedState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);

        }
    }

    public void JumpHold()
    {
        if (alive && jumpedState)
        {
            // jump higher
            marioBody.AddForce(Vector2.up * upSpeed * 30, ForceMode2D.Force);
            jumpedState = false;
        }
    }

    public void MoveCheck(int value)
    {
        if (value == 0)
        {
            moving = false;
        }
        else
        {
            FlipMarioSprite(value);
            moving = true;
            Move(value);
        }
    }

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.GameOver();


    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemies") && alive)
        {
            if(!isMarioStomping && !other.gameObject.GetComponent<EnemyMovement>().isEnemyDead)
            {
                marioDeathAudio.PlayOneShot(marioDeathAudio.clip);
                Debug.Log("Collided with goomba!");
                // play death animation
                marioAnimator.Play("mario-die");
                //marioAudio.PlayOneShot(marioDeath);
                alive = false;
                PlayDeathImpulse();
                StartCoroutine(WaitAndDie());
            }
            else
            {
                Debug.Log("Collided with goomba BUT IS STOMPING!");
            }

        }
    }

    //public void DisplayGameOverCanvas()
    //{
    //    Debug.Log("Display GameOver Canvas");
    //    gameOverCanvas.enabled = true;

    //    // Note: since we're using GetComponentInChildren, the order of the text (tmp) gameobject matters as it will only get the first TextMeshProUGUI object 
    //    gameOverCanvas.GetComponentInChildren<TextMeshProUGUI>().text = scoreText.text;

    //}

    //public void HideGameOverCanvas()
    //{
    //    Debug.Log("Hide GameOver Canvas");
    //    gameOverCanvas.enabled = false;
    //}

    //public void DisplayInGameCanvas()
    //{
    //    Debug.Log("Display InGame Canvas");
    //    inGameCanvas.enabled = true;

    //}

    //public void HideInGameCanvas()
    //{
    //    Debug.Log("Hide InGame Canvas");
    //    inGameCanvas.enabled = false;
    //}

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
        //HideGameOverCanvas();
        //DisplayInGameCanvas();
        marioBody.transform.position = new Vector3(-7.2f, -4.45f, 0.0f);
        // reset sprite direction
        faceRightState = true;
        marioSprite.flipX = false;
        // reset score
        //scoreText.text = "Score: 0";
        // reset Goomba
        foreach (Transform eachChild in enemies.transform)
        {
            eachChild.localPosition = eachChild.GetComponent<EnemyMovement>().startPosition;
        }

        // reset score
        GameManager.instance.GameOver();

        // reset animation
        marioAnimator.SetTrigger("gameRestart");
        alive = true;

        // reset camera position
        gameCamera.position = new Vector3(0, 0, -10);

    }

    public void GameRestart()
    {
        // reset position
        marioBody.transform.position = new Vector3(-5.33f, -4.69f, 0.0f);
        // reset sprite direction
        faceRightState = true;
        marioSprite.flipX = false;

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

    public void RequestPowerupEffect(IPowerup i)
    {
        throw new System.NotImplementedException();
    }
}