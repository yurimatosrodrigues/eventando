namespace eventando.Dados
{
    public static class DbInitializer
    {
        public static void Initialize(EventosContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
