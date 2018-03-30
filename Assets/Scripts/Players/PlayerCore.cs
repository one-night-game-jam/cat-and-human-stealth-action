using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

namespace Players
{
    [RequireComponent(typeof(PlayerParameters))]
    public class PlayerCore : MonoBehaviour, IPlayerPosition
    {
        [SerializeField] private PlayerParameters _parameters;
        public PlayerParameters PlayerParameters => _parameters;

        private readonly FloatReactiveProperty _moveSpeed = new FloatReactiveProperty(0);

        public IObservable<Vector2> Movement => _moveSpeed.Select(speed => Vector2.up * speed);

        public IObservable<Vector3> Position => this.FixedUpdateAsObservable().Select(_ => transform.position);

        private void Awake()
        {
            _moveSpeed.Value = _parameters.MoveSpeed;
        }
    }
}