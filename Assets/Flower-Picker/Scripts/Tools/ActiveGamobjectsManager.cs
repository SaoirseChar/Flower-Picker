using UnityEngine;

namespace FlowerPicker.Tools
{
    public class ActiveGamobjectsManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            TurnOnOrOffOnPlay[] onOffs = FindObjectsOfType<TurnOnOrOffOnPlay>();

            foreach(TurnOnOrOffOnPlay onOff in onOffs)
                onOff.TryActivate();
        }
    }
}