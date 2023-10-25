
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroomPowerup : BasePowerup
{
    // setup this object's type
    // instantiate variables
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.MagicMushroom;
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
                rigidBody.AddForce(Vector2.right * 3 * (goRight ? 1 : -1), ForceMode2D.Impulse);

            }
        }
    }

    // interface implementation
    public override void SpawnPowerup()
    {
        if (spawned == false)
        {
            spawned = true;
            rigidBody.simulated = true;
            rigidBody.AddForce(Vector2.right * 3, ForceMode2D.Impulse); // move to the right
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