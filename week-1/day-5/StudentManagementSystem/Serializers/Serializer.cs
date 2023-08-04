using System.Text.Json;

namespace StudentManagementSystem.Serializers;

class Serializer<T>
{
    public static async Task ToJson(List<T> students, string filePath)
    {
        var json = JsonSerializer.Serialize(students);
        await File.WriteAllTextAsync(filePath, json);
    }

    public static async Task<List<T>> FromJson(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<T>>(json)!;
    }
}