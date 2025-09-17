using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitNinjaButBetter
{
    public enum FruitType
    {
        Apple,
        Orange,
        Watermelon,
        Banana,
        Bomb
    }

    public class FruitProperties
    {
        public int Points { get; set; }
        public float Size { get; set; }
        public float FallSpeed { get; set; }
        public Color JuiceColor { get; set; }
        public int CutsRequired { get; set; }

        public static Dictionary<FruitType, FruitProperties> Properties = new Dictionary<FruitType, FruitProperties>
        {
            { FruitType.Apple, new FruitProperties { Points = 10, Size = 30, FallSpeed = 100, JuiceColor = Color.Red, CutsRequired = 1 } },
            { FruitType.Orange, new FruitProperties { Points = 15, Size = 25, FallSpeed = 90, JuiceColor = Color.Orange, CutsRequired = 1 } },
            { FruitType.Watermelon, new FruitProperties { Points = 50, Size = 50, FallSpeed = 60, JuiceColor = Color.Green, CutsRequired = 2 } },
            { FruitType.Banana, new FruitProperties { Points = 20, Size = 20, FallSpeed = 150, JuiceColor = Color.Yellow, CutsRequired = 1 } },
            { FruitType.Bomb, new FruitProperties { Points = -100, Size = 35, FallSpeed = 80, JuiceColor = Color.Black, CutsRequired = 1 } }
        };
    }

    public class Particle
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Color Color { get; set; }
        public float Life { get; set; }
        public float MaxLife { get; set; }
    }

    public class ParticleSystem
    {
        private List<Particle> particles = new List<Particle>();
        private Random random = new Random();

        public void SpawnJuice(Vector2 position, Color color, int count = 15)
        {
            for (int i = 0; i < count; i++)
            {
                var particle = new Particle
                {
                    Position = position,
                    Velocity = new Vector2(
                        (float)(random.NextDouble() - 0.5) * 200,
                        (float)(random.NextDouble() - 0.5) * 200
                    ),
                    Color = color,
                    Life = 0,
                    MaxLife = 1.5f + (float)random.NextDouble()
                };
                particles.Add(particle);
            }
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = particles.Count - 1; i >= 0; i--)
            {
                var particle = particles[i];

                particle.Position += particle.Velocity * deltaTime;
                // Apply gravity to velocity
                particle.Velocity = new Vector2(particle.Velocity.X, particle.Velocity.Y + 300 * deltaTime);
                particle.Life += deltaTime;

                // Fade out
                float alpha = 1.0f - (particle.Life / particle.MaxLife);
                particle.Color = particle.Color * alpha;

                if (particle.Life >= particle.MaxLife)
                {
                    particles.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D pixelTexture)
        {
            foreach (var particle in particles)
            {
                spriteBatch.Draw(pixelTexture,
                    new Rectangle((int)particle.Position.X, (int)particle.Position.Y, 4, 4),
                    particle.Color);
            }
        }
    }

    public class SwordTrail
    {
        private Queue<Vector2> trailPoints = new Queue<Vector2>();
        private const int MaxTrailPoints = 15;

        public void Update(Vector2 swordTip)
        {
            trailPoints.Enqueue(swordTip);
            if (trailPoints.Count > MaxTrailPoints)
                trailPoints.Dequeue();
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D pixelTexture)
        {
            var points = trailPoints.ToArray();
            for (int i = 1; i < points.Length; i++)
            {
                float alpha = (float)i / points.Length * 0.8f;
                DrawLine(spriteBatch, pixelTexture, points[i - 1], points[i], Color.Cyan * alpha, 3);
            }
        }

        private void DrawLine(SpriteBatch spriteBatch, Texture2D pixelTexture, Vector2 start, Vector2 end, Color color, int thickness)
        {
            Vector2 edge = end - start;
            float angle = (float)Math.Atan2(edge.Y, edge.X);

            spriteBatch.Draw(pixelTexture,
                new Rectangle((int)start.X, (int)start.Y, (int)edge.Length(), thickness),
                null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }
    }

    public class Sword
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Momentum { get; set; }
        public SwordTrail Trail { get; private set; }

        private const float SwordLength = 120;
        private Vector2 previousTip;

        public Sword()
        {
            Position = new Vector2(400, 300);
            Trail = new SwordTrail();
        }

        public Vector2 GetTip()
        {
            return Position + new Vector2(
                MathF.Cos(Rotation) * SwordLength,
                MathF.Sin(Rotation) * SwordLength
            );
        }

        public Vector2 GetBase()
        {
            return Position - new Vector2(
                MathF.Cos(Rotation) * 20,
                MathF.Sin(Rotation) * 20
            );
        }

        public void Update(GameTime gameTime)
        {
            Vector2 currentTip = GetTip();
            Trail.Update(currentTip);
            previousTip = currentTip;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D pixelTexture)
        {
            // Draw trail first
            Trail.Draw(spriteBatch, pixelTexture);

            // Draw sword blade
            Vector2 swordDirection = new Vector2(MathF.Cos(Rotation), MathF.Sin(Rotation));
            Vector2 bladeEnd = Position + swordDirection * SwordLength;

            DrawLine(spriteBatch, pixelTexture, Position, bladeEnd, Color.Silver, 6);

            // Draw hilt
            Vector2 hiltEnd = Position - swordDirection * 20;
            DrawLine(spriteBatch, pixelTexture, Position, hiltEnd, Color.SaddleBrown, 8);

            // Draw crossguard
            Vector2 perpendicular = new Vector2(-swordDirection.Y, swordDirection.X) * 15;
            DrawLine(spriteBatch, pixelTexture, Position - perpendicular, Position + perpendicular, Color.Gold, 4);
        }

        private void DrawLine(SpriteBatch spriteBatch, Texture2D pixelTexture, Vector2 start, Vector2 end, Color color, int thickness)
        {
            Vector2 edge = end - start;
            float angle = (float)Math.Atan2(edge.Y, edge.X);

            spriteBatch.Draw(pixelTexture,
                new Rectangle((int)start.X, (int)start.Y, (int)edge.Length(), thickness),
                null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }
    }

    public class Fruit
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public FruitType Type { get; set; }
        public bool IsCut { get; set; }
        public float Rotation { get; set; }
        public float RotationSpeed { get; set; }
        public int CutsRemaining { get; set; }

        private Random random = new Random();

        public Fruit(FruitType type, Vector2 startPosition)
        {
            Type = type;
            Position = startPosition;
            var props = FruitProperties.Properties[type];
            Velocity = new Vector2(0, props.FallSpeed);
            RotationSpeed = (float)(random.NextDouble() - 0.5) * 4;
            CutsRemaining = props.CutsRequired;
        }

        public float GetRadius()
        {
            return FruitProperties.Properties[Type].Size / 2;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position += Velocity * deltaTime;
            Rotation += RotationSpeed * deltaTime;

            // Add slight gravity
            Velocity = new Vector2(Velocity.X, Velocity.Y + 50 * deltaTime);
        }

        public void Cut(Vector2 cutDirection)
        {
            CutsRemaining--;
            if (CutsRemaining <= 0)
            {
                IsCut = true;
            }

            // Add some physics response to the cut
            Velocity = Velocity + cutDirection * 50;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D pixelTexture)
        {
            var props = FruitProperties.Properties[Type];
            Color fruitColor = GetFruitColor();

            // Draw main fruit body
            spriteBatch.Draw(pixelTexture,
                new Rectangle((int)Position.X - (int)props.Size / 2, (int)Position.Y - (int)props.Size / 2,
                             (int)props.Size, (int)props.Size),
                null, fruitColor, Rotation, Vector2.Zero, SpriteEffects.None, 0);

            // Add some detail based on fruit type
            if (Type == FruitType.Watermelon)
            {
                // Dark green stripes
                spriteBatch.Draw(pixelTexture,
                    new Rectangle((int)Position.X - (int)props.Size / 2 + 5, (int)Position.Y - (int)props.Size / 2,
                                 (int)props.Size - 10, (int)props.Size),
                    null, Color.DarkGreen * 0.5f, Rotation, Vector2.Zero, SpriteEffects.None, 0);
            }
            else if (Type == FruitType.Bomb)
            {
                // Fuse
                Vector2 fuseStart = Position + new Vector2(0, -props.Size / 2);
                Vector2 fuseEnd = fuseStart + new Vector2(0, -10);
                DrawLine(spriteBatch, pixelTexture, fuseStart, fuseEnd, Color.Brown, 2);

                // Spark
                spriteBatch.Draw(pixelTexture,
                    new Rectangle((int)fuseEnd.X - 2, (int)fuseEnd.Y - 2, 4, 4),
                    Color.Red);
            }
        }

        private Color GetFruitColor()
        {
            return Type switch
            {
                FruitType.Apple => Color.Red,
                FruitType.Orange => Color.Orange,
                FruitType.Watermelon => Color.LimeGreen,
                FruitType.Banana => Color.Yellow,
                FruitType.Bomb => Color.Black,
                _ => Color.White
            };
        }

        private void DrawLine(SpriteBatch spriteBatch, Texture2D pixelTexture, Vector2 start, Vector2 end, Color color, int thickness)
        {
            Vector2 edge = end - start;
            float angle = (float)Math.Atan2(edge.Y, edge.X);

            spriteBatch.Draw(pixelTexture,
                new Rectangle((int)start.X, (int)start.Y, (int)edge.Length(), thickness),
                null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }
    }

    public class ScoreManager
    {
        public int TotalScore { get; private set; }
        public int ComboMultiplier { get; private set; } = 1;
        public float ComboTimer { get; private set; }
        public int FruitsCut { get; private set; }

        private const float ComboTimeLimit = 3.0f;

        public void AddCut(FruitType fruitType, float cutQuality)
        {
            var props = FruitProperties.Properties[fruitType];

            if (fruitType == FruitType.Bomb)
            {
                // Game over or penalty
                TotalScore += props.Points;
                ResetCombo();
                return;
            }

            int basePoints = props.Points;
            int qualityBonus = (int)(cutQuality * 10);
            int comboBonus = basePoints * (ComboMultiplier - 1);

            int totalPoints = basePoints + qualityBonus + comboBonus;
            TotalScore += totalPoints;
            FruitsCut++;

            // Extend combo
            ComboMultiplier++;
            ComboTimer = ComboTimeLimit;
        }

        public void Update(GameTime gameTime)
        {
            if (ComboTimer > 0)
            {
                ComboTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (ComboTimer <= 0)
                {
                    ResetCombo();
                }
            }
        }

        private void ResetCombo()
        {
            ComboMultiplier = 1;
            ComboTimer = 0;
        }
    }

    // Your existing AccelerometerProcessor class integration
    public class AccelerometerProcessor
    {
        // Simplified version for demo - replace with your full implementation
        public float DeadZone { get; set; } = 3.0f;
        public float SmoothingAlpha { get; set; } = 0.6f;

        private AccelerometerReading previousData = new AccelerometerReading(127, 127, 127);

        public AccelerometerReading ProcessData(int x, int y, int z)
        {
            // Apply smoothing
            float smoothedX = SmoothingAlpha * x + (1 - SmoothingAlpha) * previousData.X;
            float smoothedY = SmoothingAlpha * y + (1 - SmoothingAlpha) * previousData.Y;
            float smoothedZ = SmoothingAlpha * z + (1 - SmoothingAlpha) * previousData.Z;

            var result = new AccelerometerReading(smoothedX, smoothedY, smoothedZ);
            previousData = result;

            return result;
        }

        public float GetMagnitude(AccelerometerReading data)
        {
            float centeredX = data.X - 127.5f;
            float centeredY = data.Y - 127.5f;
            float centeredZ = data.Z - 127.5f;

            return MathF.Sqrt(centeredX * centeredX + centeredY * centeredY + centeredZ * centeredZ);
        }
    }

    public class AccelerometerReading
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public AccelerometerReading(float x, float y, float z)
        {
            X = x; Y = y; Z = z;
        }
    }

    public class FruitSwordGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D pixelTexture;

        // Game objects
        private Sword sword;
        private List<Fruit> fruits;
        private ParticleSystem particleSystem;
        private ScoreManager scoreManager;
        private AccelerometerProcessor accelerometerProcessor;

        // Game timing
        private float fruitSpawnTimer;
        private const float FruitSpawnInterval = 1.5f;
        private Random random = new Random();

        // Demo input (replace with your serial accelerometer data)
        private MouseState previousMouseState;

        public FruitSwordGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
        }

        protected override void Initialize()
        {
            sword = new Sword();
            fruits = new List<Fruit>();
            particleSystem = new ParticleSystem();
            scoreManager = new ScoreManager();
            accelerometerProcessor = new AccelerometerProcessor();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create a simple white pixel texture
            pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            pixelTexture.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Demo input using mouse - replace with your accelerometer data
            var mouseState = Mouse.GetState();
            UpdateSwordWithMouse(mouseState); // Replace this with UpdateSwordWithAccelerometer

            // Update game objects
            sword.Update(gameTime);
            UpdateFruits(gameTime);
            CheckCollisions();
            particleSystem.Update(gameTime);
            scoreManager.Update(gameTime);

            // Spawn new fruits
            fruitSpawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (fruitSpawnTimer >= FruitSpawnInterval)
            {
                SpawnFruit();
                fruitSpawnTimer = 0;
            }

            base.Update(gameTime);
        }

        // Demo method - replace with your accelerometer integration
        private void UpdateSwordWithMouse(MouseState mouseState)
        {
            // Move sword position based on mouse position
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);

            // Smooth movement to mouse position
            sword.Position = Vector2.Lerp(sword.Position, mousePos, 0.1f);

            // Calculate direction from sword base to mouse for rotation
            Vector2 direction = mousePos - sword.Position;
            if (direction.Length() > 10) // Avoid jitter when mouse is at sword position
            {
                sword.Rotation = MathF.Atan2(direction.Y, direction.X);
            }

            // Calculate momentum based on mouse movement
            var mouseDelta = mousePos - new Vector2(previousMouseState.X, previousMouseState.Y);
            sword.Momentum = mouseDelta * 0.1f;

            previousMouseState = mouseState;
        }

        // This is where you'd integrate your accelerometer
        private void UpdateSwordWithAccelerometer(AccelerometerReading accelData)
        {
            // Map accelerometer tilt to sword position (like tilting the screen)
            float screenWidth = graphics.PreferredBackBufferWidth;
            float screenHeight = graphics.PreferredBackBufferHeight;

            // Convert accelerometer readings to screen coordinates
            // Assuming 0-255 range from your accelerometer
            float normalizedX = (accelData.X - 127.5f) / 127.5f; // Convert to -1 to +1
            float normalizedY = (accelData.Y - 127.5f) / 127.5f;

            // Map to screen position (with some bounds)
            Vector2 targetPosition = new Vector2(
                screenWidth * 0.5f + normalizedX * screenWidth * 0.4f,   // Keep within 40% of screen center
                screenHeight * 0.5f + normalizedY * screenHeight * 0.4f
            );

            // Smooth movement to target position
            sword.Position = Vector2.Lerp(sword.Position, targetPosition, 0.15f);

            // Calculate rotation based on acceleration direction for sword angle
            float targetRotation = MathF.Atan2(normalizedY, normalizedX);
            sword.Rotation = MathHelper.Lerp(sword.Rotation, targetRotation, 0.1f);

            // Calculate momentum for cutting power
            float magnitude = accelerometerProcessor.GetMagnitude(accelData);
            Vector2 direction = new Vector2(normalizedX, normalizedY);
            sword.Momentum = direction * magnitude * 0.01f;
        }

        private void UpdateFruits(GameTime gameTime)
        {
            for (int i = fruits.Count - 1; i >= 0; i--)
            {
                fruits[i].Update(gameTime);

                // Remove fruits that fall off screen or are cut
                if (fruits[i].Position.Y > graphics.PreferredBackBufferHeight + 100 ||
                    fruits[i].IsCut)
                {
                    fruits.RemoveAt(i);
                }
            }
        }

        private void CheckCollisions()
        {
            Vector2 swordTip = sword.GetTip();
            Vector2 swordBase = sword.GetBase();

            foreach (var fruit in fruits.Where(f => !f.IsCut))
            {
                if (LineCircleIntersection(swordBase, swordTip, fruit.Position, fruit.GetRadius()))
                {
                    CutFruit(fruit);
                }
            }
        }

        private bool LineCircleIntersection(Vector2 lineStart, Vector2 lineEnd, Vector2 circleCenter, float radius)
        {
            Vector2 line = lineEnd - lineStart;
            Vector2 toCircle = circleCenter - lineStart;

            float lineLength = line.Length();
            if (lineLength == 0) return false;

            // Project circle center onto line
            float projection = Vector2.Dot(toCircle, line) / lineLength;
            projection = MathHelper.Clamp(projection, 0, lineLength);

            // Find closest point on line
            Vector2 closestPoint = lineStart + (line / lineLength) * projection;

            // Check if distance to circle center is within radius
            float distance = Vector2.Distance(closestPoint, circleCenter);
            return distance <= radius;
        }

        private void CutFruit(Fruit fruit)
        {
            // Calculate cut quality based on sword momentum
            float cutQuality = MathHelper.Clamp(sword.Momentum.Length() * 0.1f, 0.1f, 1.0f);

            // Cut the fruit
            Vector2 cutDirection = Vector2.Normalize(sword.Momentum);
            fruit.Cut(cutDirection);

            // Add score
            scoreManager.AddCut(fruit.Type, cutQuality);

            // Spawn juice particles
            var props = FruitProperties.Properties[fruit.Type];
            particleSystem.SpawnJuice(fruit.Position, props.JuiceColor, 20);

            // Screen shake effect (simple camera shake)
            // You could add camera shake here for more juice feedback
        }

        private void SpawnFruit()
        {
            // Random fruit type (weighted towards common fruits)
            FruitType[] fruitTypes = {
                FruitType.Apple, FruitType.Apple, FruitType.Apple,  // Common
                FruitType.Orange, FruitType.Orange,                 // Somewhat common
                FruitType.Banana,                                   // Less common
                FruitType.Watermelon,                              // Rare, high value
                FruitType.Bomb                                      // Rare, penalty
            };

            FruitType selectedType = fruitTypes[random.Next(fruitTypes.Length)];

            // Random spawn position across top of screen
            Vector2 spawnPosition = new Vector2(
                random.Next(50, graphics.PreferredBackBufferWidth - 50),
                -50
            );

            fruits.Add(new Fruit(selectedType, spawnPosition));
        }

        protected override void Draw(GameTime gameTime)
        {
            // Dynamic background color based on combo
            Color backgroundColor = scoreManager.ComboMultiplier > 5
                ? Color.Lerp(Color.CornflowerBlue, Color.Orange, 0.3f)
                : Color.CornflowerBlue;

            GraphicsDevice.Clear(backgroundColor);

            spriteBatch.Begin();

            // Draw fruits
            foreach (var fruit in fruits)
            {
                fruit.Draw(spriteBatch, pixelTexture);
            }

            // Draw sword
            sword.Draw(spriteBatch, pixelTexture);

            // Draw particles
            particleSystem.Draw(spriteBatch, pixelTexture);

            // Draw UI
            DrawUI();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawUI()
        {
            // Score display
            DrawText($"Score: {scoreManager.TotalScore}", new Vector2(10, 10), Color.White);
            DrawText($"Fruits Cut: {scoreManager.FruitsCut}", new Vector2(10, 30), Color.White);

            // Combo display
            if (scoreManager.ComboMultiplier > 1)
            {
                Color comboColor = Color.Lerp(Color.Yellow, Color.Red,
                    (scoreManager.ComboMultiplier - 1) / 10.0f);
                DrawText($"COMBO x{scoreManager.ComboMultiplier}!",
                    new Vector2(10, 60), comboColor);

                // Combo timer bar
                float timerRatio = scoreManager.ComboTimer / 3.0f;
                var timerRect = new Rectangle(10, 85, (int)(200 * timerRatio), 10);
                spriteBatch.Draw(pixelTexture, timerRect, Color.Yellow * 0.8f);
            }

            // Simple crosshair at sword tip for aiming
            Vector2 swordTip = sword.GetTip();
            DrawCrosshair(swordTip);

            // Instructions
            DrawText("Move mouse to control sword",
                new Vector2(10, graphics.PreferredBackBufferHeight - 40), Color.LightGray);
            DrawText("Cut fruits, avoid bombs!",
                new Vector2(10, graphics.PreferredBackBufferHeight - 20), Color.LightGray);
        }

        private void DrawText(string text, Vector2 position, Color color)
        {
            // Simple bitmap text rendering using rectangles
            // In a real game, you'd use SpriteFont for proper text rendering
            float x = position.X;
            float y = position.Y;

            foreach (char c in text)
            {
                if (c == ' ')
                {
                    x += 8;
                    continue;
                }

                // Simple character rendering as colored rectangles
                var charRect = new Rectangle((int)x, (int)y, 6, 8);
                spriteBatch.Draw(pixelTexture, charRect, color * 0.8f);
                x += 8;
            }
        }

        private void DrawCrosshair(Vector2 position)
        {
            // Simple crosshair for aiming feedback
            spriteBatch.Draw(pixelTexture,
                new Rectangle((int)position.X - 10, (int)position.Y - 1, 20, 2),
                Color.Red * 0.7f);
            spriteBatch.Draw(pixelTexture,
                new Rectangle((int)position.X - 1, (int)position.Y - 10, 2, 20),
                Color.Red * 0.7f);
        }
    }
}