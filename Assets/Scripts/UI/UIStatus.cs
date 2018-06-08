using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    public Button btnSetAgents;
    public Button btnSetTime;
    public Button btnCaptureFrame;
    public Button btnCaptureFrameWithDijkstra;
    public Button btnCaptureFrameWithAStar;

    public void SetComponentsStatus(bool status)
    {
        btnSetAgents.enabled = status;
        btnSetTime.enabled = status;
        btnCaptureFrame.enabled = status;
        btnCaptureFrameWithDijkstra.enabled = status;
        btnCaptureFrameWithAStar.enabled = status;
    }
}