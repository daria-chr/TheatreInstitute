using TheatreApi.Models;

namespace TheatreApi.Data;

public static class ApplicationsStore
{
    public static List<Application> Applications { get; } = new()
    {
        new Application { Id = 1, Name = "Иванова Мария", Phone = "+7 999 111-22-33", Email = "m@mail.ru", Program = "Актёрское мастерство", Status = "Новая" },
        new Application { Id = 2, Name = "Петров Алексей", Phone = "+7 999 444-55-66", Email = "a@mail.ru", Program = "Режиссура", Status = "Рассматривается" }
    };

    private static int _nextId = 3;

    public static int GetNextId() => _nextId++;
}