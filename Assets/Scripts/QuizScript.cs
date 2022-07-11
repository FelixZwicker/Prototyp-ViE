using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizScript : MonoBehaviour
{
    public void TubeOne()
    {
        StartCoroutine(SolvedWrong());
    }

    public void TubeTwo()
    {
        StartCoroutine(SolvedWrong());
    }

    public void TubeThree()
    {
        StartCoroutine(SolvedRight());
    }

    public void TubeFour()
    {
        StartCoroutine(SolvedWrong());
    }

    IEnumerator SolvedRight()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("QuizRight");
    }

    IEnumerator SolvedWrong()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("QuizWrong");
    }
}
