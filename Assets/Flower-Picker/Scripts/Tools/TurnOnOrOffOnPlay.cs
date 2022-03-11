using UnityEngine;

namespace FlowerPicker.Tools
{
    public class TurnOnOrOffOnPlay : MonoBehaviour
    {
        private enum OnOrOffOnPlay { On, Off }

        [Header("Active status of this GameObject on play")] [SerializeField]
        private OnOrOffOnPlay turnOnOrOff = OnOrOffOnPlay.Off;
        
        public void TryActivate() => this.gameObject.SetActive(turnOnOrOff == OnOrOffOnPlay.On);
        
    }
}