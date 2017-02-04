using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour
{

    // Use this for initialization


    public float timer;
    public GameObject current;
    public GameObject homereset;
    private GetAllCubes all;
    void Start()
    {
        all = GetComponent<GetAllCubes>();
    }
    void OnEnable()
    {
        current = null;
    }

    // Update is called once per frame
    void Update()
    {
    if (timer>0)
    {
            timer -= Time.deltaTime;
    }
        if (Input.GetButtonDown("Fire1") && timer <= 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.transform.gameObject == current&& hit.transform.tag == "Selection")
            {
                //Activate the next level here
                StartCoroutine(loadLevel());


            }

            if (hit.transform.tag == "Selection" && hit.transform.gameObject != current)
            {
            if (current)
            {
                    current.GetComponent<lightColorSwitch>().updateColor();

                }
                current = hit.transform.gameObject;
                 current.GetComponent<lightColorSwitch>().updateColor();
            }
        }
        
    }
    IEnumerator loadLevel()
    {
        all.allFadeOut();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(current.GetComponent<levelID>().level, LoadSceneMode.Additive);

        homereset.SetActive(true);
        gameObject.SetActive(false);

    }
}
