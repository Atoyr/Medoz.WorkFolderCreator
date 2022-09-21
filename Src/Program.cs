using Medoz.CommandLine;
var app = Cli.NewApp();

app.Flags.Add(new StringFlag("directory"){ Alias = new string[] { "d" }, Usage = "Directory to create work folder"});

app.Action = ctx => {
    string dir = ctx.String("directory");

    if (!Directory.Exists(dir))
    {
        Console.WriteLine("directory not found");
        return;
    }

    string date = DateTime.Now.ToString("yyyyMMdd");
    string fullPath = Path.Combine(Path.GetFullPath(dir), date);
    int i = 0;
    while(Directory.Exists(fullPath))
    {
        i++;
        fullPath = Path.Combine(Path.GetFullPath(dir), $"{date}_{i.ToString()}");
    }

    Directory.CreateDirectory(fullPath);
};

app.Run(args);
