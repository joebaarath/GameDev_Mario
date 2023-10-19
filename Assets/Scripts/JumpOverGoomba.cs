using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpOverGoomba : MonoBehaviour
{
    public Transform enemyLocation;
    //public TextMeshProUGUI scoreText;
    private bool onGroundState;




    //[System.NonSerialized]
    //public int score = 0; // we don't want this to show up in the inspector

    private bool countScoreState = false;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    GameManager gameManager;
    AudioSource enemiesHolderAudio;

    //Vector3 enemyTransformFromVector = new Vector3();
    //Vector3 enemyTransformToVector = new Vector3();


    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        enemiesHolderAudio = enemyLocation.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        // mario jumps
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && onGroundCheck())
        {
            onGroundState = false;
            countScoreState = true;
        }

        // when jumping, and Goomba is near Mario and we haven't registered our score
        if (!onGroundState && countScoreState)
        {
            boxCollider = GetComponent<BoxCollider2D>();
            if(enemyLocation != null)
            {
                for (int i = 0; i < enemyLocation.childCount; i++)
                {
                    Transform enemyTransform = enemyLocation.GetChild(i);
                    if (enemyTransform != null)
                    {
                        if (Mathf.Abs(transform.position.x - enemyTransform.position.x) < 1.5f)
                        {
                            // check if mario is falling and check if marios bounding box lowest y value is above (enemylocation.y - 0.5f)
                            if (boxCollider == null)
                            {
                                Debug.LogError("The GameObject does not have a BoxCollider2D component!");
                                return;
                            }

                            float boxColliderBottomY = transform.position.y + boxCollider.offset.y - boxCollider.size.y / 2;
                            BoxCollider2D enemyBoxCollider = enemyTransform.GetComponent<BoxCollider2D>();
                            float enemyTopY = enemyTransform.position.y + enemyBoxCollider.offset.y + enemyBoxCollider.size.y / 2;

                            //enemyTransformFromVector = new Vector3(enemyTransform.position.x, (enemyTransform.position.y + enemyBoxCollider.offset.y + enemyBoxCollider.size.y - 0.5f), enemyTransform.position.z);
                            //enemyTransformToVector = new Vector3(enemyTransform.position.x, (enemyTransform.position.y + enemyBoxCollider.offset.y + enemyBoxCollider.size.y + 5f), enemyTransform.position.z);


                            if (Mathf.Abs(boxColliderBottomY - enemyTopY) < 0.5f)
                            {
                                Animator enemyAnimator = enemyTransform.GetComponent<Animator>();
                                countScoreState = false;

                                //USE ANIMATION + EVENT IN ANIMATION TO GIVE SCORE
                                // play Goomba Death animation
                                enemyTransform.GetComponent<EnemyMovement>().StopGoomba();
                                enemyAnimator.SetTrigger("enemyIsDead");
                                gameManager.IncreaseScore(1);

                                enemiesHolderAudio.PlayOneShot(enemiesHolderAudio.clip);
                                gameManager.ValidMarioStompChange();
                                return;
                            }

                        }
                    }
                }

                //enemyTransformFromVector = new Vector3();
                //enemyTransformToVector = new Vector3();
            }

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) onGroundState = true;
    }


    private bool onGroundCheck()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask))
        {
            Debug.Log("on ground");
            return true;
        }
        else
        {
            Debug.Log("not on ground");
            return false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Collided with goomba!");
        }
    }


    // helper
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
        //Gizmos.DrawLine(enemyTransformFromVector, enemyTransformToVector);
    }

}
