using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public struct CarStats
{
    public float acceleration;
    public int backAcceleration;
    public float turnStrength;
    public float driftStrength;
    public float weight;
    public int boostMultiplier;
    public float boostDuration;
    public GameObject projectilePrefab; 
    public float projectileVelocity; 
    public float projectileCooldown; 
    public string[] bonus; 
    public Transform vehicle;

}

public class CarController : MonoBehaviour
{
    private const int SPEED_MULTIPLIER = 100000;
    private const int ROTATE_MULTIPLIER = 100;

    [SerializeField] private CarStats Stats;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Rigidbody rigidbody;
    
    
    
    
    private Vector2 input = Vector2.zero;
    private bool isGrounded;
    private bool canRotateInAir;
    private RaycastHit _ground;
    private bool isDrifting;
    private float carSmooth = 0.75f;
    private bool usingBonus = false;

    private Ray[] disabledRays;

    private event Action<CarStats> useBonus;
    /*private bool isBoosting;
    private float boostTimer;
    private float projectileTimer;
	private string bonusValue;*/

    private float speed;
    void Start()
    {
        
    }

    private void Awake()
    {
        _input.SwitchCurrentActionMap("Vehicle");
    }

    void Update()
    {
        input = _input.actions["Movement"].ReadValue<Vector2>();
            isDrifting = _input.actions["Drift"].IsPressed();
            usingBonus = _input.actions["Boost"].IsPressed();
            speed = input.y switch
            {
                >0 => Stats.acceleration,
                <0 => -Stats.backAcceleration,
                _ => 0
            };
            if (usingBonus && useBonus != null)
            {
                useBonus(Stats);
                useBonus = null;
            }
    }

    private void FixedUpdate()
    {
            rigidbody.AddForce(Vector3.down * Stats.weight, ForceMode.Acceleration);
        isGrounded = Physics.Raycast(new Ray(transform.position + new Vector3(0,0,0.5f), -Stats.vehicle.up), out _ground, 2f);
        canRotateInAir = Physics.Raycast(new Ray(transform.position , -Stats.vehicle.up), out _, 10f);
        
        if (isGrounded)
        {
            Debug.Log("Is grounded");
            //int boostMultiplier = isBoosting ? Stats.boostMultiplier : 1;
            rigidbody.AddForce(Stats.vehicle.forward * (speed * Time.deltaTime * SPEED_MULTIPLIER));
            //rigidbody.AddRelativeForce(new Vector3(0,0 , playerOutput.y * SPEED_MULTIPLIER * 
             //                                            ((playerOutput.y > 0) ? Stats.acceleration : Stats.backAcceleration) * Time.deltaTime * boostMultiplier));
            transform.Rotate(Vector3.up * (ROTATE_MULTIPLIER * input.x * Stats.turnStrength * Time.deltaTime * (isDrifting?Stats.driftStrength:1) * Math.Min(rigidbody.velocity.magnitude, 1)));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(transform.up, _ground.normal) * transform.rotation, carSmooth);
            if (input == Vector2.zero) rigidbody.angularVelocity = Vector3.zero;
        }
        else if (!canRotateInAir)
        {
            carSmooth = 0.25f;
            transform.Rotate(-Vector3.forward * (input.x * 2));
            transform.Rotate(-Vector3.right * (input.y * 2));
            rigidbody.angularVelocity = Vector3.zero;
        }
        else
        {
            if (!isGrounded && Mathf.Abs(rigidbody.velocity.y) <= 0.001)
            {
                Debug.Log("Unable to move");
                transform.rotation = Quaternion.Euler(0,transform.rotation.y,0);
            }
        }
    }

    private IEnumerator ResetCarSmooth()
    {
        yield return new WaitForSeconds(0.5f);
        carSmooth = 0.75f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus"))
        {
            other.GetComponent<BonusBox>().IsTaken = true;
            Debug.Log("Is a bonus : True" );
            useBonus += Bonus.Instance.getBonus();
        }
    }	
    public void StartBoost(float duration)
    {
        StartCoroutine(Boost(duration));
    }

    private IEnumerator Boost(float duration)
    {
        float originalAcceleration = Stats.acceleration;
        float originalTurnStrength = Stats.turnStrength;
        Stats.acceleration *= 2;
        Stats.turnStrength *= 2;
        yield return new WaitForSeconds(duration);
        Stats.acceleration = originalAcceleration;
        Stats.turnStrength = originalTurnStrength;
    }
}
