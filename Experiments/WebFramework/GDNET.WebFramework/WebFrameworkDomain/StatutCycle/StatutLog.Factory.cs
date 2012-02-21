namespace WebFrameworkDomain.StatutCycle
{
    public partial class StatutLog
    {
        public static StatutLogFactory Factory
        {
            get { return new StatutLogFactory(); }
        }

        public class StatutLogFactory
        {
            public StatutLog Create()
            {
                return new StatutLog();
            }

            public StatutLog Create(string description, string technicalLog)
            {
                var sl = this.Create();
                sl.Description = description;
                sl.TechnicalLog = technicalLog;

                return sl;
            }
        }
    }
}
