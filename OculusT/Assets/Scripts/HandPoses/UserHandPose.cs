using UnityEngine;

public partial class UserHandPose : MonoBehaviour
{
    public bool isLeftHand;
    private bool lIndex;
    private bool lHand;
    private bool rIndex;
    private bool rHand;
    private HandPose _pose;

    public HandPose GetHandPose()
    {
        return _pose;
    }


    void Update()
    {
        lIndex = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
        lHand = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
        rIndex = OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        rHand = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

        if (isLeftHand)
        {
            //Left Punch
            if (lIndex && lHand)
            {
                _pose = HandPose.LPunch;
                //Debug.Log("LeftPunch");
            }

            //Left Poke
            if (!(lIndex) && lHand)
            {
                _pose = HandPose.LPoke;
                //Debug.Log("LeftPoke");
            }

            //Left Palm
            if (!(lIndex) && !(lHand))
            {
                _pose = HandPose.LPalm;
                //Debug.Log("LeftPalm");
            }
        }
        if (!(isLeftHand))
        {
            //Right Punch
            if (rIndex && rHand)
            {
                _pose = HandPose.RPunch;
                //Debug.Log("RightPunch");
            }

            //Right Poke
            if (!(rIndex) && rHand)
            {
                _pose = HandPose.RPoke;
                //Debug.Log("RightPoke");
            }

            //Right palm
            if (!(rIndex) && !(rHand))
            {
                _pose = HandPose.RPalm;
                //Debug.Log("RightPalm");
            }
        }

    }
}
