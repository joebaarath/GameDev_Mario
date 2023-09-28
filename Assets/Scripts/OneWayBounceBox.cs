using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayBounceBox : MonoBehaviour
{

    public SpringJoint2D springJoint;
    public float threshold = 1f;
    public Transform player; // Mario's Transform
    //Transform coinContainer;
    public float distanceToMove = 2.0f;
    bool isActiveBox = true;

    public Animator qboxAnimator;
    public Animator coinAnimator;

    public AudioSource coinAudioSource;

    public int box_type = 1;
    //box_type: 1 -> qbox w/ coin; 2 -> brick w coin; 3 -> brick no coin

    // Start is called before the first frame update
    void Start()
    {
        // Enable Bounce
        springJoint.dampingRatio = 0.3f;
        springJoint.frequency = 10;
    }

    void Update()
    {
        if (isActiveBox == false && box_type == 1)
        {
            ////Else disable bounce 
            //springJoint.dampingRatio = 0;
            //springJoint.frequency = 0;
        }
    }

    IEnumerator GradualDisableBounce()
    {
        yield return new WaitForSeconds(0.1f);
        springJoint.dampingRatio = 0.6f;
        springJoint.frequency = 5;
        yield return new WaitForSeconds(0.1f);
        springJoint.dampingRatio = 1;
        springJoint.frequency = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
            if (box_type == 1 && isActiveBox == false)
            {
                //Else disable bounce 
                springJoint.dampingRatio = 0;
                springJoint.frequency = 0;
            }
            else if (springJoint.connectedBody.position.y > player.transform.position.y + threshold)
            {
                if (isActiveBox == true)
                {
                    // Enable Bounce
                    springJoint.dampingRatio = 0.3f;
                    springJoint.frequency = 10;

                    if (box_type == 1)
                    {
                        qboxAnimator.SetTrigger("qbox_used");
                        StartCoroutine(GradualDisableBounce());
                    }
                    if (box_type == 1 || box_type == 2)
                    {
                        coinAnimator.SetTrigger("coin_bounce_trigger");
                        PlayCoinSound();
                    }
                }
                

                // reset animation
                isActiveBox = false;
            }
            else
            {
                springJoint.dampingRatio = 0;
                springJoint.frequency = 0;
            }
            
    }
        
    void PlayCoinSound()
    {
        // play jump sound
        coinAudioSource.PlayOneShot(coinAudioSource.clip);
    }
}
