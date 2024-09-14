using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;
    public float dayLength = 120f; // 2 minutes pour un cycle de 24 heures.
    private float currentTime = 0f;

    void Update()
    {
        currentTime += Time.deltaTime;
        float dayPercentage = currentTime / dayLength;
        float sunAngle = Mathf.Lerp(-90, 270, dayPercentage);
        sun.transform.rotation = Quaternion.Euler(sunAngle, 0, 0);

        if (currentTime >= dayLength)
        {
            currentTime = 0f; // Réinitialisation du cycle.
        }

        sun.intensity = Mathf.Clamp01(Mathf.Sin(sunAngle * Mathf.Deg2Rad)); // Variation de l'intensité du soleil.
    }
}
