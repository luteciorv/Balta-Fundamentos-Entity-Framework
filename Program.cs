using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();

UpdatePost(context);
GetPosts(context);

static void GetPosts(BlogDataContext context)
{
    var post = context.Posts
                .AsNoTracking()
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .FirstOrDefault();

    if(post is null)
    {
        Console.WriteLine("Nenhum post encontrado");
        return;
    }

    Console.WriteLine($"- Id: {post.Id} \n" +
                      $"- Título: {post.Title} \n" +
                      $"- Autor: {post.Author?.Name} \n" +
                      $"- Categoria: {post.Category?.Name}");

    var tags = "Nenhuma tag associada";
    if(post.Tags.Count > 0)
    {
        tags = "";
        foreach (var tag in post.Tags)
        {
            tags += tag?.Name + ", ";
        }

        tags = tags.Remove(tags.Length - 2);
    }

    Console.WriteLine($"- Tag: {tags}");
}

static void UpdatePost(BlogDataContext context)
{
    var post = context.Posts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .FirstOrDefault();

    if (post is null || post.Tags is null)
    {
        Console.WriteLine("Nenhum post encontrado");
        return;
    }

    post.Tags.Add(new()
    {
        Name = ".NET Framework",
        Slug = "dotnet-framework"
    });

    context.Posts.Update(post);
    context.SaveChanges();

    Console.WriteLine("Nova tag adicionada com sucesso");
}

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
}; ;