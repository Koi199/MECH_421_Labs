#region File Description
//-----------------------------------------------------------------------------
// FuelCellGame.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using MediaPlayer = Microsoft.Xna.Framework.Media.MediaPlayer;

namespace FuelCell
{
    /// <summary>
    /// The available states of the game
    /// </summary>
    public enum GameState { Loading, Running, Won, Lost, NextLevel }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FuelCellGame : Game
    {
        // Resources for drawing.
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont statsFont;
        private GameObject ground;
        private Camera gameCamera;
        private Random random;
        private GameState currentGameState = GameState.Loading;

        // Game objects
        private FuelCarrier fuelCarrier;
        private FuelCell[] fuelCells;
        private Barrier[] barriers;
        private Barrier[] boundaryBarriers;

        private GameObject boundingSphere;

        private int retrievedFuelCells = 0;
        private TimeSpan startTime, roundTimer;
        private float aspectRatio;
        private IInputState inputState;
        private Song backgroundMusic;

        // Level system
        private int currentLevel = 1;
        private const int maxLevel = 3;
        private TimeSpan levelCompletePause = TimeSpan.FromSeconds(2);
        private TimeSpan nextLevelTimer;

        // Cloud system
        private Texture2D cloudTexture;
        private Vector2[] cloudPositions;
        private float[] cloudSpeeds;
        private bool cloudsInitialized = false;

        public FuelCellGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            random = new Random();
            graphics.PreferredBackBufferWidth = 853;
            graphics.PreferredBackBufferHeight = 480;
            inputState = new InputState(this);
        }

        protected override void Initialize()
        {
            // Initialize the Game objects
            ground = new GameObject();
            gameCamera = new Camera();
            boundingSphere = new GameObject();
            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

            base.Initialize();
        }

        /// <summary>
        /// Get number of fuel cells for current level
        /// </summary>
        private int GetNumFuelCells(int level)
        {
            return GameConstants.NumFuelCells + (level - 1) * 2; // Level 1: base, Level 2: +2, Level 3: +4
        }

        /// <summary>
        /// Get number of barriers for current level
        /// </summary>
        private int GetNumBarriers(int level)
        {
            return GameConstants.NumBarriers + (level - 1) * 3; // More barriers each level
        }

        /// <summary>
        /// Get time limit for current level
        /// </summary>
        private TimeSpan GetLevelTime(int level)
        {
            int baseSeconds = 60;
            int timeReduction = (level - 1) * 10; // Less time each level
            return TimeSpan.FromSeconds(Math.Max(baseSeconds - timeReduction, 30)); // Minimum 30 seconds
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            this.Content.RootDirectory = "Content";

            // Load cloud texture and initialize cloud positions and speeds
            cloudTexture = Content.Load<Texture2D>("Models/Clouds V2-2");

            // Initialize cloud arrays (but not positions yet)
            cloudPositions = new Vector2[7];
            cloudSpeeds = new float[5];

            // Initialize cloud speeds (these don't change)
            Random cloudRandom = new Random();
            for (int i = 0; i < cloudSpeeds.Length; i++)
            {
                cloudSpeeds[i] = cloudRandom.Next(10, 30);
            }

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            statsFont = Content.Load<SpriteFont>("Fonts/StatsFont");

            ground.Model = Content.Load<Model>("Models/ground_grass");
            boundingSphere.Model = Content.Load<Model>("Models/sphere1uR");

            // Audio
            backgroundMusic = Content.Load<Song>("Audio/road-trip-music-383883");

            //Initialize fuel carrier
            fuelCarrier = new FuelCarrier();
            fuelCarrier.LoadContent(Content, "Models/suv");

            // Initialize with Level 1 parameters
            InitializeGameField();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Update the InputState class.
            inputState.Update();

            // Allows the game to exit
            if (inputState.PlayerExit(PlayerIndex.One))
            {
                this.Exit();
            }

            // If the player has only just pressed the Enter key or has pressed the Start button
            if (currentGameState == GameState.Loading)
            {
                if (inputState.StartGame(PlayerIndex.One))
                {
                    ResetGame(gameTime, aspectRatio);
                }
            }

            // Next level transition state
            if (currentGameState == GameState.NextLevel)
            {
                nextLevelTimer -= gameTime.ElapsedGameTime;
                if (nextLevelTimer <= TimeSpan.Zero)
                {
                    StartNextLevel(gameTime, aspectRatio);
                }
            }

            // Main gameplay running screen
            if (currentGameState == GameState.Running)
            {
                // Initialize clouds once when game starts running
                if (!cloudsInitialized)
                {
                    InitializeClouds();
                    cloudsInitialized = true;
                }

                fuelCarrier.Update(inputState, barriers);
                float aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;
                gameCamera.Update(fuelCarrier.ForwardDirection, fuelCarrier.Position, aspectRatio);

                // Count retrieved fuel cells
                retrievedFuelCells = 0;
                foreach (FuelCell fuelCell in fuelCells)
                {
                    fuelCell.Update(fuelCarrier.BoundingSphere);
                    if (fuelCell.Retrieved)
                    {
                        retrievedFuelCells++;
                    }
                }

                // Check level completion
                if (retrievedFuelCells == GetNumFuelCells(currentLevel))
                {
                    if (currentLevel >= maxLevel)
                    {
                        currentGameState = GameState.Won; // Beat all levels!
                    }
                    else
                    {
                        currentGameState = GameState.NextLevel;
                        nextLevelTimer = levelCompletePause;
                    }
                }

                // Check time limit
                roundTimer -= gameTime.ElapsedGameTime;
                if (roundTimer < TimeSpan.Zero && retrievedFuelCells != GetNumFuelCells(currentLevel))
                {
                    currentGameState = GameState.Lost;
                }
            }

            if (currentGameState == GameState.Won || currentGameState == GameState.Lost)
            {
                // Gameplay has stopped and if audio is still playing, stop it.
                if (MediaPlayer.State == MediaState.Playing)
                {
                    MediaPlayer.Stop();
                }

                // Reset the world for a new game
                if (inputState.StartGame(PlayerIndex.One))
                {
                    ResetGame(gameTime, aspectRatio);
                }
            }

            base.Update(gameTime);
        }

        private void InitializeClouds()
        {
            if (cloudPositions != null && GraphicsDevice != null)
            {
                Random cloudRandom = new Random();
                List<Vector2> placedClouds = new List<Vector2>();

                for (int i = 0; i < cloudPositions.Length; i++)
                {
                    Vector2 newPosition;
                    int attempts = 0;

                    do
                    {
                        newPosition = new Vector2(
                            cloudRandom.Next(0, GraphicsDevice.Viewport.Width - 100),
                            cloudRandom.Next(0, GraphicsDevice.Viewport.Height / 3)
                        );
                        attempts++;
                    }
                    while (IsPositionTooClose(newPosition, placedClouds, 150f) && attempts < 20);

                    cloudPositions[i] = newPosition;
                    placedClouds.Add(newPosition);
                }
            }
        }

        private bool IsPositionTooClose(Vector2 newPos, List<Vector2> existingPositions, float minDistance)
        {
            foreach (Vector2 existing in existingPositions)
            {
                if (Vector2.Distance(newPos, existing) < minDistance)
                {
                    return true;
                }
            }
            return false;
        }

        private void StartNextLevel(GameTime gameTime, float aspectRatio)
        {
            currentLevel++;
            System.Diagnostics.Debug.WriteLine($"Starting Level {currentLevel}");

            fuelCarrier.Reset();
            gameCamera.Update(fuelCarrier.ForwardDirection, fuelCarrier.Position, aspectRatio);
            InitializeGameField();

            retrievedFuelCells = 0;
            roundTimer = GetLevelTime(currentLevel);
            currentGameState = GameState.Running;
        }

        /// <summary>
        /// Draws the game from background to foreground.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Set different background colors based on game state
            switch (currentGameState)
            {
                case GameState.Loading:
                    GraphicsDevice.Clear(Color.SteelBlue);
                    DrawSplashScreen();
                    break;
                case GameState.Running:
                    GraphicsDevice.Clear(new Color(88, 179, 184));
                    DrawGameplayScreen();
                    break;
                case GameState.NextLevel:
                    GraphicsDevice.Clear(new Color(88, 179, 184));
                    DrawLevelCompleteScreen();
                    break;
                case GameState.Won:
                case GameState.Lost:
                    GraphicsDevice.Clear(Color.Black);
                    DrawWinOrLossScreen(currentGameState == GameState.Won ?
                        "Congratulations! You completed all levels!" : GameConstants.StrGameLost);
                    break;
            }

            base.Draw(gameTime);
        }

        private void DrawGameplayScreen()
        {
            // Draw the ground terrain model
            DrawTerrain(ground.Model);

            // Draw the fuel cells on the map
            foreach (FuelCell fuelCell in fuelCells)
            {
                if (!fuelCell.Retrieved)
                {
                    fuelCell.Draw(gameCamera.ViewMatrix, gameCamera.ProjectionMatrix);
                }
            }

            // Draw the barriers on the map
            foreach (Barrier barrier in barriers)
            {
                barrier.Draw(gameCamera.ViewMatrix, gameCamera.ProjectionMatrix);
            }

            // Draw the player fuelcarrier on the map
            fuelCarrier.Draw(gameCamera.ViewMatrix, gameCamera.ProjectionMatrix); 

            if (boundaryBarriers != null)
            {
                foreach (Barrier boundary in boundaryBarriers)
                {
                    boundary.Draw(gameCamera.ViewMatrix, gameCamera.ProjectionMatrix);
                }
            }

            DrawStats();
        }

        private void DrawLevelCompleteScreen()
        {
            float xOffsetText, yOffsetText;
            Vector2 viewportSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Vector2 strCenter;

            string levelCompleteText = $"Level {currentLevel - 1} Complete!";
            string nextLevelText = $"Starting Level {currentLevel}...";

            Vector2 strCompleteSize = statsFont.MeasureString(levelCompleteText);
            Vector2 strNextSize = statsFont.MeasureString(nextLevelText);

            // Level complete text
            strCenter = new Vector2(strCompleteSize.X / 2, strCompleteSize.Y / 2);
            yOffsetText = (viewportSize.Y / 2 - strCenter.Y) - statsFont.LineSpacing;
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            Vector2 strPosition = new Vector2(xOffsetText, yOffsetText);

            spriteBatch.Begin();
            spriteBatch.DrawString(statsFont, levelCompleteText, strPosition, Color.Green);

            // Next level text
            strCenter = new Vector2(strNextSize.X / 2, strNextSize.Y / 2);
            yOffsetText = (viewportSize.Y / 2 - strCenter.Y) + statsFont.LineSpacing;
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            strPosition = new Vector2(xOffsetText, yOffsetText);

            spriteBatch.DrawString(statsFont, nextLevelText, strPosition, Color.White);
            spriteBatch.End();

            ResetRenderStates();
        }

        /// <summary>
        /// Helper function to change the rasterizer state for drawing the wireframe bounding spheres
        /// </summary>
        /// <param name="fillmode">The render `FillMode` to draw with, e.g. WireFrame</param>
        /// <param name="cullMode">The culling mode to draw with, e.g. None</param>
        /// <returns>Returns a new RasterizerState to apply to a graphics device</returns>
        private RasterizerState ChangeRasterizerState(FillMode fillmode, CullMode cullMode = CullMode.None)
        {
            RasterizerState rasterizerState = new RasterizerState()
            {
                FillMode = fillmode,
                CullMode = cullMode
            };
            graphics.GraphicsDevice.RasterizerState = rasterizerState;
            return rasterizerState;
        }

        private void DrawTerrain(Model model)
        {
            float tileSize = 10f; // match your ground model size
            int tilesPerSide = (int)((2 * GameConstants.MaxRange / tileSize) + 2);

            for (int x = -tilesPerSide / 2; x < tilesPerSide / 2; x++)
            {
                for (int z = -tilesPerSide / 2; z < tilesPerSide / 2; z++)
                {
                    Matrix worldMatrix = Matrix.CreateTranslation(x * tileSize, 0, z * tileSize);

                    foreach (ModelMesh mesh in model.Meshes)
                    {
                        foreach (BasicEffect effect in mesh.Effects)
                        {
                            effect.World = worldMatrix;
                            effect.View = gameCamera.ViewMatrix;
                            effect.Projection = gameCamera.ProjectionMatrix;
                            effect.EnableDefaultLighting();
                            effect.PreferPerPixelLighting = false;
                        }
                        mesh.Draw();
                    }
                }
            }
        }

        private void DrawSplashScreen()
        {
            float xOffsetText, yOffsetText;
            Vector2 viewportSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Vector2 strCenter;

            xOffsetText = yOffsetText = 0;
            Vector2 strInstructionsSize = statsFont.MeasureString(GameConstants.StrInstructions1);
            Vector2 strPosition;
            strCenter = new Vector2(strInstructionsSize.X / 2, strInstructionsSize.Y / 2);

            yOffsetText = (viewportSize.Y / 2 - strCenter.Y);
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            strPosition = new Vector2(xOffsetText, yOffsetText);

            spriteBatch.Begin();
            spriteBatch.DrawString(statsFont, GameConstants.StrInstructions1, strPosition, Color.White);

            strInstructionsSize = statsFont.MeasureString(GameConstants.StrInstructions2);
            strCenter = new Vector2(strInstructionsSize.X / 2, strInstructionsSize.Y / 2);
            yOffsetText = (viewportSize.Y / 2 - strCenter.Y) + statsFont.LineSpacing;
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            strPosition = new Vector2(xOffsetText, yOffsetText);

            spriteBatch.DrawString(statsFont, GameConstants.StrInstructions2, strPosition, Color.LightGray);
            spriteBatch.End();

            ResetRenderStates();
        }

        private void DrawWinOrLossScreen(string gameResult)
        {
            float xOffsetText, yOffsetText;
            Vector2 viewportSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Vector2 strCenter;

            xOffsetText = yOffsetText = 0;
            Vector2 strResult = statsFont.MeasureString(gameResult);
            Vector2 strPlayAgainSize = statsFont.MeasureString(GameConstants.StrPlayAgain);
            Vector2 strPosition;
            strCenter = new Vector2(strResult.X / 2, strResult.Y / 2);

            yOffsetText = (viewportSize.Y / 2 - strCenter.Y);
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            strPosition = new Vector2(xOffsetText, yOffsetText);

            spriteBatch.Begin();
            spriteBatch.DrawString(statsFont, gameResult, strPosition, Color.Red);

            strCenter = new Vector2(strPlayAgainSize.X / 2, strPlayAgainSize.Y / 2);
            yOffsetText = (viewportSize.Y / 2 - strCenter.Y) + (float)statsFont.LineSpacing;
            xOffsetText = (viewportSize.X / 2 - strCenter.X);
            strPosition = new Vector2(xOffsetText, yOffsetText);
            spriteBatch.DrawString(statsFont, GameConstants.StrPlayAgain, strPosition, Color.AntiqueWhite);

            spriteBatch.End();

            ResetRenderStates();
        }

        private void DrawStats()
        {
            float xOffsetText, yOffsetText;
            string str1 = GameConstants.StrTimeRemaining + (roundTimer.Seconds).ToString();
            string str2 = GameConstants.StrCellsFound + retrievedFuelCells.ToString() + " of " + GetNumFuelCells(currentLevel).ToString();
            string str3 = "Level: " + currentLevel.ToString() + "/" + maxLevel.ToString();
            Rectangle rectSafeArea;

            //Calculate str1 position
            rectSafeArea = GraphicsDevice.Viewport.TitleSafeArea;

            xOffsetText = rectSafeArea.X;
            yOffsetText = rectSafeArea.Y;

            Vector2 strSize = statsFont.MeasureString(str1);
            Vector2 strPosition = new Vector2(xOffsetText + 10, yOffsetText);

            spriteBatch.Begin();
            spriteBatch.DrawString(statsFont, str1, strPosition, Color.White);
            strPosition.Y += strSize.Y;
            spriteBatch.DrawString(statsFont, str2, strPosition, Color.White);
            strPosition.Y += strSize.Y;
            spriteBatch.DrawString(statsFont, str3, strPosition, Color.Yellow); // Level in yellow
            spriteBatch.End();

            ResetRenderStates();
        }

        private void ResetRenderStates()
        {
            //re-enable depth buffer after sprite batch disablement
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
        }

        private void PlaceFuelCellsAndBarriers()
        {
            int min = GameConstants.MinDistance;
            int max = GameConstants.MaxDistance;
            Vector3 tempCenter;

            //place fuel cells
            foreach (FuelCell cell in fuelCells)
            {
                cell.Position = GenerateRandomPosition(min, max);
                tempCenter = cell.BoundingSphere.Center;
                tempCenter.X = cell.Position.X;
                tempCenter.Z = cell.Position.Z;
                cell.BoundingSphere = new BoundingSphere(tempCenter, cell.BoundingSphere.Radius);
                cell.Retrieved = false;
            }

            //place barriers
            foreach (Barrier barrier in barriers)
            {
                barrier.Position = GenerateRandomPosition(min, max);
                tempCenter = barrier.BoundingSphere.Center;
                tempCenter.X = barrier.Position.X;
                tempCenter.Z = barrier.Position.Z;
                barrier.BoundingSphere = new BoundingSphere(tempCenter, barrier.BoundingSphere.Radius);
            }
        }

        private Vector3 GenerateRandomPosition(int min, int max)
        {
            int xValue, zValue;
            do
            {
                xValue = random.Next(min, max);
                zValue = random.Next(min, max);
                if (random.Next(100) % 2 == 0)
                    xValue *= -1;
                if (random.Next(100) % 2 == 0)
                    zValue *= -1;

            } while (IsOccupied(xValue, zValue));

            return new Vector3(xValue, 0, zValue);
        }

        private bool IsOccupied(int xValue, int zValue)
        {
            foreach (GameObject currentObj in fuelCells)
            {
                if (currentObj?.Position != null &&
                    ((int)(MathHelper.Distance(xValue, currentObj.Position.X)) < 15) &&
                    ((int)(MathHelper.Distance(zValue, currentObj.Position.Z)) < 15))
                {
                    return true;
                }
            }

            foreach (GameObject currentObj in barriers)
            {
                if (currentObj?.Position != null &&
                    ((int)(MathHelper.Distance(xValue, currentObj.Position.X)) < 15) &&
                    ((int)(MathHelper.Distance(zValue, currentObj.Position.Z)) < 15))
                {
                    return true;
                }
            }
            return false;
        }

        private void CreateVisibleBoundaries()
        {
            int boundaryDistance = GameConstants.MaxRange - 5;
            List<Barrier> boundaries = new List<Barrier>();
            int spacing = 15;

            // North and South boundaries
            for (int x = -boundaryDistance; x <= boundaryDistance; x += spacing)
            {
                // North
                Barrier northMarker = new Barrier();
                northMarker.LoadContent(Content, "Models/stone_largeD");
                northMarker.Position = new Vector3(x, 0, boundaryDistance);
                boundaries.Add(northMarker);

                // South
                Barrier southMarker = new Barrier();
                southMarker.LoadContent(Content, "Models/stone_largeD");
                southMarker.Position = new Vector3(x, 0, -boundaryDistance);
                boundaries.Add(southMarker);
            }

            // East and West boundaries
            for (int z = -boundaryDistance + spacing; z < boundaryDistance; z += spacing)
            {
                // East
                Barrier eastMarker = new Barrier();
                eastMarker.LoadContent(Content, "Models/stone_largeD");
                eastMarker.Position = new Vector3(boundaryDistance, 0, z);
                boundaries.Add(eastMarker);

                // West
                Barrier westMarker = new Barrier();
                westMarker.LoadContent(Content, "Models/stone_largeD");
                westMarker.Position = new Vector3(-boundaryDistance, 0, z);
                boundaries.Add(westMarker);
            }

            boundaryBarriers = boundaries.ToArray();

            // Set bounding spheres
            foreach (Barrier boundary in boundaryBarriers)
            {
                Vector3 tempCenter = boundary.BoundingSphere.Center;
                tempCenter.X = boundary.Position.X;
                tempCenter.Z = boundary.Position.Z;
                boundary.BoundingSphere = new BoundingSphere(tempCenter, boundary.BoundingSphere.Radius);
            }
        }

        private void ResetGame(GameTime gameTime, float aspectRatio)
        {
            currentLevel = 1; // Reset to level 1
            cloudsInitialized = false; // Reset clouds

            fuelCarrier.Reset();
            gameCamera.Update(fuelCarrier.ForwardDirection, fuelCarrier.Position, aspectRatio);
            InitializeGameField();

            retrievedFuelCells = 0;
            startTime = gameTime.TotalGameTime;
            roundTimer = GetLevelTime(currentLevel);
            currentGameState = GameState.Running;

            // We use a try catch around the Media player, else in debug mode it can cause an exception which we need to catch.
            try
            {
                MediaPlayer.Stop();
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.5f;
                MediaPlayer.Play(backgroundMusic);
            }
            catch { }
        }

        private void InitializeGameField()
        {
            // Initialize fuel cells based on current level
            int numFuelCells = GetNumFuelCells(currentLevel);
            fuelCells = new FuelCell[numFuelCells];
            for (int index = 0; index < numFuelCells; index++)
            {
                fuelCells[index] = new FuelCell();
                fuelCells[index].LoadContent(Content, "Models/flower_redB");
            }

            // Initialize barriers based on current level
            int numBarriers = GetNumBarriers(currentLevel);
            barriers = new Barrier[numBarriers];
            int randomBarrier = random.Next(3);
            string barrierName = null;

            for (int index = 0; index < numBarriers; index++)
            {
                switch (randomBarrier)
                {
                    case 0:
                        barrierName = "Models/tree_palm";
                        break;
                    case 1:
                        barrierName = "Models/rock_smallF";
                        break;
                    case 2:
                        barrierName = "Models/stone_largeD";
                        break;
                }
                barriers[index] = new Barrier();
                barriers[index].LoadContent(Content, barrierName);
                randomBarrier = random.Next(3);
            }

            //CreateVisibleBoundaries();
            PlaceFuelCellsAndBarriers();
        }
    }
}