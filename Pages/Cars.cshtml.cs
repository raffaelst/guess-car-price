using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Doors { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public bool ShowMessage { get; set; }
}

public class CarsModel : PageModel
{
    private List<Car> cars = new()
    {
        new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
        new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
        new Car { Id = 3, Make = "Porsche", Model = "911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
        new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
        new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 }
    };

    [BindProperty]
    public int Guess { get; set; }

    public List<Car> Cars => cars;

    public void OnPost(int carId)
    {
        var car = cars.Find(c => c.Id == carId);
        if (car != null)
        {
            car.ShowMessage = IsGuessClose(car.Price, Guess);
        }
    }

    private bool IsGuessClose(decimal actualPrice, int guess)
    {
        return Math.Abs(actualPrice - guess) <= 5000;
    }
}
