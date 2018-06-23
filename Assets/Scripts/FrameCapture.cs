using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Utility class to capture the frames in an time interval and show the result average on the screen
/// </summary>
public class FrameCapture : MonoBehaviour
{
    /// <summary>
    /// Flag to determine if is to capture the frames or not
    /// </summary>
    public bool capture;

    /// <summary>
    /// The total time that the code needs to capture the frames
    /// </summary>
    public float timeToCapture;

    /// <summary>
    /// Reference to the interface's FPS text
    /// </summary>
    public Text fpsText;

    /// <summary>
    /// Reference to the interface's input time
    /// </summary>
    public InputField inputTime;

    /// <summary>
    /// List of A Star agents
    /// </summary>
    public List<TestAStar> aStarAgents;

    /// <summary>
    /// List of Dijkstra agents
    /// </summary>
    public List<TestDijkstra> dijkstraAgents;

    /// <summary>
    /// The description of the current algorithm being executed
    /// </summary>
    private string algorithm;

    /// <summary>
    /// The total time capturing frames
    /// </summary>
    private float timeCapturing;

    /// <summary>
    /// A collection to hold the frame average on each frame
    /// </summary>
    private List<float> fpsCollection;

    /// <summary>
    /// The final FPS average
    /// </summary>
    private float fpsAverage;

    /// <summary>
    /// The final frame count
    /// </summary>
    private int frameCount;

    private void Start()
    {
        fpsCollection = new List<float>();
        timeToCapture = 3f;
        timeCapturing = 0f;
        frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (capture)
        {
            timeCapturing += Time.deltaTime;
            if (timeCapturing >= timeToCapture)
            {
                capture = false;
                ShowResult();
                UIStatus.Get.SetComponentsStatus(true);

                frameCount = 0;
                timeCapturing = 0f;
                fpsCollection.Clear();

                aStarAgents.ForEach(x => x.execute = false);
                dijkstraAgents.ForEach(x => x.execute = false);

                return;
            }

            fpsCollection.Add((1f / Time.unscaledDeltaTime));
            frameCount++;
        }
    }

    /// <summary>
    /// Show the frame average after collect the data from the execution
    /// </summary>
    private void ShowResult()
    {
        fpsAverage = fpsCollection.Sum(x => x) / frameCount;

        string capture = algorithm != null ? string.Format("Captura do algoritmo {0} finalizada!", algorithm) : "Captura sem algoritmo finalizada!";
        fpsText.text = capture + string.Format("\nTempo capturado: {0} seg.\nMédia de frames: {1}\nNúmero de agentes: {2}", timeCapturing.ToString("f2"), fpsAverage.ToString("f2"), AgentUtility.agentCount);
    }

    /// <summary>
    /// Used by the interface to set the flag capture to true, to start the capture
    /// </summary>
    public void Capture()
    {
        algorithm = null;
        fpsText.text = "Capturando média de frames...";

        capture = true;
    }

    /// <summary>
    /// Used by the interface to set the flag capture to true, to start the capture
    /// </summary>
    /// <param name="algorithmDescription">The description of the algorithm being executed</param>
    public void Capture(string algorithmDescription)
    {
        algorithm = algorithmDescription;
        fpsText.text = "Capturando média de frames...";

        capture = true;
    }

    /// <summary>
    /// Used by the interface to set the total time to capture the average frame
    /// </summary>
    public void SetTime()
    {
        timeToCapture = string.IsNullOrEmpty(inputTime.text) ? 3f : float.Parse(inputTime.text);

        inputTime.text = string.Empty;
    }
}