namespace webapiexamp.data
{
	public class ComputersRepo
	{
		private readonly DbContextMySql _dataContext;

		public ComputersRepo(DbContextMySql dataContext)
		{
			_dataContext = dataContext;
		}

		public IEnumerable<Computer> GetAll()
		{
			return _dataContext.Computers.ToArray();
		}
	}
}
