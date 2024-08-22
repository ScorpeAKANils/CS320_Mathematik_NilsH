using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPath : MonoBehaviour
{
    public float speed = 1.0f;
    public float frequenz = 1.0f;
    public float WaveHeight = 1.0f;
    public float slopeSpeedFactor = 0.1f;
    public int numberOfPoints = 100;
    public float timeInterval = 0.1f;

    private LineRenderer lineRenderer;
    private Vector3[] positions;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        positions = new Vector3[numberOfPoints];
    }
    private void Update()
    {
        timeInterval = Time.deltaTime;
    }
    private void RenderLine()
    {
        lineRenderer.SetPositions(positions);
    }

    public void AufgabeEinsARenderer()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = i * timeInterval;
            float yPos = Mathf.Sin((xPos + Time.time * speed) * frequenz) * WaveHeight;
            positions[i] = startPosition + new Vector3(xPos, yPos, 0);
        }

        RenderLine();
    }

    public void AufgabeEinsBRenderer()
    {
        Vector3 startPosition = transform.position;
        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = i * timeInterval;
            float yPos = Mathf.Sin((xPos + Time.time * speed) * frequenz) * WaveHeight;
            float yAbleitung = Mathf.Cos((xPos + Time.time * speed) * frequenz) * frequenz * WaveHeight;
            float newY = yPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);
            positions[i] = startPosition + new Vector3(xPos + speed * Time.deltaTime, newY, 0);
        }

        RenderLine();
    }

    public void AufgabeEinsCRenderer()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = i * timeInterval;
            float yPos = Mathf.Sin((xPos + Time.time * speed) * frequenz) * WaveHeight;
            float yAbleitung = Mathf.Cos((xPos + Time.time * speed) * frequenz) * frequenz * WaveHeight;
            float neigung = Mathf.Atan(yAbleitung) * Mathf.Rad2Deg;
            float newY = yPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);
            positions[i] = new Vector3(transform.position.x + xPos + speed * Time.deltaTime, newY, 0);
            transform.rotation = Quaternion.Euler(0, 0, neigung);
        }

        RenderLine();
    }

    public void AufgabeZweiARenderer()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = i * timeInterval;
            float zPos = i * timeInterval;
            float yPos = Mathf.Cos(xPos + Time.time * speed) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time * speed) * WaveHeight;
            positions[i] = startPosition + new Vector3(xPos, yPos, zPos + speed * Time.deltaTime);
        }

        RenderLine();
    }

    public void AufgabeZweiBRenderer()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = i * timeInterval;
            float zPos = i * timeInterval;
            float yPos = Mathf.Cos(xPos + Time.time * speed) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time * speed) * WaveHeight;
            float yAbleitungX = -Mathf.Sin(xPos + Time.time * speed) * (0.25f * xPos) * WaveHeight;
            float yAbleitungZ = Mathf.Cos(zPos + Time.time * speed) * WaveHeight;
            float newY = yPos - (yAbleitungX * slopeSpeedFactor * Time.deltaTime) - (yAbleitungZ * slopeSpeedFactor * Time.deltaTime);
            positions[i] = startPosition + new Vector3(xPos + speed * Time.deltaTime, newY, zPos + speed * Time.deltaTime);
        }

        RenderLine();
    }

    public void AufgabeZweiCRenderer()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = i * timeInterval;
            float zPos = i * timeInterval;
            float yPos = Mathf.Cos(xPos + Time.time * speed) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time * speed) * WaveHeight;
            float yAbleitungX = -Mathf.Sin(xPos + Time.time * speed) * (0.25f * xPos) * WaveHeight;
            float yAbleitungZ = Mathf.Cos(zPos + Time.time * speed) * WaveHeight;
            float neigungX = Mathf.Atan(yAbleitungX) * Mathf.Rad2Deg;
            float neigungZ = Mathf.Atan(yAbleitungZ) * Mathf.Rad2Deg;
            float newY = yPos - (yAbleitungX * slopeSpeedFactor * Time.deltaTime) - (yAbleitungZ * slopeSpeedFactor * Time.deltaTime);
            positions[i] = startPosition + new Vector3(xPos + speed * Time.deltaTime, newY, zPos + speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(neigungZ, 0, neigungX);
        }

        RenderLine();
    }
}
