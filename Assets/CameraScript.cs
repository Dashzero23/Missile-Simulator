using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CameraScript : MonoBehaviour
{
    public Transform missile;
    public float updateInterval = 2f;
    private Vector3 targetPosition;
    public Canvas canvas;

    void Start()
    {
        targetPosition = missile.position;
        StartCoroutine(UpdateTargetPosition());
        canvas.enabled = false;
    }

    void FixedUpdate()
    {
        if (missile)
        {
            transform.LookAt(missile);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        }
        else if(canvas.enabled == false)
        {
            canvas.enabled = true;
        }
    }

    IEnumerator UpdateTargetPosition()
    {
        while (missile)
        {
            targetPosition = missile.position;
            yield return new WaitForSeconds(updateInterval);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
