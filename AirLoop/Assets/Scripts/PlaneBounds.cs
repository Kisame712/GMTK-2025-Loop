using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneBounds : MonoBehaviour
{
    [SerializeField] private GameObject warningText;
    [SerializeField] private float warningDistance;
    PlaneController plane;


    private void Awake()
    {
        plane = FindFirstObjectByType<PlaneController>();
    }

    private void Update()
    {
        SetWarningText();
    }

    private void SetWarningText()
    {
        float distanceFromLeftWall = Vector3.Distance(plane.transform.position, new Vector3(plane.transform.position.x, plane.transform.position.y, -5000f));
        float distanceFromRightWall = Vector3.Distance(plane.transform.position, new Vector3(plane.transform.position.x, plane.transform.position.y, 5000f));
        float distanceFromFrontWall = Vector3.Distance(plane.transform.position, new Vector3(5000f, plane.transform.position.y, plane.transform.position.x));
        float distanceFromBackWall = Vector3.Distance(plane.transform.position, new Vector3(-5000f, plane.transform.position.y, plane.transform.position.x));

        float minDistanceBetweenAllWalls = Mathf.Min(distanceFromLeftWall, distanceFromRightWall, distanceFromFrontWall, distanceFromBackWall);

        if(minDistanceBetweenAllWalls < warningDistance)
        {
            warningText.SetActive(true);
        }
        else
        {
            warningText.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
