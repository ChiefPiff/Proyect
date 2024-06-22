using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class UserDataService
{
    private List<User> users;
    private string usersFilePath = "users.json";


    public UserDataService()
    {
        users = LoadUsers();
    }

    public List<User> LoadUsers()
    {
        if (File.Exists(usersFilePath))
        {
            string json = File.ReadAllText(usersFilePath);
            return JsonSerializer.Deserialize<List<User>>(json);
        }
        else
        {
            return new List<User>();
        }
    }

    public void SaveUsers()
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(usersFilePath, json);
    }

    public bool RegisterUser(User newUser)
    {
        if (!IsUsernameTaken(newUser.Username))
        {
            newUser.UserId = GenerateUserId();
            users.Add(newUser);
            SaveUsers();
            return true;
        }
        return false;
    }

    public List<User> LoadUsersFromJsonFile()
    {
        List<User> users = new List<User>();

        string json = File.ReadAllText("users.json");

        users = JsonSerializer.Deserialize<List<User>>(json);

        return users;
    }

    public User LoginUser(string username, string password)
    {
        List<User> users = LoadUsersFromJsonFile();

        User user = users.FirstOrDefault(u => u.Username == username);

        if (user != null)
        {
            if (user.Password == password)
            {
                return user;
            }
        }

        return null;
    }

    public bool IsUsernameTaken(string username)
    {
        return users.Any(user => user.Username == username);
    }

    public int GenerateUserId()
    {
        int maxUserId = users.Any() ? users.Max(user => user.UserId) : 0;
        return ++maxUserId; // Инкрементируем максимальный идентификатор и возвращаем
    }
}

