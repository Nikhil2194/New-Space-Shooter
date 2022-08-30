using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakemagnitude = 0.5f;

    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        { 
        transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakemagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}
