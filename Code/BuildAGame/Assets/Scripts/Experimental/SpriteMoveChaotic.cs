using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMoveChaotic : MonoBehaviour
{
    // Reset my oscillator. This is like a heartbeat

    [Range(-5.0f, 5.0f)]
    [SerializeField] float kValue;

    [SerializeField] float timeToShift;

    [SerializeField] Transform positionRef;

    private float xNext = .00001f;

    private float timePassed;

    private float lastKValue;

    private void Start()
    {
        lastKValue = kValue;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (lastKValue != kValue)
        {
            lastKValue = kValue;
            xNext = .00001f;
        }

        if (timePassed >= timeToShift)
        {
            timePassed = 0.0f;
            //ChaoticOne();
            //ChaoticTwo();
            ChaoticThree();
        }
    }

    private void ChaoticOne()
    {
        float result = kValue * xNext * (1 - xNext);
        xNext = result;

        positionRef.position = new Vector3(positionRef.position.x, result, positionRef.position.z);
    }

    private void ChaoticTwo()
    {
        // Good beats at a value of .3
        float result = -kValue * kValue - xNext - kValue;
        xNext = result;

        positionRef.position = new Vector3(positionRef.position.x, result, positionRef.position.z);
    }

    private void ChaoticThree()
    {
        // .727 kValue
        // THIS ONE!
        float result = xNext * xNext - xNext - kValue;
        xNext = result;

        positionRef.position = new Vector3(positionRef.position.x, result, positionRef.position.z);
    }
}
