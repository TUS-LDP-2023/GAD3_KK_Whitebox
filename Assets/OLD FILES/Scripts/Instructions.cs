using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(FadeInstruction), 5);
    }

    public void FadeInstruction()
    {
        Destroy(gameObject);
    }

}
