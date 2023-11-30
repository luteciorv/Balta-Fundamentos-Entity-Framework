using Blog.Data;
using Blog.Models;

using var context = new BlogDataContext();

RegisterPost(context);

static void RegisterPost(BlogDataContext context)
{
    var user = new User
    {
        Name = "Balta",
        Email = "balta@localhost.com",
        Bio = "12x Microsoft MVP",
        Image = "https://local...",
        PasswordHash = "123456",
        Slug = "balta"
    };

    var category = new Category
    {
        Name = "C#",
        Slug = "csharp"
    };

    var post = new Post
    {
        Author = user,
        Category = category,
        Body = "<strong>Hello World</strong>",
        Slug = "comecando-com-ef-core",
        Summary = "Neste artigo vamos aprender sobre Entity Framework Core",
        Title = "Começando com o EF Core",
        CreateDate = DateTime.Now,
        LastUpdateDate = DateTime.Now
    };

    context.Posts.Add(post);
    context.SaveChanges();

    Console.WriteLine("O novo post foi criado com sucesso");
}

static void GetTags(BlogDataContext context)
{
    Console.WriteLine("| TAGS |");
    foreach (var tag in context.Tags)
    {
        Console.WriteLine($"- Id: {tag.Id} \n" +
                          $"- Nome: {tag.Name} \n" +
                          $"- Url: {tag.Slug}");

        Console.WriteLine();
    }
}