using UnityEngine;
using MARDEK.Event;
using MARDEK.Core;

namespace MARDEK.Animation
{
    public class PlaySpriteAnimationCommand : OngoingCommand
    {
        [SerializeField] SpriteAnimator targetAnimator;
        [SerializeField] MoveDirection animationDirection = null;

        public override bool IsOngoing()
        {
            // don't wait for a looping animation to end
            return targetAnimator.isAnimating && !targetAnimator.currentClipLoops; 
        }
        public override void Trigger()
        {
            targetAnimator.PlayClipByMoveDirectionReference(animationDirection);   
        }
    }
}