using Microsoft.Xna.Framework;

namespace FuelCell
{
    public class Camera
    {
        public Vector3 AvatarHeadOffset { get; set; }
        public Vector3 TargetOffset { get; set; }
        public Matrix ViewMatrix { get; set; }
        public Matrix ProjectionMatrix { get; set; }

        public Camera()
        {
            AvatarHeadOffset = new Vector3(0, 10, -15);
            TargetOffset = new Vector3(0, 5, 0);
            ViewMatrix = Matrix.Identity;
            ProjectionMatrix = Matrix.Identity;
        }

        //public void Update(float avatarYaw, Vector3 position, float aspectRatio)
        //{
        //    Matrix rotationMatrix = Matrix.CreateRotationY(avatarYaw);

        //    Vector3 transformedheadOffset = Vector3.Transform(AvatarHeadOffset, rotationMatrix);
        //    Vector3 transformedReference = Vector3.Transform(TargetOffset, rotationMatrix);

        //    Vector3 cameraPosition = position + transformedheadOffset;
        //    Vector3 cameraTarget = position + transformedReference;

        //    //Calculate the camera's view and projection matrices based on current values.
        //    ViewMatrix = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
        //    ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(GameConstants.ViewAngle),
        //        aspectRatio, GameConstants.NearClip, GameConstants.FarClip);
        //}

        public void Update(float avatarYaw, Vector3 position, float aspectRatio)
        {
            // Adjust this to match your model scale
            float scaleFactor = 1f; // for a buggy 1000× bigger than the old ship

            Matrix rotationMatrix = Matrix.CreateRotationY(avatarYaw);

            // Scale the offsets so the camera sits further back and higher
            Vector3 transformedHeadOffset = Vector3.Transform(AvatarHeadOffset * scaleFactor, rotationMatrix);
            Vector3 transformedReference = Vector3.Transform(TargetOffset * scaleFactor, rotationMatrix);

            Vector3 cameraPosition = position + transformedHeadOffset;
            Vector3 cameraTarget = position + transformedReference;

            // Calculate the camera's view and projection matrices
            ViewMatrix = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(GameConstants.ViewAngle),
                aspectRatio,
                GameConstants.NearClip,
                GameConstants.FarClip
            );
        }

    }
}