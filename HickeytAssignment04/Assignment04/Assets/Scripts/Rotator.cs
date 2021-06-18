using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100f;
    public bool reverse = false;

    private void Update()
    {
        float modifier = PlayerPrefs.GetFloat("rotationSpeed");

        if (!reverse)
        {
            transform.Rotate(0f, 0f, (speed * modifier) * Time.deltaTime);
        }

        else
        {
            transform.Rotate(0f, 0f, ((speed * -modifier) * Time.deltaTime));
        }
    }

    public void StartStop()
    {
        if (enabled) enabled = false;
        else enabled = true;
    }

    public IEnumerator ShedPins(Transform[] Pins, GameObject[] PinObjects)
    {
        float PinSpeed = PlayerPrefs.GetFloat("PinSpeed");

        foreach (GameObject Pin in PinObjects)
        {
            Pin.GetComponent<Collider2D>().enabled = false;
        }

        foreach (Transform pin in Pins)
        {
            pin.localPosition = Vector2.Lerp(transform.position, GetClosestDirection(pin).position, PinSpeed/100 * Time.deltaTime);
            foreach (Transform child in pin)
            {
                Destroy(child.gameObject);
            }
            yield return new WaitForSeconds(0.25f);
        }

        StartStop();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("ExitScene");
    }

    Transform GetClosestDirection(Transform Child)
    {
        GameObject[] DirectionObjects;
        Transform closestDirection = null;
        float closestDistanceSqr = Mathf.Infinity;
        DirectionObjects = GameObject.FindGameObjectsWithTag("Direction");
        Transform[] Directions = new Transform[DirectionObjects.Length];

        for (int i = 0; i < DirectionObjects.Length; i++)
        {
            Directions[i] = DirectionObjects[i].transform;
        }

        foreach (Transform potentialDirection in Directions)
        {
            Vector2 directionToTarget = potentialDirection.position - Child.position;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestDirection = potentialDirection;
            }
        }

        return closestDirection;
    }
}
