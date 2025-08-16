using UnityEngine;

public class PencilDrawer : MonoBehaviour
{
    public LineRenderer linePrefab;
    public LayerMask boardLayer;
    public float drawDistance = 0.01f;

    private LineRenderer currentLine;
    private bool isDrawing = false;
    private Transform tip;

    void Start()
    {
        tip = transform.Find("Tip"); // Create a child object at the pencil tip
    }

    void Update()
    {
        Debug.DrawRay(tip.position, tip.forward * drawDistance, Color.red);

        if (tip == null) return;

        if (Physics.Raycast(tip.position, tip.forward, out RaycastHit hit, drawDistance, boardLayer))
        {
            if (!isDrawing)
            {
                StartDrawing(hit.point);
            }
            else
            {
                AddPoint(hit.point);
            }
        }
        else
        {
            StopDrawing();
        }
    }

    void StartDrawing(Vector3 startPoint)
    {
        isDrawing = true;
        currentLine = Instantiate(linePrefab);
        currentLine.positionCount = 1;
        currentLine.SetPosition(0, startPoint);
    }

    void AddPoint(Vector3 point)
    {
        if (currentLine == null) return;

        int posCount = currentLine.positionCount;
        if (posCount == 0 || Vector3.Distance(currentLine.GetPosition(posCount - 1), point) > 0.005f)
        {
            currentLine.positionCount++;
            currentLine.SetPosition(posCount, point);
        }
    }

    void StopDrawing()
    {
        isDrawing = false;
        currentLine = null;
    }
}
