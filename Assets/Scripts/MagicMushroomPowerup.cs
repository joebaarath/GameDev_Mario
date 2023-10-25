
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroomPowerup : BasePowerup
{
    private bool isInitialValuesSet = false;
    private Vector3 initialPosition;
    private Vector2 initialVelocity;

    
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.MagicMushroom;

        if(isInitialValuesSet == false)
        {
            //initialPosition = this.gameObject.transform.position;
            initialPosition = new Vector3(0,0,0);
            initialVelocity = Vector2.zero;
            //initialVelocity = rigidBody.velocity;
            isInitialValuesSet = true;
        }


        this.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision detected with " + col.gameObject.name);
        if (col.gameObject.CompareTag("Player") && spawned)
        {
            // TODO: do something when colliding with Player

            // then destroy powerup (optional)
            DestroyPowerup();

        }
        else if (col.gameObject.layer == 7 || col.gameObject.layer == 11) // else if hitting Pipe, flip travel direction
        {
            Debug.Log("Rigidbody velocity: " + rigidBody.velocity);
            if (spawned)
            {
                goRight = !goRight;
                rigidBody.AddForce(Vector2.right * 2 * (goRight ? 1 : -1), ForceMode2D.Impulse);

            }
        }
    }

    public override void ResetPowerup()
    {
        this.gameObject.SetActive(true);

        this.transform.localPosition = initialPosition;
        rigidBody.velocity = initialVelocity;

        // Other optional resets like making it invisible or inactive can go here
        spawned = false;
        rigidBody.simulated = false;
    }

    // interface implementation
    public override void SpawnPowerup()
    {
        if (spawned == false)
        {
            spawned = true;
            rigidBody.simulated = true;
            rigidBody.AddForce(Vector2.right * 2, ForceMode2D.Impulse); // move to the right
            Debug.Log("Rigidbody velocity: " + rigidBody.velocity);
        }
        
    }


    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object
        PlayerMovement mario;
        bool result = i.TryGetComponent<PlayerMovement>(out mario);
        if (result)
        {
            //mario.MakeSuperMario();
        }

    }


}