
namespace TaxInspection
{
    using log4net;
    using log4net.Config;

    public class Logger
    {
        private static ILog _log = LogManager.GetLogger("LOGGER");

        public static ILog Log => _log;

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
