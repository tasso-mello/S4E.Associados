﻿using domain.S4E.Associados.Properties;

namespace domain.S4E.Associados.Queries;

public static class Queries
{
    public static string CreateDatabase()
        => Resources.CreateDatabase;

    public static string CreateTables()
        => Resources.CreateTables;

    public static string InitialSeed()
        => Resources.InitialSeed;
}
