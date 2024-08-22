using UnityEngine;

public enum Aufgaben
{
    einsA,
    einsB,
    einsC,
    zweiA,
    zweiB,
    zweiC,
}

public class MathePruefung : MonoBehaviour
{
    public float frequenz;
    public float WaveHeight;
    public float speed = 1;
    public RenderPath render;
    public Aufgaben curAuf = Aufgaben.einsA;
    [Range(0, 1)]
    public float slopeSpeedFactor = 1;

    private void Update()
    {
        switch (curAuf)
        {
            case Aufgaben.einsA:
                AufgabeEinsA();
                render.AufgabeEinsARenderer();
                break;
            case Aufgaben.einsB:
                AufgabeEinsB();
                render.AufgabeEinsBRenderer();
                break;
            case Aufgaben.einsC:
                AufgabeEinsC();
                render.AufgabeEinsCRenderer();
                break;
            case Aufgaben.zweiA:
                AufgabeZweiA();
                render.AufgabeZweiARenderer();
                break;
            case Aufgaben.zweiB:
                AufgabeZweiB();
                render.AufgabeZweiBRenderer();
                break;
            case Aufgaben.zweiC:
                AufgabeZweiC();
                render.AufgabeZweiCRenderer();
                break;
        }
    }

    public void AufgabeEinsA()
    {
        float xPos = transform.position.x + speed * Time.deltaTime;
        float newYPos = Mathf.Sin((xPos + Time.time) * frequenz) * WaveHeight;
        transform.position = new Vector3(xPos, newYPos, transform.position.z);
    }

    public void AufgabeEinsB()
    {
        float xPos = transform.position.x + speed * Time.deltaTime;
        float yPos = Mathf.Sin((xPos + Time.time) * frequenz) * WaveHeight;
        float yAbleitung = Mathf.Cos((xPos + Time.time) * frequenz) * frequenz * WaveHeight;
        float newY = yPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);
        transform.position = new Vector3(xPos, newY, transform.position.z);
    }

    public void AufgabeEinsC()
    {
        float xPos = transform.position.x + speed * Time.deltaTime;
        float zPos = transform.position.z;
        float yPos = Mathf.Sin((xPos + Time.time) * frequenz) * WaveHeight;
        float yAbleitung = Mathf.Cos((xPos + Time.time * speed) * frequenz) * frequenz * WaveHeight;

        float newRotationZ = Mathf.Atan2(yAbleitung, 1) * Mathf.Rad2Deg;
        float newY = yPos - (yAbleitung * slopeSpeedFactor * Time.deltaTime);

        Vector3 lastPos = transform.position;
        transform.position = new Vector3(xPos, newY, zPos);
        Vector3 dir = transform.position - lastPos;
        transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.down);
    }

    public void AufgabeZweiA()
    {
        float xPos = transform.position.x;
        float zPos = transform.position.z + speed * Time.deltaTime;
        float newYPos = Mathf.Cos(xPos + Time.time) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time) * WaveHeight;
        transform.position = new Vector3(xPos, newYPos, zPos);
    }

    public void AufgabeZweiB()
    {
        float xPos = transform.position.x + speed * Time.deltaTime;
        float zPos = transform.position.z + speed * Time.deltaTime;
        float yPos = Mathf.Cos(xPos + Time.time) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time) * WaveHeight;
        float yAbleitungX = -Mathf.Sin(xPos + Time.time) * (0.25f * xPos) * WaveHeight;
        float yAbleitungZ = Mathf.Cos(zPos + Time.time) * WaveHeight;
        float newY = yPos - (yAbleitungX * slopeSpeedFactor * Time.deltaTime) - (yAbleitungZ * slopeSpeedFactor * Time.deltaTime);
        transform.position = new Vector3(xPos, newY, zPos);
    }

    public void AufgabeZweiC()
    {
        float xPos = transform.position.x + speed * Time.deltaTime;
        float zPos = transform.position.z + speed * Time.deltaTime;
        float yPos = Mathf.Cos(xPos + Time.time) * (0.25f * xPos) + Mathf.Sin(zPos + Time.time) * WaveHeight;
        float yAbleitungX = -Mathf.Sin(xPos + Time.time) * (0.25f * xPos) * WaveHeight;
        float yAbleitungZ = Mathf.Cos(zPos + Time.time) * WaveHeight;

        float newRotationX = Mathf.Atan2(yAbleitungZ, 1) * Mathf.Rad2Deg;
        float newRotationZ = Mathf.Atan2(yAbleitungX, 1) * Mathf.Rad2Deg;
        float newY = yPos - (yAbleitungX * slopeSpeedFactor * Time.deltaTime) - (yAbleitungZ * slopeSpeedFactor * Time.deltaTime);

        Vector3 lastPos = transform.position;
        transform.position = new Vector3(xPos, newY, zPos);
        Vector3 dir = transform.position - lastPos;
        transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.down);
    }
}
