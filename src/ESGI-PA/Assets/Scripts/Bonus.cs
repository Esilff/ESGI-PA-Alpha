using System;
using UnityEngine;


public class Bonus
{
    private static Bonus instance = null;
    
    private Bonus(){}

    public static Bonus Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Bonus();
            }
            return instance;
        }
    }

    private Action<CarStats>[] bonusList = new Action<CarStats>[]
    {
        boost,
        projectile
    };

    private static void boost(CarStats stats)
    {
        Debug.Log("Im a booster");

        // Activer le boost pendant boostDuration secondes
        float boostDuration = 1.5f;
        float boostMultiplier = 1.2f;
        stats.boostMultiplier *= (int)boostMultiplier;
        stats.vehicle.GetComponent<CarController>().StartBoost(boostDuration);
    }

    private static void projectile(CarStats stats)
    {
        Debug.Log("Im a projectile");
        if (stats.projectilePrefab != null)
        {
            GameObject projectile = GameObject.Instantiate(stats.projectilePrefab, stats.vehicle.position, Quaternion.identity);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.velocity = stats.vehicle.forward * stats.projectileVelocity;
        }
    }

    public Action<CarStats> getBonus()
    {
        return bonusList[UnityEngine.Random.Range(0, bonusList.Length)];
    }
}