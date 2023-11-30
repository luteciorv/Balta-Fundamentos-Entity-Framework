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
}

static void UpdatePost(BlogDataContext context)
{
    var post = context.Posts
                .AsNoTracking()
                .Include(p => p.Author)
                .Include(p => p.Category)
                .FirstOrDefault();

    if (post is null || post.Author is null)
    {
        Console.WriteLine("Nenhum post encontrado");
        return;
    }

    post.Author.Name = "Nome teste";

    context.Posts.Update(post);
    context.SaveChanges();
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