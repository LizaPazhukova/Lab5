using Autofac;

namespace SQL_ADO.DAL
{
    public class ADODalModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter("connectionString", @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
