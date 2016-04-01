using UnityEngine;
using System.Collections;

public class ScaleCube : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine("ScaleCubeUp");
	}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            StopCoroutine("ScaleCubeUp");
        }
    }

    public IEnumerator ScaleCubeUp()
    {
        while (true)
        {
            this.transform.localScale += new Vector3(0.1f, 0f, 0f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
