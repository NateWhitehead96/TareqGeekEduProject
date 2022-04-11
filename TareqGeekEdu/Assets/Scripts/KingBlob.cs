using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingBlob : EnemyScript
{

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.maxValue = Health;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = Health;
    }
}
