using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    private static UIStatus instance;

    public static UIStatus Get
    {
        get
        {
            return instance;
        }
    }

    public Text lblInformations;
    public Text lblResults;
    public Button btnSetAgents;
    public Button btnSetTime;
    public Button btnCaptureFrame;
    public Button btnCaptureFrameWithDijkstra;
    public Button btnCaptureFrameWithAStar;
    public Toggle tglShowPath;
    public Button btnSingleDijkstraExecution;
    public Button btnSingleAStarExecution;
    public InputField inptDijkstraStartNode;
    public InputField inptDijkstraDestinyNode;
    public InputField inptAStarStartNode;
    public InputField inptAStarDestinyNode;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    public void SetComponentsStatus(bool status)
    {
        if (status)
        {
            btnSetAgents.image.color = Color.white;
            btnSetTime.image.color = Color.white;
            btnCaptureFrame.image.color = Color.white;
            btnCaptureFrameWithDijkstra.image.color = Color.white;
            btnCaptureFrameWithAStar.image.color = Color.white;
            tglShowPath.image.color = Color.white;
            btnSingleDijkstraExecution.image.color = Color.white;
            btnSingleAStarExecution.image.color = Color.white;
        }
        else
        {
            btnSetAgents.image.color = Color.gray;
            btnSetTime.image.color = Color.gray;
            btnCaptureFrame.image.color = Color.gray;
            btnCaptureFrameWithDijkstra.image.color = Color.gray;
            btnCaptureFrameWithAStar.image.color = Color.gray;
            tglShowPath.image.color = Color.gray;
            btnSingleDijkstraExecution.image.color = Color.gray;
            btnSingleAStarExecution.image.color = Color.gray;
        }

        btnSetAgents.enabled = status;
        btnSetTime.enabled = status;
        btnCaptureFrame.enabled = status;
        btnCaptureFrameWithDijkstra.enabled = status;
        btnCaptureFrameWithAStar.enabled = status;
        tglShowPath.enabled = status;
        btnSingleDijkstraExecution.enabled = status;
        btnSingleAStarExecution.enabled = status;
    }

    public void SetComponentText(Text element, string text)
    {
        element.text = text;
    }

    public bool ShowMainPathChecked()
    {
        return tglShowPath.isOn;
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}