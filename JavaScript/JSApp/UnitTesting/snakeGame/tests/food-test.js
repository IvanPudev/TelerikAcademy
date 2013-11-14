
module("Food.init");
test("should set correct values",
  function () {
      var position = { x: 150, y: 150 }, size = 10;
      var food = new snakeGame.Food(position, size);

      ok(food instanceof snakeGame.GameObject, "Food inherits GameObject")
      deepEqual(food.position, { x: 150, y: 150 }, "Possition value is correct")
      deepEqual(food.size, 10, "Size value is correct");
  });