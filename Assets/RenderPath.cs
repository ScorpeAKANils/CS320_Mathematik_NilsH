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
    public float yPosBase;
    private LineRenderer lineRenderer;
    public Vector3[] positions;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        positions = new Vector3[numberOfPoints];
        yPosBase = transform.position.y;
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
            float xPos = startPosition.x + (i + speed * Time.deltaTime);
            float yPos = Mathf.Sin((xPos + Time.time) * frequenz) * WaveHeight;

            positions[i] = new Vector3(xPos, yPos, startPosition.z);
        }

        RenderLine();
    }

    public void AufgabeEinsBRenderer()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = startPosition.x + i * timeInterval * speed;
            float yPos = Mathf.Sin((xPos + Time.time) * frequenz) * WaveHeight;
            float yAbleitung = Mathf.Cos((xPos + Time.time) * frequenz) * frequenz * WaveHeight;
            float newY = yPos - (yAbleitung * slopeSpeedFactor * timeInterval);
            positions[i] = new Vector3(xPos, newY, startPosition.z);
        }

        RenderLine();
    }



    public void AufgabeEinsCRenderer()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = startPosition.x + i * timeInterval * speed;
            float yPos = Mathf.Sin((xPos + Time.time) * frequenz) * WaveHeight;
            float yAbleitung = Mathf.Cos((xPos + Time.time * speed) * frequenz) * frequenz * WaveHeight;
            float newY = yPos - (yAbleitung * slopeSpeedFactor * timeInterval);
            positions[i] = new Vector3(xPos, newY, startPosition.z);
        }

        RenderLine();
    }


    public void AufgabeZweiARenderer()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = startPosition.x;
            float zPos = startPosition.z + i * timeInterval * speed;
            float yPos = Mathf.Cos(xPos + Time.time) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time) * WaveHeight;
            float newY = yPos;
            positions[i] = new Vector3(xPos, newY, zPos);
        }

        RenderLine();
    }

    public void AufgabeZweiBRenderer()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = startPosition.x + i * timeInterval * speed;
            float zPos = startPosition.z + i * timeInterval * speed;
            float yPos = Mathf.Cos(xPos + Time.time) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time) * WaveHeight;
            float newY = yPos;
            positions[i] = new Vector3(xPos, newY, zPos);
        }

        RenderLine();
    }

    public void AufgabeZweiCRenderer()
    {
        Vector3 startPosition = transform.position;
        float deltaTime = Time.deltaTime;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float xPos = startPosition.x + i * timeInterval * speed;
            float zPos = startPosition.z + i * timeInterval * speed;

            float yPos = Mathf.Cos(xPos + Time.time) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time) * WaveHeight;
            
            float yAbleitungX = -Mathf.Sin(xPos + Time.time * speed) * (0.25f * xPos) * WaveHeight;
            float yAbleitungZ = Mathf.Cos(zPos + Time.time * speed) * WaveHeight;
            float newY = yPos - (yAbleitungX * slopeSpeedFactor * deltaTime) - (yAbleitungZ * slopeSpeedFactor * deltaTime);

            positions[i] = new Vector3(xPos, newY, zPos);
        }

        RenderLine();
    }



}
