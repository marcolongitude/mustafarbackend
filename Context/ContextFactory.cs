namespace mustafarbackend.Context
{
    public class ContextFactory: IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var dbConnectionString = "Server=localhost;Database=sfe_contatos6;Uid=root;Pwd=Adminmagti*1981";
            //var dbConnectionString = "Persist Security Info=True;Server=127.0.0.1,1433;Initial Catalog=dbIntegration1;MultipleActiveResultSets=true; User Id=sa;Password=Adminmagti*1981";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(dbConnectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
