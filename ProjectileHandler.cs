using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Damien.ProjectileSystem.ScriptableObjects;
namespace Damien.ProjectileSystem
{
    public class ProjectileHandler : MonoBehaviour
    {
        [SerializeField]internal ProjectileHandlerBehaviour Behaviour;

        private void Start()
        {
            Instantiate(Behaviour.VfxBase, transform);
        }

        public void Update()
        {
            transform.position += transform.forward * Behaviour.Speed * Time.deltaTime;
        }
    }
}
