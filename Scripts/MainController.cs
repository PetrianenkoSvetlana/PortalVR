using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    //[SerializeField] private Color[] _colors;
    [SerializeField] private GameObject _plane;
    [SerializeField] private GameObject _direction;
    [SerializeField] private GameObject _personCamera;
    [SerializeField] private float _minDist;
    //[SerializeField] private GameObject _column;
    //[SerializeField] private Light _flashlight;

    private Light _light;
    private ParticleSystem _particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        //_light = _direction.GetComponent<Light>();
        //_particleSystem = _direction.GetComponent<ParticleSystem>();

        //ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(_personCamera.transform.position, _direction.transform.position) < _minDist)
        //{
        //    ChangeColor();
        //}
    }

    //private void ChangeColor()
    //{
    //    Vector3 pos = _plane.transform.GetChild(Random.Range(1, _plane.transform.childCount)).transform.localPosition;
    //    _direction.transform.localPosition = new Vector3(pos.x, 2f, pos.z);

    //    //_light.color = _colors[Random.Range(0, _colors.Length)];
    //    //_particleSystem.startColor = _light.color;
    //}

    //public void ChangeLight()
    //{
    //    _flashlight.enabled = !_flashlight.enabled;
    //}
}
