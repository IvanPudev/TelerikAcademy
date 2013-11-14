using System;
using System.Linq;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(startRow - 3, i));
                engine.AddObject(ceiling);
            }

            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(i, startCol - 2));
                engine.AddObject(leftWall);
            }

            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(i, startCol + 37));
                engine.AddObject(rightWall);
            }

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }
            // Exploding Block
            for (int i = startCol; i < endCol; i+=10)
            {
                ExplodingBlock currBlock = new ExplodingBlock(new MatrixCoords(startRow + 1, i));

                engine.AddObject(currBlock);
            }
            // Unpassable Block
            for (int i = startCol; i < endCol; i += 10)
            {
                UnpassableBlock currBlock = new UnpassableBlock(new MatrixCoords(startRow + 3, i));

                engine.AddObject(currBlock);
            }
            // Gift Block
            for (int i = startCol; i < endCol; i += 10)
            {
                GiftBlock currBlock = new GiftBlock(new MatrixCoords(startRow + 2, i));

                engine.AddObject(currBlock);
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            //engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            //Meteorite Ball
            MeteoriteBall meteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows - 1, 3), new MatrixCoords(-1,1), 5);

            //engine.AddObject(meteoriteBall);

            //Unstoppable Ball
            Ball UnstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(UnstoppableBall);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
