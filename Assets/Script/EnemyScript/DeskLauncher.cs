using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLauncher : EnemyParent {

    [SerializeField] private GameObject[] furniturePrefab;

    [SerializeField] private float launcherRate;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(DeskLaunching());
    }

    protected void Update()
    {
        base.Update();
    }

    IEnumerator DeskLaunching()
    {
        while (gameObject)
        {
            yield return new WaitForSecondsRealtime(launcherRate);
            Instantiate(furniturePrefab[Random.Range(0, furniturePrefab.Length)], transform);
        }
    }
}
