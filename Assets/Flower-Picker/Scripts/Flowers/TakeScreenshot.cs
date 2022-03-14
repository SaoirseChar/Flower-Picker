using System;
using System.IO;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    [Header("Screen Capture")]
    private string directoryName = "Screenshots";
    private string screenshotName = "TestImage.png";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SaveScreenshotToDocuments();
            print("Image saved!");
        }
    }

    public void SaveScreenshotToDocuments()
    {
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string screenshotPath = Path.Combine(documentsPath, Application.productName, directoryName);

        DirectoryInfo screenshotDirectory = Directory.CreateDirectory(screenshotPath);
        ScreenCapture.CaptureScreenshot(Path.Combine(screenshotDirectory.FullName, screenshotName));
    }
}