namespace C_Sharp.OOP
{
	public interface ILogger
	{
		void LogInfo(string message);
		void LogError(string message);
	}

  public class ConsoleLog : ILogger
  {
    public void LogError(string message) => WriteLog(message, "ERROR");

    public void LogInfo(string message) => WriteLog(message, "INFO");

		private void WriteLog(string message, string messageType)
		{
			Console.ForegroundColor = messageType == "INFO" ? ConsoleColor.Green : ConsoleColor.Red;
			Console.WriteLine(message);
		}
  }

  public class FileLogger(string _path) : ILogger
  {
    public void LogError(string message) => Log(message, "ERROR");

    public void LogInfo(string message) => Log(message, "INFO"); 
		
		private void Log(string message, string messageType)
		{
      using var streamWrite = new StreamWriter(_path, true);
      streamWrite.WriteLine($"{messageType}: {message}");
			streamWrite.Dispose();
    }
  }


	// Open for extension. In this case the DbMigrator is open for the extension and the
	// extension was applied creating ConsoleLog and FileLogger Classes using is the ILogger interface.

	public class DbMigrator(ILogger logger)
  {
    private readonly ILogger _logger = logger;

		public void Migrate()
		{
			_logger.LogInfo($"Migration stater at {DateTime.Now}");
			// Detail of migration 
			_logger.LogInfo($"Migration finished at {DateTime.Now}");
		}
	}
	


  public class Interface_Extensibility
	{
		public static void Run_Interface_Extensibility()
		{
			var dbMigratorWithConsoleLog = new DbMigrator(new ConsoleLog());
			dbMigratorWithConsoleLog.Migrate();

			var dbMigratorWithFileLog = new DbMigrator(new FileLogger($"c:\\Users\\esteb\\Log.txt"));
			dbMigratorWithFileLog.Migrate();
		}
	}
}