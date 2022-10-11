using System;
using System.Collections;
using TMPro;
using UnityEngine;
using static System.Convert;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private TMP_InputField timeIntervalInputField;
    [SerializeField] private TMP_InputField cubeSpeedInputField;
    [SerializeField] private TMP_InputField distanceInputField;

    [SerializeField] private TextMeshProUGUI warningText;

    [SerializeField] private GameObject cube;

    private float _intervalBetweenCreationCubes;
    private float _cubeSpeed;
    private float _distance;
    private static readonly int IsAppearing = Animator.StringToHash("IsAppearing");

    private void Start()
    {
        StartCoroutine(CubeSpawn());
    }

    private void Update()
    {
        try
        {
            _intervalBetweenCreationCubes = ToSingle(timeIntervalInputField.text);
            _cubeSpeed = ToSingle(cubeSpeedInputField.text);
            _distance = ToSingle(distanceInputField.text);
        }
        catch (Exception e)
        {
            timeIntervalInputField.text = _intervalBetweenCreationCubes.ToString();
            cubeSpeedInputField.text = _cubeSpeed.ToString();
            distanceInputField.text = _distance.ToString();
            warningText.text = e.Message;
            warningText.gameObject.SetActive(true);
            warningText.gameObject.GetComponent<Animator>().SetBool(IsAppearing, true);
        }
    }

    private IEnumerator CubeSpawn()
    {
        while (true)
        {
            var createdCube = Instantiate(cube, Vector3.zero, Quaternion.identity);
            createdCube.GetComponent<Cube>().speed = _cubeSpeed;
            createdCube.GetComponent<Cube>().distance = _distance;
            yield return new WaitForSeconds(_intervalBetweenCreationCubes);
        }
    }
}