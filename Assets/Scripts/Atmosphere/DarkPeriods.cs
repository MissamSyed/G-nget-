using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DarkPeriods : MonoBehaviour
{
    private bool _darkMode = false;

    private Camera camera;
    private Color cameraBackgroundColor;
    private Coroutine flickerCoroutine;

    public bool GetDarkMode()
    {
        return _darkMode;
    }

    private void Start()
    {
        camera = Camera.main;
        cameraBackgroundColor = camera.backgroundColor;
        StartCoroutine(ColorLoop());
    }

    IEnumerator ColorLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            flickerCoroutine = StartCoroutine(LightFlicker(0.2f));
            yield return new WaitForSeconds(2f);

            StopCoroutine(flickerCoroutine);
            flickerCoroutine = StartCoroutine(LightFlicker(0.05f));

            yield return new WaitForSeconds(1f);

            StopCoroutine(flickerCoroutine);
            camera.backgroundColor = Color.black;
            _darkMode = true;

            yield return new WaitForSeconds(2f);
            camera.backgroundColor = cameraBackgroundColor;
            _darkMode = false;
        }
    }

    IEnumerator LightFlicker(float flickTime)
    {
        while (true)
        {
            camera.backgroundColor = Color.gray;
            yield return new WaitForSeconds(flickTime);
            camera.backgroundColor = cameraBackgroundColor;
            yield return new WaitForSeconds(flickTime);
        }
    }
}
