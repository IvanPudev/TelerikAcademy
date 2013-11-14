/// <reference path="../snake-game/scripts/snake.js" />

module("SnakePiece.init");
test("should set correct values",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);

      ok(piece instanceof snakeGame.GameObject, "SnakePiece is instance of GameObject");
      ok(piece instanceof snakeGame.MovingGameObject, "SnakePiece is instance of MovingGameObject");
      deepEqual(piece.position, { x: 150, y: 150 }, "Correct position value set");
      deepEqual(piece.size, 15, "Correct size value set");
      deepEqual(piece.speed, 5, "Correct speed value set");
      deepEqual(piece.direction, 0, "Correct direction value set");
  });

module("SnakePiece.move");
test("When direction is 0, decrease x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      deepEqual(piece.position, { x: 145, y: 150 }, "Moves left");
  });
test("When  direction is 1, decrease update y",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      deepEqual(piece.position, { x: 150, y: 145 }, "Moves up");
  });
test("When  direction is 2, increase x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      deepEqual(piece.position, { x: 155, y: 150 }, "Moves right");
  });
test("When  direction is 3, should increase y",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 3;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      deepEqual(piece.position, { x: 150, y: 155 }, "Moves down");
  });

module("SnakePiece.changeDirection");
test("Test changing direction from 0",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);

      piece.changeDirection(0);
      deepEqual(piece.direction, 0, "Change from 0 to 0, stays 0");

      piece.changeDirection(1);
      deepEqual(piece.direction, 1, "Change from 0 to 1, becomes 1");

      piece.direction = 0;
      piece.changeDirection(2);
      deepEqual(piece.direction, 0, "Change from 0 to 2, stays 0");

      piece.direction = 0;
      piece.changeDirection(3);
      deepEqual(piece.direction, 3, "Change from 0 to 3, becomes 3");

      piece.direction = 0;
      piece.changeDirection(4);
      deepEqual(piece.direction, 0, "Change from 0 to 4, stays 0");
  });

test("Test changing direction from 1",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);

      piece.changeDirection(0);
      deepEqual(piece.direction, 0, "Change from 1 to 0, becomes 0");

      piece.changeDirection(1);
      deepEqual(piece.direction, 1, "Change from 1 to 1, stays 1");

      piece.direction = 1;
      piece.changeDirection(2);
      deepEqual(piece.direction, 2, "Change from 1 to 2, becomes 2");

      piece.direction = 1;
      piece.changeDirection(3);
      deepEqual(piece.direction, 1, "Change from 1 to 3, stays 1");

      piece.direction = 1;
      piece.changeDirection(4);
      deepEqual(piece.direction, 1, "Change from 1 to 4, stays 1");
  });

test("Test changing direction from 2",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);

      piece.changeDirection(0);
      deepEqual(piece.direction, 2, "Change from 2 to 0, stays 2");

      piece.direction = 2;
      piece.changeDirection(1);
      deepEqual(piece.direction, 1, "Change from 2 to 1, becomes 1");

      piece.direction = 2;
      piece.changeDirection(2);
      deepEqual(piece.direction, 2, "Change from 2 to 2, stays 2");

      piece.direction = 2;
      piece.changeDirection(3);
      deepEqual(piece.direction, 3, "Change from 2 to 3, becomes 3");

      piece.direction = 2;
      piece.changeDirection(4);
      deepEqual(piece.direction, 2, "Change from 2 to 4, stays 2");
  });

test("Test changing direction from 3",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 3;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);

      piece.changeDirection(0);
      deepEqual(piece.direction, 0, "Change from 3 to 0, becomes 0");

      piece.direction = 3;
      piece.changeDirection(1);
      deepEqual(piece.direction, 3, "Change from 3 to 1, stays 3");

      piece.direction = 3;
      piece.changeDirection(2);
      deepEqual(piece.direction, 2, "Change from 3 to 2, becomes 2");

      piece.direction = 3;
      piece.changeDirection(3);
      deepEqual(piece.direction, 3, "Change from 3 to 3, stays 3");

      piece.direction = 3;
      piece.changeDirection(4);
      deepEqual(piece.direction, 3, "Change from 3 to 4, stays 3");
  });