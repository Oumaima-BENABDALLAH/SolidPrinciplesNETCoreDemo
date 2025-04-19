# Utilisation des Principes SOLID dans un Projet C#

## Introduction

Les principes SOLID sont un ensemble de cinq principes de conception qui visent à rendre le code plus compréhensible, flexible et maintenable. Ces principes sont particulièrement utiles dans le développement de logiciels orientés objet. Dans ce document, nous allons explorer chaque principe SOLID et comment les appliquer dans un projet C#.

## Les Principes SOLID

### 1. Single Responsibility Principle (SRP)

**Principe :** Une classe ne doit avoir qu'une seule raison de changer, c'est-à-dire qu'elle doit avoir une seule responsabilité.

**Application :**
- Créez des classes qui se concentrent sur une seule tâche. Par exemple, si vous avez une classe `User `, elle ne devrait gérer que les opérations liées à l'utilisateur, comme la création et la validation, mais pas l'envoi d'e-mails.

```csharp
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserService
{
    public void CreateUser (User user)
    {
        // Logique pour créer un utilisateur
    }
}

```
### 2. Open/Closed Principle (OCP)
**Principe :** Les entités de logiciel doivent être ouvertes à l'extension mais fermées à la modification.

**Application :**

Utilisez des interfaces ou des classes abstraites pour permettre l'extension des fonctionnalités sans modifier le code existant.
</pre>
```csharp
public interface INotificationService
{
    void SendNotification(string message);
}

public class EmailNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        // Logique pour envoyer un e-mail
        Console.WriteLine($"Email sent: {message}");
    }
}

public class SmsNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        // Logique pour envoyer un SMS
        Console.WriteLine($"SMS sent: {message}");
    }
}
```
### 3. Liskov Substitution Principle (LSP)
** Principe : ** Les objets d'une classe dérivée doivent pouvoir remplacer les objets de la classe de base sans altérer le comportement du programme.

*** Application ***

Assurez-vous que les classes dérivées respectent le contrat de la classe de base.

# 4. Interface Segregation Principle (ISP)
** Principe : ** Les clients ne doivent pas être forcés de dépendre d'interfaces qu'ils n'utilisent pas.

*** Application : ***

Créez des interfaces spécifiques plutôt qu'une interface générale.
```csharp

public interface IEmailService
{
    void SendEmail(string message);
}

public interface ISmsService
{
    void SendSms(string message);
}

public class EmailNotificationService : IEmailService
{
    public void SendEmail(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class SmsNotificationService : ISmsService
{
    public void SendSms(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}
```
## 5. Dependency Inversion Principle (DIP)
**Principe :** Les modules de haut niveau ne doivent pas dépendre des modules de bas niveau. Les deux doivent dépendre d'abstractions.

*** Application ***

Utilisez l'injection de dépendances pour gérer les dépendances entre les classes.
```csharp

public interface IUserRepository
{
    void AddUser (User user);
}

public class UserRepository : IUserRepository
{
    public void AddUser (User user)
    {
        // Logique pour ajouter un utilisateur à la base de données
        Console.WriteLine($"User  {user.Name} added.");
    }
}

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUser Repository userRepository)
    {
        _userRepository = userRepository;
    }

    public void CreateUser (User user)
    {
        _userRepository.AddUser (user);
    }
}

******* Utilisation
var userRepository = new UserRepository();
var userService = new UserService(userRepository);
userService.Create
