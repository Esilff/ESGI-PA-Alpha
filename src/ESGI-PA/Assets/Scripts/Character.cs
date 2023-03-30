using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public new string name;
    public string description;

    public void move(int direction, Rigidbody rb)
    {
        Debug.Log("Moving to : " + direction);
        
        
    }


    public void turn(int direction, Rigidbody rb)
    {
        Debug.Log("Turning to : " + direction);
        rb.AddForce(new Vector3(direction * Time.deltaTime * 500, 0, 0));
    }

    public void specialAction()
    {
        Debug.Log("Dashing");
    }

    public void bonus()
    {
        Debug.Log("Using bonus");
    }

    public void behave(Rigidbody rb, Vector2 movement)
    {
        rb.AddForce(new Vector3(movement.x * Time.deltaTime * 500,0, movement.y * Time.deltaTime * 1000));
    }
}
