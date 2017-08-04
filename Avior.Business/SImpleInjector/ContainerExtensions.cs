using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Avior.Base.Helpers;
using Avior.Base.Interfaces;
using Avior.Business.Queries;
using Avior.Business.UnitOfWork;
using Avior.Database.Data;

namespace Avior.Business.SImpleInjector
{
    public static class ContainerExtensions
    {
        public static void RegisterUnitOfWorks(this Container container)
        {
            container.Register<IDataUnitOfWork, DataUnitOfWork>(Lifestyle.Scoped);
            container.Register<IRepositoryMapper, EntityFrameWorkRepositoryMapper>(Lifestyle.Scoped);
            container.Register<DbContext, AviorDbContext>(Lifestyle.Scoped);
        }

        public static void RegisterCommonTypes(this Container container)
        {
            //container.RegisterAutoScoped<IClock>(
            //    () =>
            //        new RealClock(configuration.ActivateAccountToken_TtlHours,
            //            configuration.RestorePasswordToken_TtlHours));
            //container.RegisterAutoScoped<IGenerateSalt>(() => new SaltGenerator(configuration.PasswordSaltLength));
            //container.RegisterAutoScoped<IHashPassword, PBKDF2SHA1PasswordHasher>();
            //container.RegisterAutoScoped<IValidateAuthorisations, AuthorisationValidator>();
            //container.RegisterAutoScoped<IWord, Word>();
            //container.RegisterAutoScoped<IExcel, Excel>();
            //container.RegisterAutoScoped<IPdf, Pdf>();
            //container.RegisterAutoScoped<IFormsEngine, FormsEngine.FormsEngine>();
            //container.RegisterAutoScoped<PasswordValidator>();
            //container.RegisterAutoScoped<FeatureFetcher>();
            //container.RegisterAutoScoped<ICheckDigit, CheckDigit>();
            //container.RegisterAutoScoped<IRssReader, RssReader>();
            //container.RegisterAutoScoped<IReportReader, ReportReader>();
            //container.RegisterAutoScoped<IUserSessionManager, UserSessionManager>();
            //container.RegisterAutoScoped<IAuthenticationCookie, AuthenticationCookie>();
            //container.RegisterSingleton(SecurityConfiguration.GetDefault);
            //container.RegisterAutoScoped<FeatureFlags>();
            //container.RegisterAutoScoped<PreconditionIbFacade>();
            //container.RegisterAutoScoped<PreconditionVpbFacade>();
            //container.RegisterAutoScoped<XbrlDeferralRequestGenerator>();
            //container.RegisterAutoScoped<XbrlDeferralRequestMessageProcessor>();
            //container.RegisterAutoScoped<IFunctionEnabled<MuMaType>, IsMuMaTypeEnabled>();
            //container.RegisterAutoScoped(() => FeatureFlagSettings.FromSettings(ConfigurationManager.AppSettings));

            //container.RegisterAutoScoped<TaxReturnStatusHistoryDao>();
            //container.RegisterAutoScoped<DeferralStatusHelper>();

            //container.RegisterAutoScoped<IViaMappingReader, ViaMappingReader>();
            //container.RegisterAutoScoped<ViaService>();
            //container.RegisterAutoScoped<TaxReturnLockManager>();

            //container.RegisterAutoScoped<ImportFileReader>();
            //container.RegisterSingleton<Func<TextReader, CsvConfiguration, CsvReader>>(
            //    (reader, csvConfiguration) => new CsvReader(reader, csvConfiguration));
            //container.RegisterAutoScoped<ImportExportLogger>();
            //container.RegisterAutoScoped<TaxReturnImporterFactory>();
            //container.RegisterAutoScoped<ILogProgress, LogProgress.LogProgress>();

            //container.RegisterAutoScoped<OnPremiseDatabaseMigrationService>();

            //container.RegisterAutoScoped<TaxOfficeCredentialsStore>();

            //container.RegisterAutoScoped<UserPreferenceStorage>();
            //container.Register<UserPreference>();

            //container.RegisterAutoScoped<OfficeBlobStorage>();
            //container.RegisterSingleton<SapRegisteredKbpProductsStore>();

            //container.RegisterAutoScoped<IDistributedKeyValueStore, DatabaseDistributedKeyValueStore>();

            //container.RegisterAutoScoped(() =>
            //{
            //    var userContext = container.GetInstance<UserContext>();
            //    var entityConnectionString =
            //        new EntityConnectionStringBuilder(
            //            DatabaseConnectionString.Create(ConnectionContainer.LynxDataContainer, userContext.DataDbServer,
            //                userContext.DataDb, userContext.UserName, userContext.Password).ToString());
            //    return new SelectionQueryExecutor(entityConnectionString.ProviderConnectionString);
            //});

            //container.RegisterAutoScoped(() =>
            //{
            //    var userContext = container.GetInstance<UserContext>();
            //    var entityConnectionString =
            //        new EntityConnectionStringBuilder(
            //            DatabaseConnectionString.Create(ConnectionContainer.LynxDataContainer, userContext.DataDbServer,
            //                userContext.DataDb, userContext.UserName, userContext.Password).ToString());
            //    return new TaxAssessmentDashboardQueryExecutor(entityConnectionString.ProviderConnectionString);
            //});

            //container.RegisterAutoScoped(() =>
            //{
            //    var userContext = container.GetInstance<UserContext>();
            //    var entityConnectionString =
            //        new EntityConnectionStringBuilder(
            //            DatabaseConnectionString.Create(ConnectionContainer.LynxDataContainer, userContext.DataDbServer,
            //                userContext.DataDb, userContext.UserName, userContext.Password).ToString());
            //    return new FiscalDashboardQueryFactoryExecutor(entityConnectionString.ProviderConnectionString);
            //});

            //container.RegisterAutoScoped<DataAnalysesReporter>();
            //container.RegisterCollection(typeof(IDataAnalyser), typeof(IDataAnalyser).Assembly);

            //container.RegisterAutoScoped<OfficeService>();
            //container.RegisterAutoScoped<LicenseService>();
            //container.RegisterAutoScoped<TaxReturnService>();
            //container.RegisterAutoScoped<DeferralRequestService>();

            //container.RegisterAutoScoped<IDeferralRequestDao, DeferralRequestDao>();
        }

        public static void RegisterQueryHandling(this Container container)
        {
            var assemblies = ReflectionHelper.GetLynxAssemblies().ToArray();

            container.Register<IQueryProcessor, QueryProcessor>(Lifestyle.Scoped);
            container.Register(typeof(IQueryHandler<,>), assemblies, Lifestyle.Scoped);
        }
    }
}