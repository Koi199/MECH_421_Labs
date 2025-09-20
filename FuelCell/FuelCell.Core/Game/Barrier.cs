using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FuelCell
{
    public class Barrier : GameObject
    {
        public string BarrierType { get; set; }

        public Barrier()
            : base()
        {
            BarrierType = null;
        }

        public void LoadContent(ContentManager content, string modelName)
        {
            Model = content.Load<Model>(modelName);
            BarrierType = modelName;
            Position = Vector3.Down;

            // Use tight bounding sphere for palm trees, default for others
            if (BarrierType.Contains("palm", StringComparison.OrdinalIgnoreCase))
            {
                BoundingSphere = CalculateTightBoundingSphere(Model);
            }
            else
            {
                BoundingSphere = CalculateBoundingSphere();
            }

            // Apply scaling factor
            BoundingSphere scaledSphere = BoundingSphere;
            scaledSphere.Radius *= GameConstants.BarrierBoundingSphereFactor;
            BoundingSphere = new BoundingSphere(scaledSphere.Center, scaledSphere.Radius);
        }

        /// <summary>
        /// Calculates a tight-fitting bounding sphere from the actual mesh vertices.
        /// </summary>
        private BoundingSphere CalculateTightBoundingSphere(Model model)
        {
            Vector3 min = new Vector3(float.MaxValue);
            Vector3 max = new Vector3(float.MinValue);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    // Get vertex data
                    var vertexData = new VertexPositionNormalTexture[part.NumVertices];
                    part.VertexBuffer.GetData(vertexData);

                    foreach (var v in vertexData)
                    {
                        // Transform vertex to model space
                        Vector3 transformed = Vector3.Transform(v.Position, mesh.ParentBone.Transform);
                        min = Vector3.Min(min, transformed);
                        max = Vector3.Max(max, transformed);
                    }
                }
            }

            BoundingBox box = new BoundingBox(min, max);
            return BoundingSphere.CreateFromBoundingBox(box);
        }

        public void Draw(Matrix view, Matrix projection)
        {
            Matrix translateMatrix = Matrix.CreateTranslation(Position);
            Matrix worldMatrix = translateMatrix;

            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = worldMatrix;
                    effect.View = view;
                    effect.Projection = projection;

                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                }
                mesh.Draw();
            }
        }
    }
}
