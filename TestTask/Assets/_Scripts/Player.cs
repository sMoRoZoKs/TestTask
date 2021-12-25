using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Material playerIdentetiMaterial;
    [SerializeField] private Material playerShieldMaterial;
    [HideInInspector] public bool immortal = false;
    [SerializeField] private MeshRenderer playerMeshRenderer;
    [SerializeField] private Transform startPosition;
    [SerializeField] private GameObject destroyBody;
    private GameObject _destroyBodySpawned;
    [SerializeField] private ParticleSystem winParticle;
    [SerializeField] private HintRenderer hintRenderer;
    [SerializeField] private TransitionAnimator transitionAnimator;
    private Transform _playerTransform;
    public float speed = 15;
    private float _speed;
    int routePointId = 0;
    private bool isGo = true;
    public bool GetIsGo => isGo;
    public void PlayerStop()
    {
        _speed = 0;
        isGo = false;
    }
    public void PlayerStart()
    {
        isGo = true;
        _speed = speed;
    }
    private void Start()
    {
        _speed = speed;

        //transitionAnimator.HideTransition();
        _playerTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (routePointId == hintRenderer.positions.Count) return;
        Vector3 point = hintRenderer.positions[routePointId] + new Vector3(5, 0, 5);
        _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, point, _speed * 0.01f);
        if (Vector3.Distance(_playerTransform.position, point) < 0.1f)
        {
            routePointId++;
        }
    }
    public void OnShield()
    {
        playerMeshRenderer.material = playerShieldMaterial;
        immortal = true;
        Invoke(nameof(EndOnShield),2f);
    }
    public void EndOnShield()
    {
        CancelInvoke(nameof(EndOnShield));
        playerMeshRenderer.material = playerIdentetiMaterial;
        immortal = false;
    }
    public bool Dead()
    {
        if (immortal) return false;
        StartDestroyAnimation();
        PlayerStop();
        transitionAnimator.ShowTransition();
        Invoke(nameof(ResetPosition),1f);
        return true;
    }
    private void StartDestroyAnimation()
    {
        _destroyBodySpawned = Instantiate(destroyBody,_playerTransform.position,Quaternion.identity);
        _destroyBodySpawned.transform.localScale = _playerTransform.localScale;
        playerMeshRenderer.enabled = false;
    }
    public void Finish()
    {
        winParticle.Play();
        transitionAnimator.ShowTransition();
        Invoke(nameof(ReloadScene),2f);
    }

    private void  ResetPosition()
    {
        //transitionAnimator.HideTransition();
        transitionAnimator.gameObject.SetActive(false);
        Destroy(_destroyBodySpawned);
        PlayerStart();
        playerMeshRenderer.enabled = true;
        routePointId = 0;
        _playerTransform.position = startPosition.position;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
