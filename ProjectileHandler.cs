using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Damien.ProjectileSystem.ScriptableObjects;
using UnityEngine.Splines;

namespace Damien.ProjectileSystem
{
    [AddComponentMenu("Damien/Projectile System/Handler")]
    public class ProjectileHandler : MonoBehaviour
    {
        [SerializeField] internal ProjectileHandlerBehaviour Behaviour;

        private GameObject parent;
        private SplineContainer _splineContainer;
        private SplineAnimate _splineAnimator;
        private bool _initialized = false;
        private void Start()
        {

            CreateParentObject();
            InitializeSpline();
            InitializeVfx();

            transform.parent = parent.transform;

            _splineContainer.transform.parent = parent.transform;
            _splineContainer.transform.localPosition = new Vector3(0, 0, 0);
            _splineContainer.transform.localEulerAngles = new Vector3(0, 0, 0);

            _splineAnimator.transform.parent = parent.transform;
            _splineAnimator.transform.localPosition = new Vector3(0, 0, 0);
            _splineAnimator.transform.localEulerAngles = new Vector3(0, 0, 0);
            _splineAnimator.Play();
            _initialized = true;
        }

        private void CreateParentObject()
        {
            parent = new GameObject("Projectile Parent");
            parent.transform.parent = this.transform;
            parent.transform.localPosition = new Vector3(0, 0, 0);
            parent.transform.localEulerAngles = new Vector3(0, 0, 0);
            parent.transform.parent = null;
        }

        private void InitializeVfx()
        {
            var vfxBase = Behaviour.Vfx_Base;
            GameObject.Instantiate(vfxBase, transform);
        }

        private void InitializeSpline()
        {
            InitializeSplineContainer();
            InitializeSplineAnimate();
        }

        private void InitializeSplineAnimate()
        {
            _splineAnimator = gameObject.AddComponent<SplineAnimate>();
            _splineAnimator.AnimationMethod = SplineAnimate.Method.Speed;
            _splineAnimator.MaxSpeed = Behaviour.Speed;
            _splineAnimator.Container = _splineContainer;
            _splineAnimator.Loop = SplineAnimate.LoopMode.Once;
        }

        private void InitializeSplineContainer()
        {
            var splineObj = Instantiate(Behaviour.GetNextSpline(), parent.transform);
            _splineContainer = splineObj.GetComponent<SplineContainer>();
        }

        public void Update()
        {
            if (_initialized && _splineAnimator!=null && _splineAnimator.IsPlaying == false)
                Destroy(parent.gameObject);
        }
    }
}
