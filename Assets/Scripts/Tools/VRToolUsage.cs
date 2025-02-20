using UnityEngine;

public class VRToolUsage : MonoBehaviour
{
    public bool starting;
    public OVRInput.Controller whichHand;
    public GameObject currentHandToolObject;
    public GameObject otherHandToolObject;
    private ITool currentTool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(currentHandToolObject.TryGetComponent(out ITool newTool))
        {
            currentTool = newTool;
        }
        if (starting)
        {
            currentHandToolObject.SetActive(true);
            otherHandToolObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,whichHand))
        {
            currentHandToolObject.SetActive(true);
            currentTool.Main();
            otherHandToolObject.SetActive(false);
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, whichHand))
        {
            currentTool.UpMain();
        }
    }
}
