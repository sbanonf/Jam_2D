using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionManager : MonoBehaviour
{
    public static TransitionManager _instance;
    public Scene scene;
    public int nextScene;
    public float delay;
    [SerializeField] AnimationCurve animationCurve;

    bool animationDone = false;
    [SerializeField] Material material;


    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log(scene.buildIndex);
        if (scene.buildIndex != 0)
        {
            StartCoroutine(CurtainEffectFadeIn(delay));
            Debug.Log(GetAnimationDone());
        }

    }
    private void Update()
    {
        if (scene.buildIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                StartCoroutine(CurtainEffectFadeOut(delay));

            }
            if (GetAnimationDone() == true)
            {
                SceneManager.LoadScene(nextScene);
            }
        }

    }

    public IEnumerator CurtainEffectFadeIn(float _delay)
    {
        Debug.Log("Entre");
        material.SetFloat("_Cutoff", 1);

        for (float i = _delay; i > 0; i -= Time.deltaTime)
        {
            Debug.Log("Entre a la rutina");
            material.SetFloat("_Cutoff", animationCurve.Evaluate(i / _delay));
            yield return null;
        }
        material.SetFloat("_Cutoff", 0);
        animationDone = true;
        yield return null;

        
    }

    public IEnumerator CurtainEffectFadeOut(float _delay)
    {
        material.SetFloat("_Cutoff", 0);

        for (float i = 0; i < _delay; i += Time.deltaTime)
        {
            material.SetFloat("_Cutoff", animationCurve.Evaluate(i / _delay));
            yield return null;
        }
        material.SetFloat("_Cutoff", 1);
        animationDone = true;
        yield return null;

        


    }

    public bool GetAnimationDone()
    {
        return animationDone;
    }

 
}