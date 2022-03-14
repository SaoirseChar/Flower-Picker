using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private static readonly int _start = Animator.StringToHash("Start");

    void Update()
    {
        //Go to bouquet making menu
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        //Return to flower picking
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        }
    }

    private IEnumerator LoadLevel(int _levelIndex)
    {
        //Play anim
        transition.SetTrigger(_start);

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(_levelIndex);
    }
    
    private IEnumerator ReturnLevel(int _levelIndex)
    {
        //Play anim
        transition.SetTrigger(_start);

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(_levelIndex);
    }
}
