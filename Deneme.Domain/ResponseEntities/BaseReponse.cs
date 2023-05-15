using Deneme.Domain.Enums;

namespace Deneme.Domain.ReponseEntities
{
	public class BaseReponse<T>
	{
		public string Title { get; set; }
		public string Message { get; set; }
		public ResultStatus ResultStatus { get; set; }
		public T ResultObject { get; set; }
		public ICollection<T> ResultObjects { get; set; }
		public string Url { get; set; }
	}
}
