using Sirenix.OdinInspector;
using Unity.Collections;
using UnityEngine;

namespace FlowerPicker.Environment
{
    /// <summary>
    /// Make sure the skybox "sun" and the directional light are aligned.
    /// HOW TO USE: https://ibb.co/nfMDSXh
    /// </summary>
    public class SkyAnim : MonoBehaviour
    {
        [Header("How to use")] [SerializeField] [Sirenix.OdinInspector.ReadOnly] private string guideURL = "https://ibb.co/nfMDSXh";
        [Header("The material used for the Skybox")] [SerializeField] private Material skyboxMat;
        [Header("Directional Light Rotation Point")] [SerializeField] private GameObject directionalLight;
        [Header("Speed the light and skybox to rotates at")]
        [SerializeField] private float rotationSpeed = 0.02f;
        private float currentSkyboxRotation;
        private float originalSkyboxRotation;
        private Vector3 currentDirectionalLightRotation;
        private Vector3 originalDirectionalLightRotation;
        private Transform directionalLightTransform;

        private void Start()
        {
            
            // Get the Current Skybox Rotation.
            currentSkyboxRotation = skyboxMat.GetFloat("_Rotation");
            
            
            // Make the directional ligh transform = normal light transform (so we dont need to get it every frame)
            directionalLightTransform = directionalLight.transform;
            
            // Get the current Directional light parent Game Object rotation.
            currentDirectionalLightRotation = directionalLightTransform.rotation.eulerAngles;
            
            SaveOriginalLightAndSkyboxRotations(currentSkyboxRotation,currentDirectionalLightRotation);
        }

        private void SaveOriginalLightAndSkyboxRotations(float _skyboxRotation, Vector3 _directional)
        {
            // Saving the original Skybox Rotation, to change back to when we close the application.
            originalSkyboxRotation = currentSkyboxRotation;
            // Saving the original Light Rotation, to change back to  when we close the application.
            originalDirectionalLightRotation = currentDirectionalLightRotation;
        }

        private void Update() {
            // Set the skybox rotation the the current rotation.
            skyboxMat.SetFloat("_Rotation", currentSkyboxRotation);
            // Set the Directional Light Parent Game Object rotation the the current rotation.
            directionalLightTransform.eulerAngles = currentDirectionalLightRotation;
            // Get the ammount for both objects to rotate.
            float rotationAmmount = (rotationSpeed * Time.deltaTime * 10f);
            // Rotate float that the skybox is to rotate by.
            currentSkyboxRotation += rotationAmmount;
            // Get the ammount the Light is to rotate by
            currentDirectionalLightRotation = new Vector3(currentDirectionalLightRotation.x, currentDirectionalLightRotation.y, currentDirectionalLightRotation.z + rotationAmmount);
        }

        private void OnApplicationQuit()
        {
            // Set the Directional Light Parent Game Object rotation the the original rotation.
            directionalLightTransform.eulerAngles = originalDirectionalLightRotation;
            // Set the skybox rotation the the original rotation.
            skyboxMat.SetFloat("_Rotation", originalSkyboxRotation);
        }
    }
}